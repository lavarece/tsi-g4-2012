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
        public string LogoUrl { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public List<Contenido> ListaContenido { get; set; }

        [DataMember]
        public string Template { get; set; }

        [DataMember]
        public List<Imagen> ListaImagen { get; set; }
        
        [DataMember]
        public string Url { get; set; }
    }
}
