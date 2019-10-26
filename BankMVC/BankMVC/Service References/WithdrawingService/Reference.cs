﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankMVC.WithdrawingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WithdrawingService.IWithdrawingService")]
    public interface IWithdrawingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWithdrawingService/Withdraw", ReplyAction="http://tempuri.org/IWithdrawingService/WithdrawResponse")]
        void Withdraw(decimal amount, Pocos.BankAccount bankAccount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWithdrawingService/Withdraw", ReplyAction="http://tempuri.org/IWithdrawingService/WithdrawResponse")]
        System.Threading.Tasks.Task WithdrawAsync(decimal amount, Pocos.BankAccount bankAccount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWithdrawingServiceChannel : BankMVC.WithdrawingService.IWithdrawingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WithdrawingServiceClient : System.ServiceModel.ClientBase<BankMVC.WithdrawingService.IWithdrawingService>, BankMVC.WithdrawingService.IWithdrawingService {
        
        public WithdrawingServiceClient() {
        }
        
        public WithdrawingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WithdrawingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WithdrawingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WithdrawingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Withdraw(decimal amount, Pocos.BankAccount bankAccount) {
            base.Channel.Withdraw(amount, bankAccount);
        }
        
        public System.Threading.Tasks.Task WithdrawAsync(decimal amount, Pocos.BankAccount bankAccount) {
            return base.Channel.WithdrawAsync(amount, bankAccount);
        }
    }
}
