﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignaFwk.UI.Process.ConvocatoriaService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ConvocatoriaService.IConvocatoriaService")]
    public interface IConvocatoriaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/CrearNuevaConvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/CrearNuevaConvocatoriaResponse")]
        int CrearNuevaConvocatoria(IndignaFwk.Common.Entities.Convocatoria convocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/ObtenerListadoConvocatorias", ReplyAction="http://tempuri.org/IConvocatoriaService/ObtenerListadoConvocatoriasResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Convocatoria> ObtenerListadoConvocatorias();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/ObtenerListadoConvocatoriasPorGrupo", ReplyAction="http://tempuri.org/IConvocatoriaService/ObtenerListadoConvocatoriasPorGrupoRespon" +
            "se")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/ObtenerConvocatoriaPorId", ReplyAction="http://tempuri.org/IConvocatoriaService/ObtenerConvocatoriaPorIdResponse")]
        IndignaFwk.Common.Entities.Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/EditarConvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/EditarConvocatoriaResponse")]
        void EditarConvocatoria(IndignaFwk.Common.Entities.Convocatoria convocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/EliminarConvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/EliminarConvocatoriaResponse")]
        void EliminarConvocatoria(int idConvocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/CrearNuevaAsistenciaConvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/CrearNuevaAsistenciaConvocatoriaResponse")]
        int CrearNuevaAsistenciaConvocatoria(IndignaFwk.Common.Entities.AsistenciaConvocatoria asistenciaConvocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/ObtenerAsistenciaConvocatoriaPorUsuarioYC" +
            "onvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/ObtenerAsistenciaConvocatoriaPorUsuarioYC" +
            "onvocatoriaResponse")]
        IndignaFwk.Common.Entities.AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/EditarAsistenciaConvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/EditarAsistenciaConvocatoriaResponse")]
        void EditarAsistenciaConvocatoria(IndignaFwk.Common.Entities.AsistenciaConvocatoria asistenciaConvocatoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/ObtenerAsistenciaConvocatoriaPorIdUsuario" +
            "", ReplyAction="http://tempuri.org/IConvocatoriaService/ObtenerAsistenciaConvocatoriaPorIdUsuario" +
            "Response")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/ObtenerConvocatoriasPorFiltro", ReplyAction="http://tempuri.org/IConvocatoriaService/ObtenerConvocatoriasPorFiltroResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Convocatoria> ObtenerConvocatoriasPorFiltro(IndignaFwk.Common.Filter.FiltroBusqueda filtroBusqueda);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConvocatoriaService/EliminarAsistenciaConvocatoria", ReplyAction="http://tempuri.org/IConvocatoriaService/EliminarAsistenciaConvocatoriaResponse")]
        void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConvocatoriaServiceChannel : IndignaFwk.UI.Process.ConvocatoriaService.IConvocatoriaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConvocatoriaServiceClient : System.ServiceModel.ClientBase<IndignaFwk.UI.Process.ConvocatoriaService.IConvocatoriaService>, IndignaFwk.UI.Process.ConvocatoriaService.IConvocatoriaService {
        
        public ConvocatoriaServiceClient() {
        }
        
        public ConvocatoriaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConvocatoriaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvocatoriaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConvocatoriaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CrearNuevaConvocatoria(IndignaFwk.Common.Entities.Convocatoria convocatoria) {
            return base.Channel.CrearNuevaConvocatoria(convocatoria);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Convocatoria> ObtenerListadoConvocatorias() {
            return base.Channel.ObtenerListadoConvocatorias();
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Convocatoria> ObtenerListadoConvocatoriasPorGrupo(int idGrupo) {
            return base.Channel.ObtenerListadoConvocatoriasPorGrupo(idGrupo);
        }
        
        public IndignaFwk.Common.Entities.Convocatoria ObtenerConvocatoriaPorId(int idConvocatoria) {
            return base.Channel.ObtenerConvocatoriaPorId(idConvocatoria);
        }
        
        public void EditarConvocatoria(IndignaFwk.Common.Entities.Convocatoria convocatoria) {
            base.Channel.EditarConvocatoria(convocatoria);
        }
        
        public void EliminarConvocatoria(int idConvocatoria) {
            base.Channel.EliminarConvocatoria(idConvocatoria);
        }
        
        public int CrearNuevaAsistenciaConvocatoria(IndignaFwk.Common.Entities.AsistenciaConvocatoria asistenciaConvocatoria) {
            return base.Channel.CrearNuevaAsistenciaConvocatoria(asistenciaConvocatoria);
        }
        
        public IndignaFwk.Common.Entities.AsistenciaConvocatoria ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(int idUsuario, int idConvocatoria) {
            return base.Channel.ObtenerAsistenciaConvocatoriaPorUsuarioYConvocatoria(idUsuario, idConvocatoria);
        }
        
        public void EditarAsistenciaConvocatoria(IndignaFwk.Common.Entities.AsistenciaConvocatoria asistenciaConvocatoria) {
            base.Channel.EditarAsistenciaConvocatoria(asistenciaConvocatoria);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.AsistenciaConvocatoria> ObtenerAsistenciaConvocatoriaPorIdUsuario(int idUsuario) {
            return base.Channel.ObtenerAsistenciaConvocatoriaPorIdUsuario(idUsuario);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Convocatoria> ObtenerConvocatoriasPorFiltro(IndignaFwk.Common.Filter.FiltroBusqueda filtroBusqueda) {
            return base.Channel.ObtenerConvocatoriasPorFiltro(filtroBusqueda);
        }
        
        public void EliminarAsistenciaConvocatoria(int idAsistenciaConvocatoria) {
            base.Channel.EliminarAsistenciaConvocatoria(idAsistenciaConvocatoria);
        }
    }
}
