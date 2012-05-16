﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Business.Entities;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Business.Managers
{
    public class UsuarioManager : IUsuarioManager
    {
        public Int32 CrearUsuario(Entities.Usuario usuario)
        {
            throw new NotImplementedException();
        }
        
        
        /* DEPENDENCIAS */
        private UsuarioADO _UsuarioAdo;

        /* DATOS CONEXION Y TRANSACCION */
        private SqlConnection conexion;

        private SqlTransaction transaccion;

        /*
            * Metodo que se llama desde la capa de servicio para
            * crear un nuevo usuario. Este metodo abre y cierra las 
            * conexiones, ademas llama las AccessDataObject para
            * persistir el nuevo objeto.
        */
         public Int32 CrearNuevoUsuario(Usuario usuario)
         {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                UsuarioAdo.Crear(usuario, conexion);

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
    

            protected UsuarioADO UsuarioAdo
            {
                get
                {
                    if (_UsuarioAdo == null)
                    {
                        _UsuarioAdo = new UsuarioADO();
                    }

                    return _UsuarioAdo;
                }
            }

        
    }
}
