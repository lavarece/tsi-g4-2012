using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class Grupo
    {
        private int _id;

        public int Id 
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

        private string _nombre;

        public string Nombre
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


        public string LogoUrl { get; set; }

        public string Descripcion { get; set; }

        public List<Contenido> ListaContenido { get; set; }

        public Template Template { get; set; }

        public List<Imagen> ListaImagen { get; set; }

        public string Url { get; set; }



    }
}
