using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Enumeration
{
    public class FuenteExternaEnum
    {
        public static readonly FuenteExternaEnum YOU_TUBE = new FuenteExternaEnum("YOU_TUBE", "You Tube");

        public static readonly FuenteExternaEnum WIKIPEDIA = new FuenteExternaEnum("WIKIPEDIA", "Wikipedia");

        public string Valor { get; private set; }

        public string Etiqueta { get; private set; }

        private FuenteExternaEnum(string valor, string etiqueta)
        {
            this.Valor = valor;

            this.Etiqueta = etiqueta;
        }
    }
}
