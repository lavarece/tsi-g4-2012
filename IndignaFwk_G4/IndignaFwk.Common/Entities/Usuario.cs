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
    public class Usuario
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public bool Conectado { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Pregunta { get; set; }

        [DataMember]
        public string Respuesta { get; set; }

        [DataMember]
        public string Coordenadas { get; set; }

        [DataMember]
        public Grupo Grupo { get; set; }

        [DataMember]
        public Imagen Imagen { get; set; }

        [DataMember]
        public List<Tematica> ListaTematicas { get; set; }

        // Retorna el nombre competo del usuario (Nombre + " " + Apellido)
        public string NombreCompleto { get { return Nombre + " " + Apellido; } }

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
