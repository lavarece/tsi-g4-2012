using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Util;
using IndignaFwk.Common.Filter;

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

        private IUsuarioADO _usuarioADO;
        protected IUsuarioADO UsuarioADO
        {
            get
            {
                if (_usuarioADO == null)
                {
                    _usuarioADO = new UsuarioADO();
                }

                return _usuarioADO;
            }
        }

        private IAsistenciaConvocatoriaADO _asistenciaConvocatoriaADO;
        protected IAsistenciaConvocatoriaADO AsistenciaConvocatoriaADO
        {
            get
            {
                if (_asistenciaConvocatoriaADO == null)
                {
                    _asistenciaConvocatoriaADO = new AsistenciaConvocatoriaADO();
                }

                return _asistenciaConvocatoriaADO;
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

        private INotificacionADO _notifiacionADO;
        protected INotificacionADO NotificacionADO
        {
            get
            {
                if (_notifiacionADO == null)
                {
                    _notifiacionADO = new NotificacionADO();
                }

                return _notifiacionADO;
            }
        }

        /* OPERACIONES */
        public int CrearNuevaConvocatoria(Convocatoria convocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                ConvocatoriaADO.Crear(convocatoria, conexion, transaccion);

                // Se creara una notificacion a todos los usuarios que se encuentren a menos de 50mk de la convocatoria
                List<Usuario> usuariosGrupo = UsuarioADO.ObtenerUsuariosPorIdGrupo(convocatoria.Grupo.Id, conexion, transaccion);

                foreach (Usuario usuario in usuariosGrupo)
                {
                    double distance = UtilesGenerales.CalcularDistanciaCoordenadas(convocatoria.GetLatitud(),
                                                                                   convocatoria.GetLongitud(),
                                                                                   usuario.GetLatitud(),
                                                                                   usuario.GetLongitud());

                    // Si distancia en KM entre usuario y convocatoria menor a 50 notifico
                    if (distance < 50D)
                    {
                        Notificacion notificacion = new Notificacion();

                        notificacion.Contenido = "Se ha creado la convocatoria '" + convocatoria.Titulo + "' a menos de 50Km de su posición.";

                        notificacion.Visto = false;

                        notificacion.Convocatoria = convocatoria;

                        notificacion.Usuario = usuario;

                        notificacion.FechaCreacion = DateTime.Now;

                        NotificacionADO.Crear(notificacion, conexion, transaccion);
                    }
                }

                UtilesBD.CommitTransaccion(transaccion);

                return convocatoria.Id;
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
                throw ex;
            }
            finally
            {
                UtilesBD.CerrarConexion(conexion);
            }
        }

        public List<Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ConvocatoriaADO.ObtenerListadoPorGrupo(conexion, idGrupo);
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

        public Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ConvocatoriaADO.Obtener(idConvocatoria, conexion);
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

        public int CrearNuevaAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                AsistenciaConvocatoriaADO.Crear(asistenciaConvocatoria, conexion, transaccion);

                UtilesBD.CommitTransaccion(transaccion);

                return asistenciaConvocatoria.Id;
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

        public List<AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return AsistenciaConvocatoriaADO.ObtenerListadoPorIdUsuario(idUsuario, conexion);
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

        public List<Convocatoria> ObtenerConvocatoriasPorFiltro(FiltroBusqueda filtroBusqueda)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ConvocatoriaADO.ObtenerConvocatoriasPorFiltro(filtroBusqueda, conexion);
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

        public AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return AsistenciaConvocatoriaADO.ObtenerPorUsuarioYConvocatoria(idUsuario, idConvocatoria, conexion);
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

        public void EditarAsistenciaConvocatoria(AsistenciaConvocatoria asistenciaConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                AsistenciaConvocatoriaADO.Editar(asistenciaConvocatoria, conexion, transaccion);

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

        public void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                AsistenciaConvocatoriaADO.Eliminar(idAsistenciaConvocatoria, conexion, transaccion);

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
    }
}
