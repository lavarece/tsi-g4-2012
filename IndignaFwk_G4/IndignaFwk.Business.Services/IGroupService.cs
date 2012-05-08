using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignaFwk.Business.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGroupService" in both code and config file together.
    [ServiceContract]
    public interface IGroupService
    {
        [OperationContract]
        void DoWork();
    }
}
