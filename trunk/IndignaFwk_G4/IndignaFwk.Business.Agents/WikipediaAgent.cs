﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Enumeration;
using IndignaFwk.Business.Agents.WikipediaService;
using System.Data;

namespace IndignaFwk.Business.Agents
{
    public class WikipediaAgent
    {
        public List<Contenido> ObtenerContenidosDeGrupo(Grupo grupo)
        {
            WikipediaService.ServiceSoapClient service = new WikipediaService.ServiceSoapClient();

            uint iID = service.GetTopCandidateIDFromKeyword("Music", "English");

            DataSet source = service.GetThesaurusDS(0, iID, 0, "English");

            // Creo la lista de contenidos
            List<Contenido> listaContenidos = new List<Contenido>();

            foreach (DataTable table in source.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    string tagWiki = row.ItemArray[3].ToString();

                    Contenido contenido = new Contenido();

                    contenido.Titulo = tagWiki;

                    contenido.Comentario = "Contenido wikipedia";

                    contenido.TipoContenido = TipoContenidoEnum.LINK.Valor;

                    contenido.Grupo = grupo;

                    contenido.Url = "http://en.wikipedia.org/wiki/" + tagWiki;

                    contenido.Externo = true;

                    contenido.FuenteExterna = FuenteExternaEnum.WIKIPEDIA.Valor;

                    listaContenidos.Add(contenido);
                }
            }

            return listaContenidos;
        }
    }
}
