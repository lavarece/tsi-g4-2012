﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
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

        public System.Collections.Generic.List<IndignaFwk.Common.Entities.VariableSistema> ObtenerListadoVariables()
        {
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
    }
}
