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
    public class UsuTematica
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Usuario Usuario { get; set; }

        [DataMember]
        public Tematica Tematica { get; set; }
    }
}
