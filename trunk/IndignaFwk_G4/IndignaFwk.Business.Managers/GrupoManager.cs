﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Business.Entities;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Business.Managers
{
   public class GrupoManager : IGrupoManager
   {
       /* DEPENDENCIAS */
       private GrupoADO _grupoAdo;

       /* DATOS CONEXION Y TRANSACCION */
       private SqlConnection conexion;

       private SqlTransaction transaccion;

       /*
        * Metodo que se llama desde la capa de servicio para
        * crear un nuevo sitio. Este metodo abre y cierra las 
        * conexiones, ademas llama las AccessDataObject para
        * persistir el nuevo objeto.
       */
       public Int32 CrearNuevoGrupo(Grupo grupo)
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);
               
               transaccion = UtilesBD.IniciarTransaccion(conexion); 

               GrupoAdo.Crear(grupo, conexion);

               UtilesBD.CommitTransaccion(transaccion);

               return 0;
           }
           catch (Exception ex)
           {
               UtilesBD.RollbackTransaccion(transaccion);

               throw ex;
           }
           finally
           {
               UtilesBD.CerrarConexion(conexion);
           }
       } 

       /*
        * Método que obtiene la lista de sitios de 
        * la base de datos.
        */
       public List<Grupo> ObtenerTodosLosGrupos()
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);

               transaccion = UtilesBD.IniciarTransaccion(conexion);

               List<Grupo> sitios = new List<Grupo>();

               sitios = GrupoAdo.ObtenerListado(conexion);

               return sitios;
           }
           catch (Exception ex)
           {
               UtilesBD.RollbackTransaccion(transaccion);

               throw ex;
           }
           finally 
           {
               UtilesBD.CerrarConexion(conexion);
           }

       }

       /*
        * Método que obtiene un sitio dado
        * por su identificador
        */
       public Grupo ObtenerGrupoPorId(Int32 idGrupo)
       {
            Grupo sitio = new Grupo();

            return sitio;
       }

       /*
        * Método que guarda un sitio pasado
        * como parámetro
        */
       public void GuardarGrupo(Grupo grupo)
       {
        
       }
       
       /*
        * Método que elimina una o varias imágenes
        * pasadas por parámetro en una lista.
        */
       public void EliminarImagenes(List<long> imagenes)
       {
       
       }


       /*
        * Método que elimina un sitio dado
        * por su identificador.
        */
       public void EliminarGrupo(Int32 idGrupo)
       { 
       
       }

       protected GrupoADO GrupoAdo
       {
           get 
           {    
               if (_grupoAdo == null)
               {
                    _grupoAdo = new GrupoADO();
               }
           
               return _grupoAdo;
           }           
       }

   }
}