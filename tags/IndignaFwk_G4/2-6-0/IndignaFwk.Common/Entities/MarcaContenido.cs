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
    public class MarcaContenido
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TipoMarca { get; set; }

        [DataMember]
        public Contenido Contenido { get; set; }

        [DataMember]
        public Usuario UsuarioMarca { get; set; }

    }
}
