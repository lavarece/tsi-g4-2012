using System;
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

               GrupoAdo.Crear(grupo, conexion, transaccion);

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

               List<Grupo> grupos = new List<Grupo>();

               grupos = GrupoAdo.ObtenerListado(conexion);

               return grupos;
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

               return GrupoAdo.Obtener(idGrupo, conexion);
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

               return GrupoAdo.ObtenerPorUrl(url, conexion);
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

               GrupoAdo.Editar(grupo, conexion, transaccion);
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
        * Método que elimina una o varias imágenes
        * pasadas por parámetro en una lista.
        */
       //to do
       public void EliminarImagenes(List<Imagen> imagenes)
       {
           try
           {
               
              
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

               GrupoAdo.Eliminar(idGrupo, conexion, transaccion);
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
       private IGrupoADO _grupoAdo;

       protected IGrupoADO GrupoAdo
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

   }
}
