using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignaFwk.Business.Services
{
    [ServiceContract(
    Namespace = "http://localhost//IndignaFwk//2012",
    SessionMode = SessionMode.Allowed)] 
    public interface ISistemaService
    {
    }
}
