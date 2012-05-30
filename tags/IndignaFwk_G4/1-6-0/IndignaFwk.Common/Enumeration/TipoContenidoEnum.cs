using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Common.Enumeration
{
    public class TipoContenidoEnum
    {
        public static readonly TipoContenidoEnum IMAGEN = new TipoContenidoEnum("IMAGEN", "Imagen");

        public static readonly TipoContenidoEnum VIDEO = new TipoContenidoEnum("VIDEO", "Video");

        public static readonly TipoContenidoEnum LINK = new TipoContenidoEnum("LINK", "Link");

        public string Valor { get; private set; }

        public string Etiqueta { get; private set; }

        private TipoContenidoEnum(string valor, string etiqueta) 
        {
            this.Valor = valor;

            this.Etiqueta = etiqueta;
        }

        public static List<TipoContenidoEnum> ObtenerListado()
        {
            List<TipoContenidoEnum> listado = new List<TipoContenidoEnum>();

            listado.Add(IMAGEN);

            listado.Add(VIDEO);

            listado.Add(LINK);

            return listado;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            TipoContenidoEnum tObj = (TipoContenidoEnum)obj;

            return this.Valor.Equals(tObj.Valor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
