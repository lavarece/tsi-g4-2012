using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Business.Entities;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Business.Managers
{
   public class GrupoManager : IGrupoManager
   {
       /* DEPENDENCIAS */
       private GrupoADO grupoAdo;

       /* DATOS CONEXION Y TRANSACCION */
       private SqlConnection conexion;

       private SqlTransaction transaccion;

       /*
        * Metodo que se llama desde la capa de servicio para
        * crear un nuevo sitio. Este metodo abre y cierra las 
        * conexiones, ademas llama las AccessDataObject para
        * persistir el nuevo objeto.
       */
       public void CrearNuevoSitio(Sitio grupo)
       {
           try
           {
               conexion = UtilesBD.ObtenerConexion(true);
               
               transaccion = UtilesBD.IniciarTransaccion(conexion); 

               GetGrupoAdo().Crear(grupo, conexion);

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
        * Método que obtiene la lista de sitios de 
        * la base de datos.
        */
       public List<Sitio> ObtenerTodosLosSitios()
       {    
            List<Sitio> sitios = new List<Sitio>();

            return sitios;
       }

       /*
        * Método que obtiene un sitio dado
        * por su identificador
        */
       public Sitio ObtenerSitioPorId(long id)
       {
            Sitio sitio = new Sitio();

            return sitio;
       }

       /*
        * Método que guarda un sitio pasado
        * como parámetro
        */
       public void GuardarSitio(Sitio grupo)
       {
        
       }
       
       /*
        * Método que elimina una o varias imágenes
        * pasadas por parámetro en una lista.
        */
       public void EliminarImagenes(List<long> imagenes)
       {
       
       }


       /*
        * Método que elimina un sitio dado
        * por su identificador.
        */
       public void EliminarSitio(long idSitio)
       { 
       
       }

       public GrupoADO GetGrupoAdo()
       {
           if (grupoAdo == null)
           { 
                grupoAdo = new GrupoADO();
           }
           return grupoAdo;
       }

   }
}
