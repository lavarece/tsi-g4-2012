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
    public class TematicaADO : ITematicaADO
    {
        private SqlCommand command;    

        public Tematica Obtener(int id, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "select * from Tematica where Id = @id";

                UtilesBD.SetParameter(command, "id", id);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Tematica tematica = new Tematica();

                    tematica.Id = UtilesBD.GetIntFromReader("id", reader);

                    tematica.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    tematica.NombreCSS = UtilesBD.GetStringFromReader("NombreCSS", reader);

                    return tematica;
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

        public List<Tematica> ObtenerListado(SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<Tematica> listaTematicas = new List<Tematica>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM Tematica";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tematica tematica = new Tematica();

                    tematica.Id = UtilesBD.GetIntFromReader("id", reader);

                    tematica.Nombre = UtilesBD.GetStringFromReader("Nombre", reader);

                    tematica.NombreCSS = UtilesBD.GetStringFromReader("NombreCSS", reader);

                    listaTematicas.Add(tematica);
                }

                return listaTematicas;
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
