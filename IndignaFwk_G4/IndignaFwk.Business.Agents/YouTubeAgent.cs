using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.YouTube;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Enumeration;

namespace IndignaFwk.Business.Agents
{
    public class YouTubeAgent
    {
        private static readonly string DEVELOPER_KEY = "AIzaSyB6nBteJRoEKT3lgTW9TqwCD47WWgDpxUo-5t3MzOgIjcvDvPf4hHE7SyQpQ5n-Rqc6aSpNV7w";

        public List<Contenido> ObtenerContenidosDeGrupo(Grupo grupo)
        {
            // Youtube request
            YouTubeRequestSettings settings = new YouTubeRequestSettings("example app", DEVELOPER_KEY);
            YouTubeRequest request = new YouTubeRequest(settings);

            // Youtube query
            YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
            query.OrderBy = "viewCount";
            query.Query = "Reggaton";
            query.SafeSearch = YouTubeQuery.SafeSearchValues.None;

            Feed<Video> videoFeed = request.Get<Video>(query);

            // Genero la lista de contenidos
            List<Contenido> listaContenidos = new List<Contenido>();

            foreach (Video video in videoFeed.Entries)
            {
                Contenido contenido = new Contenido();

                contenido.Titulo = video.Title;

                contenido.TipoContenido = TipoContenidoEnum.VIDEO_YOU_TUBE.Valor;

                contenido.Grupo = grupo;

                contenido.Externo = true;

                contenido.Url = video.ComplaintUri.AbsolutePath;

                listaContenidos.Add(contenido);
            }

            return listaContenidos;
        }   
    }
}
