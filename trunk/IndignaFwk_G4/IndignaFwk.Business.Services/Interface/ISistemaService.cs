using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace IndignaFwk.Business.Services.Interface
{
    [ServiceContract(
    Namespace = "http://localhost//IndignaFwk//2012",
    SessionMode = SessionMode.Allowed)] 
    public interface ISistemaService
    {
    }
}
