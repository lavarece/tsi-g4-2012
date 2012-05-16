using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Grupo
    {
        private Int32 _id;

        public Int32 Id 
        {
            get   
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        private String _nombre;

        public String Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = value;
            }
        }


        public String LogoUrl { get; set; }

        public String Descripcion { get; set; }

        public List<Contenido> ListaContenido { get; set; }

        public Template Template { get; set; }

        public List<Imagen> ListaImagen { get; set; }

        public String Url { get; set; }



    }
}
