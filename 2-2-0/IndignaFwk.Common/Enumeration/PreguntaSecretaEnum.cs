using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Enumeration
{
    public class PreguntaSecretaEnum
    {
        public static readonly PreguntaSecretaEnum LUGAR_FAVORITO = new PreguntaSecretaEnum("Lugar favorito");

        public static readonly PreguntaSecretaEnum COLOR_FAVORITO = new PreguntaSecretaEnum("Color favorito");

        public static readonly PreguntaSecretaEnum CANCION_FAVORITA = new PreguntaSecretaEnum("Canción favorita");

        public string Valor { get; private set; }

        private PreguntaSecretaEnum(string valor) 
        {
            this.Valor = valor;
        }

        public static PreguntaSecretaEnum FromString(string strTipo)
        {
            if (LUGAR_FAVORITO.Valor.Equals(strTipo))
            {
                return LUGAR_FAVORITO;
            }
            else if (COLOR_FAVORITO.Valor.Equals(strTipo))
            {
                return COLOR_FAVORITO;
            }
            else if (CANCION_FAVORITA.Valor.Equals(strTipo))
            {
                return CANCION_FAVORITA;
            }
            else
            {
                return null;
            }
        }

        public static List<PreguntaSecretaEnum> ObtenerListado()
        {
            List<PreguntaSecretaEnum> listado = new List<PreguntaSecretaEnum>();

            listado.Add(LUGAR_FAVORITO);

            listado.Add(COLOR_FAVORITO);

            listado.Add(CANCION_FAVORITA);

            return listado;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            PreguntaSecretaEnum tObj = (PreguntaSecretaEnum)obj;

            return this.Valor.Equals(tObj.Valor);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Valor;
        }
    }
}
