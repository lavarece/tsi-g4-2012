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

        public static readonly TipoContenidoEnum VIDEO_YOU_TUBE = new TipoContenidoEnum("VIDEO_YOU_TUBE", "Video YouTube");

        public static readonly TipoContenidoEnum LINK = new TipoContenidoEnum("LINK", "Link");

        public string Valor { get; private set; }

        public string Etiqueta { get; private set; }

        private TipoContenidoEnum(string valor, string etiqueta) 
        {
            this.Valor = valor;

            this.Etiqueta = etiqueta;
        }

        public static TipoContenidoEnum FromString(string strTipo)
        {
            if (IMAGEN.Valor.Equals(strTipo))
            {
                return IMAGEN;
            }
            else if (VIDEO_YOU_TUBE.Valor.Equals(strTipo))
            {
                return VIDEO_YOU_TUBE;
            }
            else if (LINK.Valor.Equals(strTipo))
            {
                return LINK;
            }
            else
            {
                return null;
            }
        }

        public static List<TipoContenidoEnum> ObtenerListado()
        {
            List<TipoContenidoEnum> listado = new List<TipoContenidoEnum>();

            listado.Add(IMAGEN);

            listado.Add(VIDEO_YOU_TUBE);

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

        public override string ToString()
        {
            return Etiqueta;
        }
    }
}
