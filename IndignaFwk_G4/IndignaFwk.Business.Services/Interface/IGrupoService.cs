﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract]
    public interface IGrupoService
    {    
        [OperationContract]
        int CrearNuevoGrupo(Grupo grupo);

        [OperationContract]
        List<Grupo> ObtenerListadoGrupos();

        [OperationContract]
        Grupo ObtenerGrupoPorId(int idGrupo);

        [OperationContract]
        Grupo ObtenerGrupoPorUrl(string url);

        [OperationContract]
        void EditarGrupo(Grupo grupo);

        [OperationContract]
        void EliminarGrupo(int idGrupo);
    }
}
