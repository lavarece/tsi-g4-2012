﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Business.Managers;


namespace IndignaFwk.Business.Services
{
    public class SistemaService : ISistemaService
    {
        private ISistemaManager sistemaManager = ManagerFactory.Instance.SistemaManager;    

        public List<VariableSistema> ObtenerListadoVariables()
        {
            return sistemaManager.ObtenerTodosLasVariables();
        }

        public VariableSistema ObtenerVariablePorId(int idVariable)
        {
            return sistemaManager.ObtenerVariablePorId(idVariable);
        }

        public VariableSistema ObtenerVariablePorNombre(string nombre)
        {
            return sistemaManager.ObtenerVariablePorNombre(nombre);
        }

        public void EditarVariableSistema(VariableSistema variableSistema)
        {
            sistemaManager.EditarVariable(variableSistema);
        }

    }
}
