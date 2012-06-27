using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Business.Agents;
using IndignaFwk.Common.Enumeration;

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

        // AGENTS
        private YouTubeAgent _youTubeAgent;
        protected YouTubeAgent YouTubeAgent
        {
            get
            {
                if (_youTubeAgent == null)
                {
                    _youTubeAgent = new YouTubeAgent();
                }

                return _youTubeAgent;
            }
        }

        private WikipediaAgent _wikipediaAgent;
        protected WikipediaAgent WikipediaAgent
        {
            get
            {
                if (_wikipediaAgent == null)
                {
                    _wikipediaAgent = new WikipediaAgent();
                }

                return _wikipediaAgent;
            }
        }

        private InG4Agent _inG4Agent;
        protected InG4Agent InG4Agent
        {
            get
            {
                if (_inG4Agent == null)
                {
                    _inG4Agent = new InG4Agent();
                }

                return _inG4Agent;
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

                List<Contenido> listaContenidos = new List<Contenido>();

                // Agrego los contenidos locales
                listaContenidos.AddRange(ContenidoADO.ObtenerXPorGrupoYVisibilidad(conexion, idGrupo, visibilidadContenido, x));

                // Verifico las fuentes externas del grupo y cargo las que correspondan
                Grupo grupo = GrupoADO.Obtener(idGrupo, conexion);

                if (grupo.FuentesExternas != null)
                {
                    foreach (FuenteExternaGrupo fuenteExternaGrupo in grupo.FuentesExternas)
                    {
                        if (fuenteExternaGrupo.FuenteExterna.Equals(FuenteExternaEnum.YOU_TUBE.Valor))
                        {                            
                            listaContenidos.AddRange(YouTubeAgent.ObtenerContenidosExternosDeGrupo(fuenteExternaGrupo, grupo));                            
                        }
                        else if (fuenteExternaGrupo.FuenteExterna.Equals(FuenteExternaEnum.WIKIPEDIA.Valor))
                        {                            
                            listaContenidos.AddRange(WikipediaAgent.ObtenerContenidosExternosDeGrupo(fuenteExternaGrupo, grupo));                            
                        }
                    }
                }

                // Agrego los contenidos de integracion con otros grupos
                if (UtilesGenerales.INTEGRAR_CON_G4)
                {
                    listaContenidos.AddRange(InG4Agent.ObtenerContenidosIntegracionPorTematica(grupo.Tematica.Id));
                }

                return listaContenidos;                
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

        public Contenido ObtenerContenidoConMarcas(int id)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerContenidoConMarcas(id, conexion);
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

        public List<Contenido> ObtenerListadoPorGrupo(int idGrupo)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerListadoPorGrupo(conexion, idGrupo);
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

        public void EliminarListaContenido(int idContenido)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                transaccion = UtilesBD.IniciarTransaccion(conexion);

                ContenidoADO.Eliminar(idContenido, conexion, transaccion);
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

        
        public List<Contenido> ObtenerListadoPorGrupoNoEliminado(int idGrupo)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerListadoPorGrupoNoEliminado(conexion, idGrupo);
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
        

        public List<Contenido> ObtenerContenidoEliminadoPorUsuario(int idUsuario)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerContenidoEliminadoPorUsuario(idUsuario, conexion);
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

        public List<Contenido> ObtenerListadoPorTematica(int idTematica)
        {
            try
            {
                conexion = UtilesBD.ObtenerConexion(true);

                return ContenidoADO.ObtenerListadoPorTematica(idTematica, conexion);
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
