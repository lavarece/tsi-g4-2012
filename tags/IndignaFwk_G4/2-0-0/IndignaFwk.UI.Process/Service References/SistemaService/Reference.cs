﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndignaFwk.UI.Process.SistemaService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SistemaService.ISistemaService")]
    public interface ISistemaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerListadoVariables", ReplyAction="http://tempuri.org/ISistemaService/ObtenerListadoVariablesResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.VariableSistema> ObtenerListadoVariables();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerVariablePorId", ReplyAction="http://tempuri.org/ISistemaService/ObtenerVariablePorIdResponse")]
        IndignaFwk.Common.Entities.VariableSistema ObtenerVariablePorId(int idVariable);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerVariablePorNombre", ReplyAction="http://tempuri.org/ISistemaService/ObtenerVariablePorNombreResponse")]
        IndignaFwk.Common.Entities.VariableSistema ObtenerVariablePorNombre(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/EditarVariableSistema", ReplyAction="http://tempuri.org/ISistemaService/EditarVariableSistemaResponse")]
        void EditarVariableSistema(IndignaFwk.Common.Entities.VariableSistema variableSistema);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerLayoutPorId", ReplyAction="http://tempuri.org/ISistemaService/ObtenerLayoutPorIdResponse")]
        IndignaFwk.Common.Entities.Layout ObtenerLayoutPorId(int idLayout);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerListadoLayouts", ReplyAction="http://tempuri.org/ISistemaService/ObtenerListadoLayoutsResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Layout> ObtenerListadoLayouts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerTematicaPorId", ReplyAction="http://tempuri.org/ISistemaService/ObtenerTematicaPorIdResponse")]
        IndignaFwk.Common.Entities.Tematica ObtenerTematicaPorId(int idTematica);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISistemaService/ObtenerListadoTematicas", ReplyAction="http://tempuri.org/ISistemaService/ObtenerListadoTematicasResponse")]
        System.Collections.Generic.List<IndignaFwk.Common.Entities.Tematica> ObtenerListadoTematicas();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISistemaServiceChannel : IndignaFwk.UI.Process.SistemaService.ISistemaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SistemaServiceClient : System.ServiceModel.ClientBase<IndignaFwk.UI.Process.SistemaService.ISistemaService>, IndignaFwk.UI.Process.SistemaService.ISistemaService {
        
        public SistemaServiceClient() {
        }
        
        public SistemaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SistemaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SistemaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SistemaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.VariableSistema> ObtenerListadoVariables() {
            return base.Channel.ObtenerListadoVariables();
        }
        
        public IndignaFwk.Common.Entities.VariableSistema ObtenerVariablePorId(int idVariable) {
            return base.Channel.ObtenerVariablePorId(idVariable);
        }
        
        public IndignaFwk.Common.Entities.VariableSistema ObtenerVariablePorNombre(string nombre) {
            return base.Channel.ObtenerVariablePorNombre(nombre);
        }
        
        public void EditarVariableSistema(IndignaFwk.Common.Entities.VariableSistema variableSistema) {
            base.Channel.EditarVariableSistema(variableSistema);
        }
        
        public IndignaFwk.Common.Entities.Layout ObtenerLayoutPorId(int idLayout) {
            return base.Channel.ObtenerLayoutPorId(idLayout);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Layout> ObtenerListadoLayouts() {
            return base.Channel.ObtenerListadoLayouts();
        }
        
        public IndignaFwk.Common.Entities.Tematica ObtenerTematicaPorId(int idTematica) {
            return base.Channel.ObtenerTematicaPorId(idTematica);
        }
        
        public System.Collections.Generic.List<IndignaFwk.Common.Entities.Tematica> ObtenerListadoTematicas() {
            return base.Channel.ObtenerListadoTematicas();
        }
    }
}
