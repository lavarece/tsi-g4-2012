using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Enumeration
{
    public class VisibilidadContenidoEnum
    {
        public static readonly VisibilidadContenidoEnum PRIVADO = new VisibilidadContenidoEnum("PRIVADO", "Privado");

        public static readonly VisibilidadContenidoEnum PUBLICO = new VisibilidadContenidoEnum("PUBLICO", "Público");

        public string Valor { get; private set; }

        public string Etiqueta { get; private set; }

        private VisibilidadContenidoEnum(string valor, string etiqueta)
        {
            this.Valor = valor;

            this.Etiqueta = etiqueta;
        }

        public static VisibilidadContenidoEnum FromString(string strVisibilidad)
        {
            if (PRIVADO.Valor.Equals(strVisibilidad))
            {
                return PRIVADO;
            }
            else if (PUBLICO.Valor.Equals(strVisibilidad))
            {
                return PUBLICO;
            }
            else
            {
                return null;
            }
        }

        public static List<VisibilidadContenidoEnum> ObtenerListado()
        {
            List<VisibilidadContenidoEnum> listado = new List<VisibilidadContenidoEnum>();
            listado.Add(PRIVADO);
            listado.Add(PUBLICO);
            return listado;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            VisibilidadContenidoEnum tobj = (VisibilidadContenidoEnum)obj;

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
