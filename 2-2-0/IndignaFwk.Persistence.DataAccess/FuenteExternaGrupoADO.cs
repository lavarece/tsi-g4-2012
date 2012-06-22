using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Common.Entities;
using System.Data.SqlClient;
using System.Data;
using IndignaFwk.Common.Util;

namespace IndignaFwk.Persistence.DataAccess
{
    public class FuenteExternaGrupoADO : IFuenteExternaGrupoADO
    {
        private SqlCommand command;    

        public void Crear(FuenteExternaGrupo fuenteExternaGrupo, SqlConnection conexion, SqlTransaction transaccion)
        {
            command = conexion.CreateCommand();

            command.Transaction = transaccion;

            command.Connection = conexion;

            command.CommandText = " insert into FuenteExternaSitio(FuenteExterna, FK_Id_Sitio, QueryString, CantidadResultados) " +
                                  " values(@fuenteExterna, @idSitio, @queryString, @cantidadResultados); " +
                                  " select @idGen = SCOPE_IDENTITY() FROM FuenteExternaGrupo; ";

            UtilesBD.SetParameter(command, "fuenteExterna", fuenteExternaGrupo.FuenteExterna);
            UtilesBD.SetParameter(command, "idSitio", fuenteExternaGrupo.Grupo.Id);
            UtilesBD.SetParameter(command, "queryString", fuenteExternaGrupo.QueryString);
            UtilesBD.SetParameter(command, "cantidadResultados", fuenteExternaGrupo.CantidadResultados);
            
            // indico que la query tiene un parámetro de salida thisId de tipo int
            command.Parameters.Add("@idGen", SqlDbType.Int).Direction = ParameterDirection.Output;

            command.ExecuteScalar();

            // este es el identificador generado
            fuenteExternaGrupo.Id = (int)command.Parameters["@idGen"].Value;
        }

        public List<FuenteExternaGrupo> ObtenerListadoPorGrupo(int idGrupo, SqlConnection conexion)
        {
            SqlDataReader reader = null;

            List<FuenteExternaGrupo> listaFuentes = new List<FuenteExternaGrupo>();

            try
            {
                command = conexion.CreateCommand();

                command.Connection = conexion;

                command.CommandText = "SELECT * FROM FuenteExternaSitio where FK_Id_Sitio = @idSitio ";

                UtilesBD.SetParameter(command, "idSitio", idGrupo);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FuenteExternaGrupo fuenteExternaGrupo = new FuenteExternaGrupo();

                    fuenteExternaGrupo.Id = UtilesBD.GetIntFromReader("Id", reader);

                    fuenteExternaGrupo.FuenteExterna = UtilesBD.GetStringFromReader("FuenteExterna", reader);

                    fuenteExternaGrupo.QueryString = UtilesBD.GetStringFromReader("QueryString", reader);

                    fuenteExternaGrupo.CantidadResultados = UtilesBD.GetIntFromReader("CantidadResultados", reader);

                    fuenteExternaGrupo.Grupo = new Grupo { Id = UtilesBD.GetIntFromReader("FK_Id_Sitio", reader) };

                    listaFuentes.Add(fuenteExternaGrupo);
                }

                return listaFuentes;
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
