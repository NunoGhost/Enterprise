using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Common;

namespace StoreWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StoreWebServ" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StoreWebServ.svc or StoreWebServ.svc.cs at the Solution Explorer and start debugging.
    public class StoreWebServ : IStoreWebServ
    {
        private Dictionary<string, object> _result;
        private JavaScriptSerializer s = new JavaScriptSerializer();

        public Stream AddOrder(Order order, string token)
        {
            _result = new Dictionary<string, object>();
            try
            {
                Client user = validateClient(Guid.Parse(token));
                DatabaseConnector client = new DatabaseConnector("mongodb://tdin:tdin@ds031942.mongolab.com:31942/", "store");
                var collection = client.Database.GetCollection<Order>("orders");
                var book = GetBook(order.Title);
                if (book.Quantity >= order.Quantity)
                {
                    var random = new Random();
                    var timestamp = DateTime.UtcNow;
                    var machine = random.Next(0, 16777215);
                    var pid = (short)random.Next(0, 32768);
                    var increment = random.Next(0, 16777215);
                    order.Id = new ObjectId(timestamp, machine, pid, increment).ToString();
                    order.State = new StateEnum { CurrentState = StateEnum.State.Dispatched };
                    order.State.Date = DateTime.Now.AddDays(1);
                    var query = collection.InsertOneAsync(order);
                    query.Wait();
                    if (query.IsCompleted)
                    {
                        _result.Add("Text", "Order add sucessfully");
                        _result.Add("Data", order);
                        book.Quantity -= order.Quantity;
                        UpdateBook(book);
                        NotifyClient(order);
                    }
                    else
                    {
                        throw new Exception(string.Format("Failed to register order: \n{0}", query));
                    }
                }
                else //send to mq
                {
                    var msg = new Message("restock", order.Quantity * 10, book);
                    Console.WriteLine(msg.ToString());
                    try
                    {
                        WarehouseServiceClient warehouse = new WarehouseServiceClient();
                        warehouse.SendToWarehouseAsync(msg);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        Debug.WriteLine(e.StackTrace);
                        throw;
                    }

                    var random = new Random();
                    var timestamp = DateTime.UtcNow;
                    var machine = random.Next(0, 16777215);
                    var pid = (short)random.Next(0, 32768);
                    var increment = random.Next(0, 16777215);
                    order.Id = new ObjectId(timestamp, machine, pid, increment).ToString();
                    order.State = new StateEnum();
                    order.State.CurrentState = StateEnum.State.WaitingDispatch;
                    var query = collection.InsertOneAsync(order);
                    query.Wait();
                    if (query.IsCompleted)
                    {
                        _result.Add("Text", "Order could not be fulfilled, sent message to warehouse to restock");
                        _result.Add("Data", order);
                    }
                    else
                    {
                        throw new Exception(string.Format("Failed to register order: \n{0}", query));
                    }
                }

            }
            catch (Exception e)
            {
                if (WebOperationContext.Current != null)
                {
                    OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                    response.StatusCode = HttpStatusCode.NotAcceptable;
                }
                _result.Add("Error", true);
                _result.Add("Reason", e.Message);
            }
            string result = s.Serialize(_result);
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
            return new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

    }
}
