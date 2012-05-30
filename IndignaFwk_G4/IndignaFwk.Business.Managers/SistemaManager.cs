using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;

namespace IndignaFwk.Business.Managers
{
    public class SistemaManager : ISistemaManager
    {

        /* DATOS CONEXION Y TRANSACCION */
        private SqlConnection conexion;

        private SqlTransaction transaccion;

        /* DEPENDENCIAS */
        private IVariableSistemaADO _variableAdo;

        protected IVariableSistemaADO VariableADO
        {
            get
            {
                if (_variableAdo == null)
                {
                    _variableAdo = new VariableSistemaADO();
                }

                return _variableAdo;
            }
        }

        /*
        * Metodo que se llama desde la capa de servicio para
        * crear un nuevo usuario. Este metodo abre y cierra las 
        * conexiones, ademas llama las AccessDataObject para
        * persistir el nuevo objeto.
        */
        public int CrearNuevaVariable(VariableSistema variable)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                int id = VariableADO.Crear(variable, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return id;
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
        
        public VariableSistema ObtenerVariablePorId(int idVariable)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return VariableADO.Obtener(idVariable, conexion);
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

        public VariableSistema ObtenerVariablePorNombre(string nombreVariable)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return VariableADO.ObtenerPorNombre(nombreVariable, conexion);
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

        public void EditarVariable(VariableSistema variableSistema)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                VariableADO.Editar(variableSistema, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);
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

        public List<VariableSistema> ObtenerTodosLasVariables()
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return VariableADO.ObtenerListado(conexion); ;
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

    }
}
