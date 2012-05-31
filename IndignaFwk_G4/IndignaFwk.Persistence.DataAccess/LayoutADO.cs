using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data;
using IndignaFwk.Common.Util;
using System.Data.SqlClient;

namespace IndignaFwk.Persistence.DataAccess
{
    public class LayoutADO : ILayoutADO
    {
        private SqlCommand command;    

        public Layout Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Layout where Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Layout layout = new Layout();

                    layout.Id = UtilesBD.GetIntFromReader("id", reader);

                    layout.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    layout.NombreLayout = UtilesBD.GetStringFromReader("NombreLayout", reader);

                    return layout;
                }

                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        public List<Layout> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Layout> listaLayouts = new List<Layout>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Layout";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Layout layout = new Layout();

                    layout.Id = UtilesBD.GetIntFromReader("id", reader);

                    layout.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    layout.NombreLayout = UtilesBD.GetStringFromReader("NombreLayout", reader);

                    listaLayouts.Add(layout);
                }

                return listaLayouts;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
