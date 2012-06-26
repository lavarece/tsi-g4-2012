﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignaFwk.UI.Process.UsuarioService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsuarioService.IUsuarioService")]
    public interface IUsuarioService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/CrearNuevoUsuario", ReplyAction="http://tempuri.org/IUsuarioService/CrearNuevoUsuarioResponse")]
        int CrearNuevoUsuario(IndignaFwk.Common.Entities.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerListadoUsuarios", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerListadoUsuariosResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Usuario> ObtenerListadoUsuarios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerUsuarioPorId", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerUsuarioPorIdResponse")]
        IndignaFwk.Common.Entities.Usuario ObtenerUsuarioPorId(int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/EditarUsuario", ReplyAction="http://tempuri.org/IUsuarioService/EditarUsuarioResponse")]
        void EditarUsuario(IndignaFwk.Common.Entities.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/EliminarUsuario", ReplyAction="http://tempuri.org/IUsuarioService/EliminarUsuarioResponse")]
        void EliminarUsuario(int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerUsuariosPorIdGrupo", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerUsuariosPorIdGrupoResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerUsuarioPorEmailPassYGrupo", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerUsuarioPorEmailPassYGrupoResponse")]
        IndignaFwk.Common.Entities.Usuario ObtenerUsuarioPorEmailPassYGrupo(string email, string pass, int idGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerUsuarioPorEmailYGrupo", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerUsuarioPorEmailYGrupoResponse")]
        IndignaFwk.Common.Entities.Usuario ObtenerUsuarioPorEmailYGrupo(string email, int idGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerUsuariosAgrupandoFechaRegistro", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerUsuariosAgrupandoFechaRegistroResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerListadoNotificacionesPorUsuario", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerListadoNotificacionesPorUsuarioResponse" +
            "")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/ObtenerNotificacionPorId", ReplyAction="http://tempuri.org/IUsuarioService/ObtenerNotificacionPorIdResponse")]
        IndignaFwk.Common.Entities.Notificacion ObtenerNotificacionPorId(int idNotificacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/EditarNotificacion", ReplyAction="http://tempuri.org/IUsuarioService/EditarNotificacionResponse")]
        void EditarNotificacion(IndignaFwk.Common.Entities.Notificacion notificacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/EliminarNotificacion", ReplyAction="http://tempuri.org/IUsuarioService/EliminarNotificacionResponse")]
        void EliminarNotificacion(int idNotificacion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioServiceChannel : IndignaFwk.UI.Process.UsuarioService.IUsuarioService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioServiceClient : System.ServiceModel.ClientBase<IndignaFwk.UI.Process.UsuarioService.IUsuarioService>, IndignaFwk.UI.Process.UsuarioService.IUsuarioService {
        
        public UsuarioServiceClient() {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CrearNuevoUsuario(IndignaFwk.Common.Entities.Usuario usuario) {
            return base.Channel.CrearNuevoUsuario(usuario);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Usuario> ObtenerListadoUsuarios() {
            return base.Channel.ObtenerListadoUsuarios();
        }
        
        public IndignaFwk.Common.Entities.Usuario ObtenerUsuarioPorId(int idUsuario) {
            return base.Channel.ObtenerUsuarioPorId(idUsuario);
        }
        
        public void EditarUsuario(IndignaFwk.Common.Entities.Usuario usuario) {
            base.Channel.EditarUsuario(usuario);
        }
        
        public void EliminarUsuario(int idUsuario) {
            base.Channel.EliminarUsuario(idUsuario);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Usuario> ObtenerUsuariosPorIdGrupo(int idGrupo) {
            return base.Channel.ObtenerUsuariosPorIdGrupo(idGrupo);
        }
        
        public IndignaFwk.Common.Entities.Usuario ObtenerUsuarioPorEmailPassYGrupo(string email, string pass, int idGrupo) {
            return base.Channel.ObtenerUsuarioPorEmailPassYGrupo(email, pass, idGrupo);
        }
        
        public IndignaFwk.Common.Entities.Usuario ObtenerUsuarioPorEmailYGrupo(string email, int idGrupo) {
            return base.Channel.ObtenerUsuarioPorEmailYGrupo(email, idGrupo);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Usuario> ObtenerUsuariosAgrupandoFechaRegistro(int idGrupo) {
            return base.Channel.ObtenerUsuariosAgrupandoFechaRegistro(idGrupo);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Notificacion> ObtenerListadoNotificacionesPorUsuario(int idUsuario) {
            return base.Channel.ObtenerListadoNotificacionesPorUsuario(idUsuario);
        }
        
        public IndignaFwk.Common.Entities.Notificacion ObtenerNotificacionPorId(int idNotificacion) {
            return base.Channel.ObtenerNotificacionPorId(idNotificacion);
        }
        
        public void EditarNotificacion(IndignaFwk.Common.Entities.Notificacion notificacion) {
            base.Channel.EditarNotificacion(notificacion);
        }
        
        public void EliminarNotificacion(int idNotificacion) {
            base.Channel.EliminarNotificacion(idNotificacion);
        }
    }
}
