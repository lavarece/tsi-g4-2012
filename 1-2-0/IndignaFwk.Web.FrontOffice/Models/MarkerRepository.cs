using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndignaFwk.Web.FrontOffice.Models
{
    public class MarkerRepository
    {
        public IList<GoogleMarker> GetMarkers()
        {
            var googleMarkers = new List<GoogleMarker>
                                    {
                                        new GoogleMarker
                                            {
                                                SiteName = "Jardines de Sabatini",
                                                Latitude = 40.421749,
                                                Longitude = -3.713994,
                                                InfoWindow = "InfoWindow de los Jardines de Sabatini"
                                            },
                                        new GoogleMarker
                                            {
                                                SiteName = "Campo del Moro",
                                                Latitude = 40.419658,
                                                Longitude = -3.718801,
                                                InfoWindow = "InfoWindow del Campo del Moro"
                                            },
                                        new GoogleMarker
                                            {
                                                SiteName = "Parque de la Cornisa",
                                                Latitude = 40.413254,
                                                Longitude = -3.716483,
                                                InfoWindow = "InfoWindow del Parque de la Cornisa"
                                            }
                                    };

            return googleMarkers;
        }
    }
}