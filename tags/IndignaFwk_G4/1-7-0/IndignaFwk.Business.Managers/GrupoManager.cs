﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Common.Util;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Managers
{
   public class GrupoManager : IGrupoManager
   {
       /* DATOS CONEXION Y TRANSACCION */
       private SqlConnection conexion;

       private SqlTransaction transaccion;

       /* DEPENDENCIAS */
       private IGrupoADO _grupoAdo;
       protected IGrupoADO GrupoADO
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

       private IImagenADO _imagenADO;
       protected IImagenADO ImagenADO
       {
           get
           {
               if(_imagenADO == null)
               {
                   _imagenADO = new ImagenADO();
               }
               
               return _imagenADO;
           }
       }
       
       private ITematicaADO _tematicaADO;
       protected ITematicaADO TematicaADO
       {
           get
           {
               if(_tematicaADO == null)
               {
                   _tematicaADO = new TematicaADO();
               }

               return _tematicaADO;
           }
       }

       private ILayoutADO _layoutADO;
       protected ILayoutADO LayoutADO
       {
           get
           {
               if(_layoutADO == null)
               {
                   _layoutADO = new LayoutADO();
               }

               return _layoutADO;
           }
       }
       

       /*
        * Metodo que se llama desde la capa de servicio para
        * crear un nuevo sitio. Este metodo abre y cierra las 
        * conexiones, ademas llama las AccessDataObject para
        * persistir el nuevo objeto.
       */
       public int CrearNuevoGrupo(Grupo grupo)
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);
               
               transaccion = UtilesBD.IniciarTransaccion(conexion); 

               int ret = GrupoADO.Crear(grupo, conexion, transaccion);

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

       /*
        * Método que obtiene la lista de sitios de 
        * la base de datos.
        */
       public List<Grupo> ObtenerListadoGrupos()
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);

               List<Grupo> listadoGrupos = GrupoADO.ObtenerListado(conexion);

               foreach (Grupo grupo in listadoGrupos)
               {
                   if (grupo.Imagen != null && grupo.Imagen.Id != 0)
                   {
                       grupo.Imagen = ImagenADO.Obtener(grupo.Imagen.Id, conexion);
                   }

                   if (grupo.Layout != null && grupo.Layout.Id != 0)
                   {
                       grupo.Layout = LayoutADO.Obtener(grupo.Layout.Id, conexion);
                   }

                   if (grupo.Tematica != null && grupo.Tematica.Id != 0)
                   {
                       grupo.Tematica = TematicaADO.Obtener(grupo.Tematica.Id, conexion);
                   }
               }

               return listadoGrupos;
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
       public Grupo ObtenerGrupoPorId(int idGrupo)
       {
           try
           {
                conexion = UtilesBD.ObtenerConexion(true);

                Grupo grupo = GrupoADO.Obtener(idGrupo, conexion);

                if (grupo.Imagen != null && grupo.Imagen.Id != 0)
                {
                    grupo.Imagen = ImagenADO.Obtener(grupo.Imagen.Id, conexion);
                }

                if (grupo.Layout != null && grupo.Layout.Id != 0)
                {
                    grupo.Layout = LayoutADO.Obtener(grupo.Layout.Id, conexion);
                }

                if (grupo.Tematica != null && grupo.Tematica.Id != 0)
                {
                    grupo.Tematica = TematicaADO.Obtener(grupo.Tematica.Id, conexion);
                }
                
                return grupo; 
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
        * Obtiene un grupo por su Url
        */
       public Grupo ObtenerGrupoPorUrl(string url)
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);

               Grupo grupo = GrupoADO.ObtenerPorUrl(url, conexion);

               if (grupo.Imagen != null && grupo.Imagen.Id != 0)
               {
                   grupo.Imagen = ImagenADO.Obtener(grupo.Imagen.Id, conexion);
               }

               if (grupo.Layout != null && grupo.Layout.Id != 0)
               {
                   grupo.Layout = LayoutADO.Obtener(grupo.Layout.Id, conexion);
               }

               if (grupo.Tematica != null && grupo.Tematica.Id != 0)
               {
                   grupo.Tematica = TematicaADO.Obtener(grupo.Tematica.Id, conexion);
               }

               return grupo;
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
        * Método que guarda un sitio pasado
        * como parámetro
        */
       public void EditarGrupo(Grupo grupo)
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);

               transaccion = UtilesBD.IniciarTransaccion(conexion);

               GrupoADO.Editar(grupo, conexion, transaccion);

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
       
       /*
        * Método que elimina un sitio dado
        * por su identificador.
        */
       //to do
       public void EliminarGrupo(int idGrupo)
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);

               transaccion = UtilesBD.IniciarTransaccion(conexion);

               GrupoADO.Eliminar(idGrupo, conexion, transaccion);

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
