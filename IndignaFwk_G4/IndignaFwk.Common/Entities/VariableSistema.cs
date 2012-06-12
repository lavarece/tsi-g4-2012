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
    public class VariableSistema
    {
        public static readonly int N = 1;
        public static readonly int M = 2;
        public static readonly int Y = 3;
        public static readonly int Z = 4;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Valor { get; set; }

    }
}
