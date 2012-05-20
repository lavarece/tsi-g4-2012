using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace IndignaFwk.Common.Util
{
    public class UtilesBD
    {
        private const String STR_CONEXION_BD = "Data Source=Chory-pc\\SQLEXPRESS;Initial Catalog=IndignadoFDb;Persist Security Info=True;User ID=indigna_usr;Password=indigna_usr";

        public static SqlConnection ObtenerConexion(bool abrir)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(STR_CONEXION_BD);

                if(abrir)
                {
                    conexion.Open();
                }

                return conexion;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);

                return null;
            }
        }

        public static SqlTransaction IniciarTransaccion(SqlConnection conexion)
        {
            if(conexion != null)
            {
                return conexion.BeginTransaction();
            }

            return null;
        }

        public static void CommitTransaccion(SqlTransaction transaccion)
        {
            if(transaccion != null)
            {
                transaccion.Commit();
            }
        }

        public static void RollbackTransaccion(SqlTransaction transaccion)
        {
            if(transaccion != null)
            {
                transaccion.Rollback();
            }
        }

        public static void CerrarConexion(SqlConnection conexion)
        {
            if(conexion != null)
            {
                conexion.Close();

                conexion.Dispose();
            }
        }
    }
}
