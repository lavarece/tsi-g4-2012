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

                UsuarioAdo.Crear(usuario, conexion, transaccion);

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
         public List<Usuario> ObtenerTodosLosUsuarios()
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 transaccion = UtilesBD.IniciarTransaccion(conexion);

                 List<Usuario> usuarios = new List<Usuario>();

                 usuarios = UsuarioAdo.ObtenerListado(conexion, transaccion);

                 return usuarios;
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


         public Usuario ObtenerUsuarioPorId(int idUsuario)
         {
             try
             {
                 conexion = UtilesBD.ObtenerConexion(true);

                 return UsuarioAdo.Obtener(idUsuario, conexion);
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

         /* DEPENDENCIAS */
        private IUsuarioADO _usuarioAdo;

        protected IUsuarioADO UsuarioAdo
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

        
    }
}
