using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IndignaFwk.Common.Entities;

namespace IndignaFwk.Business.Services
{
    [ServiceContract]
    public interface IUsuarioService
    {
        [OperationContract]
        int CrearNuevoUsuario(Usuario usuario);

        [OperationContract]
        List<Usuario> ObtenerListadoUsuarios();

        [OperationContract]
        Usuario ObtenerUsuarioPorId(int idUsuario);

        [OperationContract]
        void EditarUsuario(Usuario usuario);

        [OperationContract]
        void EliminarUsuario(int idUsuario);

        [OperationContract]
        List<Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo);

        [OperationContract]
        Usuario ObtenerUsuarioPorEmailPassYGrupo(string email, string pass, int idGrupo);

        [OperationContract]
        Usuario ObtenerUsuarioPorEmailYGrupo(string email, int idGrupo);

        [OperationContract]
        List<Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo);

        // Operaciones con notificaciones
        [OperationContract]
        List<Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario);

        [OperationContract]
        Notificacion ObtenerNotificacionPorId(int idNotificacion);

        [OperationContract]
        void EditarNotificacion(Notificacion notificacion);

        [OperationContract]
        void EliminarNotificacion(int idNotificacion);


    }
}
