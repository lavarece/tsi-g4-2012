using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Util
{
    public class UtilesGenerales
    {
        // Variable exclusivamente utilitaria para indicar si se integra o no con
        // nosotros mismos, la segunda aplicacion la tendra en true
        public static Boolean INTEGRAR_CON_G4 = false;

        public const double radioTierraKm = 6371;
        
        /*       
         * Los valores de Latitud y Longitu deben proporcionarse en radianes,
         * para convertir de gradoas a radianes: Grados * PI / 180
         */
        public static double CalcularDistanciaCoordenadas(string strLat1, string strLon1, string strLat2, string strLon2)
        {
            double lat1 = Rad(Double.Parse(strLat1.Replace(".", ",")));
            double lon1 = Rad(Double.Parse(strLon1.Replace(".", ",")));
            double lat2 = Rad(Double.Parse(strLat2.Replace(".", ",")));
            double lon2 = Rad(Double.Parse(strLon2.Replace(".", ",")));

            // Calculo la diferencia de distancias en radianes
            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return radioTierraKm * c;
        }

        private static double Rad(double x)
        {
            return x * (Math.PI / 180);
        }
    }
}
