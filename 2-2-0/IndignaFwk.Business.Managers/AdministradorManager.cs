using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IndignaFwk.Common.Entities;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Business.Managers
{
    public class AdministradorManager : IAdministradorManager
    {
        /* DATOS CONEXION Y TRANSACCION */
        private SqlConnection conexion;

        private SqlTransaction transaccion;

        /* DEPENDENCIAS */
        private IAdministradoADO _administradorADO;

        protected IAdministradoADO AdministradorADO
        {
            get
            {
                if (_administradorADO == null)
                {
                    _administradorADO = new AdministradorADO();
                }

                return _administradorADO;
            }
        }

        public int CrearNuevoAdministrador(Administrador administrador)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                AdministradorADO.Crear(administrador, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return administrador.Id;
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

        public List<Administrador> ObtenerListadoAdministradores()
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return AdministradorADO.ObtenerListado(conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UtilesBD.CerrarConexion(conexion);
            }
        }

        public Administrador ObtenerAdministradorPorId(int idAdministrador)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return AdministradorADO.Obtener(idAdministrador, conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                UtilesBD.CerrarConexion(conexion);
            }
        }

        public void EditarAdministrador(Administrador administrador)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                AdministradorADO.Editar(administrador, conexion, transaccion);

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

        public void EliminarAdministrador(int idAdministrador)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                AdministradorADO.Eliminar(idAdministrador, conexion, transaccion);

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

        public Administrador ObtenerAdministradorPorEmailYPass(string email, string pass)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return AdministradorADO.ObtenerPorEmailYPass(email, pass, conexion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                UtilesBD.CerrarConexion(conexion);
            }
        }
    }
}
