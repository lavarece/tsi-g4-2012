using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Util
{
    public class UtilesGenerales
    {
        public static bool isNullOrEmpty(string str)
        {
            return (str == null || (str != null && str.Length == 0));
        }
    }
}
