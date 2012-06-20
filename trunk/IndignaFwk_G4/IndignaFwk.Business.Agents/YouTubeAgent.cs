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
        private static readonly string DEVELOPER_KEY = "AI39si4YVTBLXrlE15S5N_t3Su_hQBXxkRWz3HmsgcQlJKRj3RRIVtrOU8-5t3MzOgIjcvDvPf4hHE7SyQpQ5n-Rqc6aSpNV7w";
        
        public List<Contenido> ObtenerContenidosDeGrupo(Grupo grupo)
        {
            // Youtube request
            YouTubeRequestSettings settings = new YouTubeRequestSettings("TSI_2012", DEVELOPER_KEY);
            YouTubeRequest request = new YouTubeRequest(settings);

            // Youtube query
            YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
            query.OrderBy = "viewCount";
            query.Query = "Reggaton";
            query.SafeSearch = YouTubeQuery.SafeSearchValues.None;

            Feed<Video> videoFeed = request.Get<Video>(query);

            // Genero la lista de contenidos
            List<Contenido> listaContenidos = new List<Contenido>();

            int count = 0;
            foreach (Video video in videoFeed.Entries)
            {
                // Permito agregar tantos contenidos como indique el grupo
                if (count == 3)
                    break;

                Contenido contenido = new Contenido();

                contenido.Titulo = video.Title;

                contenido.Comentario = video.Description;

                contenido.TipoContenido = TipoContenidoEnum.VIDEO_YOU_TUBE.Valor;

                contenido.Grupo = grupo;

                contenido.Url = "http://www.youtube.com/embed/" + video.VideoId;

                contenido.Externo = true;

                contenido.FuenteExterna = FuenteExternaEnum.YOU_TUBE.Valor;

                listaContenidos.Add(contenido);

                count++;
            }

            return listaContenidos;
        }   
    }
}
