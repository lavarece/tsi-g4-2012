using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using IndignaFwk.Common.Enumeration;

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
        public bool Eliminado { get; set; }

        [DataMember]
        public Usuario UsuarioCreacion { get; set; }

        [DataMember]
        public Grupo Grupo { get; set; }

        [DataMember]
        public int CantidadMeGusta { get; set; }

        [DataMember]
        public int CantidadInadecuado { get; set; }

        // Dato utilizado por la logica de presentacion 
        public MarcaContenido MarcaContenidoUsuario { get; set; }
    }
}
