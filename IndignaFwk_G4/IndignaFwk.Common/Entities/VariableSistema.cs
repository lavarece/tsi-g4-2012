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
        public static readonly int N = 1; // Cantidad de contenidos mejor rankeados a mostrar
        public static readonly int M = 2; // Cantidad de contenidos a mostrar temporalmente
        public static readonly int X = 3; // Cantidad de marcas inadecuado para dar de baja contenido
        public static readonly int Z = 4; // Cantidad de contenidos eliminados para dar de baja usuario

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Valor { get; set; }

    }
}
