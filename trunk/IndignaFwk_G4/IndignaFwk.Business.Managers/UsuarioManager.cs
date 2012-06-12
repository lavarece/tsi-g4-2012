using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Business.Managers
{
    public class UsuarioManager : IUsuarioManager
    {
        /* DATOS CONEXION Y TRANSACCION */
        private SqlConnection conexion;

        private SqlTransaction transaccion;

        /* DEPENDENCIAS */
        private IUsuarioADO _usuarioAdo;
        protected IUsuarioADO UsuarioADO
        {
            get
            {
                if (_usuarioAdo == null)
                {
                    _usuarioAdo = new UsuarioADO();
                }

                return _usuarioAdo;
            }
        }

        private IGrupoADO _grupoADO;
        protected IGrupoADO GrupoADO
        {
            get
            {
                if (_grupoADO == null)
                {
                    _grupoADO = new GrupoADO();
                }

                return _grupoADO;
            }
        }

        private INotificacionADO _notificacionADO;
        protected INotificacionADO NotificacionADO
        {
            get
            {
                if (_notificacionADO == null)
                {
                    _notificacionADO = new NotificacionADO();
                }

                return _notificacionADO;
            }
        }

        /*
        * Metodo que se llama desde la capa de servicio para
        * crear un nuevo usuario. Este metodo abre y cierra las 
        * conexiones, ademas llama las AccessDataObject para
        * persistir el nuevo objeto.
        */
         public int CrearNuevoUsuario(Usuario usuario)
         {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                UsuarioADO.Crear(usuario, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return usuario.Id;
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
         public List<Usuario> ObtenerTodosLosUsuarios()
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioADO.ObtenerListado(conexion);
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

         public Usuario ObtenerUsuarioPorId(int idUsuario)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioADO.Obtener(idUsuario, conexion);
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

         public List<Usuario> ObtenerListadoUsuarios()
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioADO.ObtenerListado(conexion);
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

         public List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioADO.ObtenerUsuariosPorIdGrupo(idGrupo, conexion);

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

         public void EditarUsuario(Usuario usuario)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 transaccion = UtilesBD.IniciarTransaccion(conexion);

                 UsuarioADO.Editar(usuario, conexion, transaccion);

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

         public void EliminarUsuario(int idUsuario)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 transaccion = UtilesBD.IniciarTransaccion(conexion);

                 UsuarioADO.Eliminar(idUsuario, conexion, transaccion);

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

         public Usuario ObtenerPorEmail(string email)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioADO.ObtenerPorEmail(email, conexion);
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

         public Usuario ObtenerUsuarioPorEmailYPass(string email, string pass)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioADO.ObtenerPorEmailYPass(email, pass, conexion);
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

         public List<Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return NotificacionADO.ObtenerListadoPorUsuario(conexion, idUsuario);
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

         public Notificacion ObtenerNotificacionPorId(int idNotificacion)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return NotificacionADO.Obtener(idNotificacion, conexion);
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

         public void EditarNotificacion(Notificacion notificacion)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 transaccion = UtilesBD.IniciarTransaccion(conexion);

                 NotificacionADO.Editar(notificacion, conexion, transaccion);

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
        
         public void EliminarNotificacion(int idNotificacion)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 transaccion = UtilesBD.IniciarTransaccion(conexion);

                 NotificacionADO.Eliminar(idNotificacion, conexion, transaccion);

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
