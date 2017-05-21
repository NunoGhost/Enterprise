using System.ComponentModel;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using Common;

namespace StoreWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreWebServ" in both code and config file together.
    [ServiceContract]
    public interface IStoreWebServ
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/order/{token}")]
        [Description("")]
        Stream AddOrder(Order order, string token);
    }
}
