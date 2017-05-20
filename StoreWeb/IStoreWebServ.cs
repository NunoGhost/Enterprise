using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StoreWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStoreWebServ" in both code and config file together.
    [ServiceContract]
    public interface IStoreWebServ
    {
        [OperationContract]
        void DoWork();
    }
}
