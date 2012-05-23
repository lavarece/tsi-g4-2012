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
    public class Convocatoria
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Quorum { get; set; }

        [DataMember]
        public string Coordenadas { get; set; }

        [DataMember]
        public string LogoUrl { get; set; }

        [DataMember]
        public Tematica Tematica { get; set; }

        [DataMember]
        public Grupo Grupo { get; set; }

        [DataMember]
        public Usuario UsuarioCreacion { get; set; }
    }
}
