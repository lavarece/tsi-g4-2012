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

        private string _logoUrl;

        public string LogoUrl 
        {
            get
            {
                return this._logoUrl;
            }
            set
            {
                this._logoUrl = value;
            }
        }

        private string _descripcion;

        public string Descripcion 
        {

            get
            {
                return this._descripcion;
            }
            set
            {
                this._descripcion = value;
            }
        }

        private List<Contenido> _listaContenido;

        public List<Contenido> ListaContenido
        {

            get
            {
                return this._listaContenido;
            }
            set
            {
                this._listaContenido = value;
            }
        }

        private Template _template;

        public Template Template 
        {
            get
            {
                return this._template;
            }
            set
            {
                this._template = value;
            }
        }

        private List<Imagen> _imagen;

        public List<Imagen> ListaImagen 
        {
            get
            {
                return this._imagen;
            }
            set
            {
                this._imagen = value;
            }
        }

        private String _url;

        public string Url 
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }   
        }



    }
}
