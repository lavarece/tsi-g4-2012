using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using IndignaFwk.Persistence.DataAccess;
using IndignaFwk.Business.Entities;
using System.Windows.Forms;

namespace IndignaFwk.Business.Managers
{
   public class GrupoManager : IGrupoManager
   {
       private static GrupoADO grupoAdo;
       private SqlConnection conexion;

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
               conexion = GetConection();
               conexion.Open();
               grupoAdo = ObtenerGrupoADO();
               grupoAdo.Crear(grupo, conexion);
           }

           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

           finally
           {
               if (conexion != null)
               {
                   conexion.Close();
                   conexion.Dispose();
               }
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

       public SqlConnection GetConection()
       {
           SqlConnection conection = new SqlConnection("Data Source=JuanMa\SQLEXPRESS;Initial Catalog=IndignadoFDb;Persist Security Info=True;User ID=jmg216;Password=enano20");
           return conection;
       }

       public GrupoADO ObtenerGrupoADO()
       {
           if (grupoAdo == null)
           { 
                grupoAdo = new GrupoADO();
           }
           return grupoAdo;
       }

   }
}
