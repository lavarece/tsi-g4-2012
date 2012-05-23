using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class GoogleMarker
    {
        public String SiteName { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public String InfoWindow { get; set; }
    }
}