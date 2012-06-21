using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace IndignaFwk.Common.Entities
{
    [DataContract]
    [Serializable]
    public class FuenteExternaGrupo
    {   
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FuenteExterna { get; set; }

        [DataMember]
        public Grupo Grupo { get; set; }   

        [DataMember]
        public string QueryString { get; set; }

        [DataMember]
        public int CantidadResultados { get; set; }
    }
}
