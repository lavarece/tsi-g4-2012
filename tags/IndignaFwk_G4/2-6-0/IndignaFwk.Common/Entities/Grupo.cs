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
    public class Grupo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Coordenadas { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string AppIDFacebook { get; set; }

        [DataMember]
        public Layout Layout { get; set; }

        [DataMember]
        public Tematica Tematica { get; set; }

        [DataMember]
        public Imagen Imagen { get; set; }

        [DataMember]
        public List<FuenteExternaGrupo> FuentesExternas { get; set; }

        // Funciones auxiliares
        public string GetLatitud()
        {
            string cleanCoord = Coordenadas.Replace("(", "").Replace(")", "");

            string[] array = cleanCoord.Split(',');

            return array[0];
        }

        public string GetLongitud()
        {
            string cleanCoord = Coordenadas.Replace("(", "").Replace(")", "");

            string[] array = cleanCoord.Split(',');

            return array[1];
        }
    }
}
