﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace IndignaFwk.Common.Entities
{
    [DataContract]
    [Serializable]
    public class Convocatoria
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Quorum { get; set; }

        [DataMember]
        public string Coordenadas { get; set; }

        [DataMember]
        public string LogoUrl { get; set; }

        [DataMember]
        public DateTime? FechaInicio { get; set; }

        [DataMember]
        public DateTime? FechaFin { get; set; }

        [DataMember]
        public Grupo Grupo { get; set; }

        [DataMember]
        public Usuario UsuarioCreacion { get; set; }

        [DataMember]
        public int CantidadAsistencias { get; set; }

        // Atributo utilizado por la presentacion
        public Boolean ExisteAsistenciaUsuario { get; set; }

        // Funciones auxiliares
        public string GetLatitud()
        {
            string cleanCoord = Coordenadas.Replace("(", "").Replace(")", "");

            string[] array = cleanCoord.Split(',');

            return array[0];
        }

        public string GetLongitud()
        {
            string cleanCoord = Coordenadas.Replace("(", "").Replace(")", "");

            string[] array = cleanCoord.Split(',');

            return array[1];
        }
    }
}
