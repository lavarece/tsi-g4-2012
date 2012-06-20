using System;
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

            uint iID = service.GetTopCandidateIDFromKeyword("Microsoft", "English");

            DataSet ds = service.GetThesaurusDS(0, iID, 0, "English");

            return null;
        }
    }
}
