using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Enumeration
{
    public class TipoMarcaContenidoEnum
    {
        public static readonly TipoMarcaContenidoEnum ME_GUSTA = new TipoMarcaContenidoEnum("ME_GUSTA", "Me gusta");

        public static readonly TipoMarcaContenidoEnum INADECUADO = new TipoMarcaContenidoEnum("INADECUADO", "Inadecuado");

        public string Valor { get; private set; }

        public string Etiqueta { get; private set; }

        private TipoMarcaContenidoEnum(string valor, string etiqueta)
        {
            this.Valor = valor;

            this.Etiqueta = etiqueta;
        }

        public static TipoMarcaContenidoEnum FromString(string strTipo)
        {
            if (ME_GUSTA.Valor.Equals(strTipo))
            {
                return ME_GUSTA;
            }
            else if (INADECUADO.Valor.Equals(strTipo))
            {
                return INADECUADO;
            }
            else
            {
                return null;
            }
        }

        public static List<TipoMarcaContenidoEnum> ObtenerListado()
        {
            List<TipoMarcaContenidoEnum> listado = new List<TipoMarcaContenidoEnum>();

            listado.Add(ME_GUSTA);

            listado.Add(INADECUADO);

            return listado;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            TipoMarcaContenidoEnum tobj = (TipoMarcaContenidoEnum)obj;

            return this.Valor.Equals(tobj.Valor);
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
