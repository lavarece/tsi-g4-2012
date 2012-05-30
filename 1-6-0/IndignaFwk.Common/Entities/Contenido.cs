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
    public class Contenido
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public string Comentario { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string NivelVisibilidad { get; set; }

        [DataMember]
        public string TipoContenido { get; set; }

        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        [DataMember]
        public Usuario UsuarioCreacion { get; set; }
    }
}
