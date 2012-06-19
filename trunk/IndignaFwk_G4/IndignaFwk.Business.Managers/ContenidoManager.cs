using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;

namespace IndignaFwk.Business.Managers
{
    public class ContenidoManager : IContenidoManager
    {
        /* DATOS CONEXION Y TRANSACCION */
        private SqlConnection conexion;

        private SqlTransaction transaccion;

        /* DEPENDENCIAS */
        private IContenidoADO _contenidoADO;
        protected IContenidoADO ContenidoADO
        {
            get
            {
                if (_contenidoADO == null)
                {
                    _contenidoADO = new ContenidoADO();
                }

                return _contenidoADO;
            }
        }

        private IMarcaContenidoADO _marcaContenidoADO;
        protected IMarcaContenidoADO MarcaContenidoADO
        {
            get
            {
                if (_marcaContenidoADO == null)
                {
                    _marcaContenidoADO = new MarcaContenidoADO();
                }

                return _marcaContenidoADO;
            }
        }

        public int CrearNuevoContenido(Contenido contenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                ContenidoADO.Crear(contenido, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return contenido.Id;
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

        public Contenido ObtenerContenidoPorId(int idContenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.Obtener(idContenido, conexion);
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

        public List<Contenido> ObtenerListadoContenidosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerListadoPorGrupoYVisibilidad(conexion, idGrupo, visibilidadContenido);
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

        public List<Contenido> ObtenerXContenidosMasRankeadosPorGrupoYVisibilidad(int idGrupo, string visibilidadContenido, int x)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerXPorGrupoYVisibilidad(conexion, idGrupo, visibilidadContenido, x);
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

        public MarcaContenido ObtenerMarcaContenidoPorUsuarioYContenido(int idUsuario, int idContenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return MarcaContenidoADO.ObtenerPorUsuarioYContenido(idUsuario, idContenido, conexion);
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

        public int CrearNuevaMarcaContenido(MarcaContenido marcaContenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                MarcaContenidoADO.Crear(marcaContenido, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return marcaContenido.Id;
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

        public void EditarMarcaContenido(MarcaContenido marcaContenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                MarcaContenidoADO.Editar(marcaContenido, conexion, transaccion);

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
