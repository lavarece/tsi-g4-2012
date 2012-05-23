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
    public class Notificacion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Contenido { get; set; }

        [DataMember]
        public bool Visto { get; set; }
        
        [DataMember]
        public Convocatoria Convocatoria { get; set; }

        [DataMember]
        public Usuario Usuario { get; set; }
    }
}
