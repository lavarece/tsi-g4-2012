using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Business.Managers
{
    public class ConvocatoriaManager : IConvocatoriaManager
    {
        /* DATOS CONEXION Y TRANSACCION */
        private SqlConnection conexion;

        private SqlTransaction transaccion;

        /* DEPENDENCIAS */
        private IConvocatoriaADO _convocatoriaADO;

        protected IConvocatoriaADO ConvocatoriaADO
        {
            get
            {
                if (_convocatoriaADO == null)
                {
                    _convocatoriaADO = new ConvocatoriaADO();
                }

                return _convocatoriaADO;
            }
        }

        public int CrearNuevaConvocatoria(Convocatoria convocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                int ret = ConvocatoriaADO.Crear(convocatoria, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return ret;
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

        public List<Convocatoria> ObtenerListadoConvocatorias()
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ConvocatoriaADO.ObtenerListado(conexion);
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

        public Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ConvocatoriaADO.Obtener(idConvocatoria, conexion);
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

        public void EditarConvocatoria(Convocatoria convocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                ConvocatoriaADO.Editar(convocatoria, conexion, transaccion);

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

        public void EliminarConvocatoria(int idConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                ConvocatoriaADO.Eliminar(idConvocatoria, conexion, transaccion);

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
    }
}
