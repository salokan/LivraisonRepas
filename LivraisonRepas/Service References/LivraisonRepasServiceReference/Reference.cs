﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34209
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 12.0.21005.1
// 
namespace LivraisonRepas.LivraisonRepasServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UtilisateursComposite", Namespace="http://schemas.datacontract.org/2004/07/LivraisonRepasService.Composite")]
    public partial class UtilisateursComposite : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AdresseValueField;
        
        private int IdUtilisateursValueField;
        
        private string PasswordValueField;
        
        private string PseudoValueField;
        
        private string TypeValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AdresseValue {
            get {
                return this.AdresseValueField;
            }
            set {
                if ((object.ReferenceEquals(this.AdresseValueField, value) != true)) {
                    this.AdresseValueField = value;
                    this.RaisePropertyChanged("AdresseValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUtilisateursValue {
            get {
                return this.IdUtilisateursValueField;
            }
            set {
                if ((this.IdUtilisateursValueField.Equals(value) != true)) {
                    this.IdUtilisateursValueField = value;
                    this.RaisePropertyChanged("IdUtilisateursValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PasswordValue {
            get {
                return this.PasswordValueField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordValueField, value) != true)) {
                    this.PasswordValueField = value;
                    this.RaisePropertyChanged("PasswordValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PseudoValue {
            get {
                return this.PseudoValueField;
            }
            set {
                if ((object.ReferenceEquals(this.PseudoValueField, value) != true)) {
                    this.PseudoValueField = value;
                    this.RaisePropertyChanged("PseudoValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TypeValue {
            get {
                return this.TypeValueField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeValueField, value) != true)) {
                    this.TypeValueField = value;
                    this.RaisePropertyChanged("TypeValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Utilisateurs", Namespace="http://schemas.datacontract.org/2004/07/LivraisonRepasService")]
    public partial class Utilisateurs : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AdresseField;
        
        private System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.Commandes> CommandesField;
        
        private System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.Commandes> Commandes1Field;
        
        private int IdField;
        
        private string PasswordField;
        
        private string PseudoField;
        
        private string TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Adresse {
            get {
                return this.AdresseField;
            }
            set {
                if ((object.ReferenceEquals(this.AdresseField, value) != true)) {
                    this.AdresseField = value;
                    this.RaisePropertyChanged("Adresse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.Commandes> Commandes {
            get {
                return this.CommandesField;
            }
            set {
                if ((object.ReferenceEquals(this.CommandesField, value) != true)) {
                    this.CommandesField = value;
                    this.RaisePropertyChanged("Commandes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.Commandes> Commandes1 {
            get {
                return this.Commandes1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Commandes1Field, value) != true)) {
                    this.Commandes1Field = value;
                    this.RaisePropertyChanged("Commandes1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pseudo {
            get {
                return this.PseudoField;
            }
            set {
                if ((object.ReferenceEquals(this.PseudoField, value) != true)) {
                    this.PseudoField = value;
                    this.RaisePropertyChanged("Pseudo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Commandes", Namespace="http://schemas.datacontract.org/2004/07/LivraisonRepasService")]
    public partial class Commandes : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ContenuField;
        
        private string EtatField;
        
        private int IdField;
        
        private int Id_ClientField;
        
        private int Id_LivreurField;
        
        private LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs UtilisateursField;
        
        private LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs Utilisateurs1Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contenu {
            get {
                return this.ContenuField;
            }
            set {
                if ((object.ReferenceEquals(this.ContenuField, value) != true)) {
                    this.ContenuField = value;
                    this.RaisePropertyChanged("Contenu");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Etat {
            get {
                return this.EtatField;
            }
            set {
                if ((object.ReferenceEquals(this.EtatField, value) != true)) {
                    this.EtatField = value;
                    this.RaisePropertyChanged("Etat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id_Client {
            get {
                return this.Id_ClientField;
            }
            set {
                if ((this.Id_ClientField.Equals(value) != true)) {
                    this.Id_ClientField = value;
                    this.RaisePropertyChanged("Id_Client");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id_Livreur {
            get {
                return this.Id_LivreurField;
            }
            set {
                if ((this.Id_LivreurField.Equals(value) != true)) {
                    this.Id_LivreurField = value;
                    this.RaisePropertyChanged("Id_Livreur");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs Utilisateurs {
            get {
                return this.UtilisateursField;
            }
            set {
                if ((object.ReferenceEquals(this.UtilisateursField, value) != true)) {
                    this.UtilisateursField = value;
                    this.RaisePropertyChanged("Utilisateurs");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs Utilisateurs1 {
            get {
                return this.Utilisateurs1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Utilisateurs1Field, value) != true)) {
                    this.Utilisateurs1Field = value;
                    this.RaisePropertyChanged("Utilisateurs1");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommandesComposite", Namespace="http://schemas.datacontract.org/2004/07/LivraisonRepasService.Composite")]
    public partial class CommandesComposite : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string ContenuValueField;
        
        private string EtatValueField;
        
        private int IdClientsValueField;
        
        private int IdCommandesValueField;
        
        private int IdLivreursValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContenuValue {
            get {
                return this.ContenuValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ContenuValueField, value) != true)) {
                    this.ContenuValueField = value;
                    this.RaisePropertyChanged("ContenuValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EtatValue {
            get {
                return this.EtatValueField;
            }
            set {
                if ((object.ReferenceEquals(this.EtatValueField, value) != true)) {
                    this.EtatValueField = value;
                    this.RaisePropertyChanged("EtatValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdClientsValue {
            get {
                return this.IdClientsValueField;
            }
            set {
                if ((this.IdClientsValueField.Equals(value) != true)) {
                    this.IdClientsValueField = value;
                    this.RaisePropertyChanged("IdClientsValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCommandesValue {
            get {
                return this.IdCommandesValueField;
            }
            set {
                if ((this.IdCommandesValueField.Equals(value) != true)) {
                    this.IdCommandesValueField = value;
                    this.RaisePropertyChanged("IdCommandesValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdLivreursValue {
            get {
                return this.IdLivreursValueField;
            }
            set {
                if ((this.IdLivreursValueField.Equals(value) != true)) {
                    this.IdLivreursValueField = value;
                    this.RaisePropertyChanged("IdLivreursValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LivraisonRepasServiceReference.ILivraisonRepasService")]
    public interface ILivraisonRepasService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/GetUtilisateurs", ReplyAction="http://tempuri.org/ILivraisonRepasService/GetUtilisateursResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.UtilisateursComposite>> GetUtilisateursAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/GetUtilisateur", ReplyAction="http://tempuri.org/ILivraisonRepasService/GetUtilisateurResponse")]
        System.Threading.Tasks.Task<LivraisonRepas.LivraisonRepasServiceReference.UtilisateursComposite> GetUtilisateurAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/AddUtilisateurs", ReplyAction="http://tempuri.org/ILivraisonRepasService/AddUtilisateursResponse")]
        System.Threading.Tasks.Task AddUtilisateursAsync(LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/DeleteUtilisateurs", ReplyAction="http://tempuri.org/ILivraisonRepasService/DeleteUtilisateursResponse")]
        System.Threading.Tasks.Task DeleteUtilisateursAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/UpdateUtilisateurs", ReplyAction="http://tempuri.org/ILivraisonRepasService/UpdateUtilisateursResponse")]
        System.Threading.Tasks.Task UpdateUtilisateursAsync(LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/AuthentificationUtilisateur", ReplyAction="http://tempuri.org/ILivraisonRepasService/AuthentificationUtilisateurResponse")]
        System.Threading.Tasks.Task<LivraisonRepas.LivraisonRepasServiceReference.UtilisateursComposite> AuthentificationUtilisateurAsync(string pseudo, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/ExistePseudo", ReplyAction="http://tempuri.org/ILivraisonRepasService/ExistePseudoResponse")]
        System.Threading.Tasks.Task<bool> ExistePseudoAsync(string pseudo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/GetCommandes", ReplyAction="http://tempuri.org/ILivraisonRepasService/GetCommandesResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.CommandesComposite>> GetCommandesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/GetCommande", ReplyAction="http://tempuri.org/ILivraisonRepasService/GetCommandeResponse")]
        System.Threading.Tasks.Task<LivraisonRepas.LivraisonRepasServiceReference.CommandesComposite> GetCommandeAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/AddCommandes", ReplyAction="http://tempuri.org/ILivraisonRepasService/AddCommandesResponse")]
        System.Threading.Tasks.Task AddCommandesAsync(LivraisonRepas.LivraisonRepasServiceReference.Commandes c);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/DeleteCommandes", ReplyAction="http://tempuri.org/ILivraisonRepasService/DeleteCommandesResponse")]
        System.Threading.Tasks.Task DeleteCommandesAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILivraisonRepasService/UpdateCommandes", ReplyAction="http://tempuri.org/ILivraisonRepasService/UpdateCommandesResponse")]
        System.Threading.Tasks.Task UpdateCommandesAsync(LivraisonRepas.LivraisonRepasServiceReference.Commandes c);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILivraisonRepasServiceChannel : LivraisonRepas.LivraisonRepasServiceReference.ILivraisonRepasService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LivraisonRepasServiceClient : System.ServiceModel.ClientBase<LivraisonRepas.LivraisonRepasServiceReference.ILivraisonRepasService>, LivraisonRepas.LivraisonRepasServiceReference.ILivraisonRepasService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public LivraisonRepasServiceClient() : 
                base(LivraisonRepasServiceClient.GetDefaultBinding(), LivraisonRepasServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ILivraisonRepasService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LivraisonRepasServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(LivraisonRepasServiceClient.GetBindingForEndpoint(endpointConfiguration), LivraisonRepasServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LivraisonRepasServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(LivraisonRepasServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LivraisonRepasServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(LivraisonRepasServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LivraisonRepasServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.UtilisateursComposite>> GetUtilisateursAsync() {
            return base.Channel.GetUtilisateursAsync();
        }
        
        public System.Threading.Tasks.Task<LivraisonRepas.LivraisonRepasServiceReference.UtilisateursComposite> GetUtilisateurAsync(int id) {
            return base.Channel.GetUtilisateurAsync(id);
        }
        
        public System.Threading.Tasks.Task AddUtilisateursAsync(LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs u) {
            return base.Channel.AddUtilisateursAsync(u);
        }
        
        public System.Threading.Tasks.Task DeleteUtilisateursAsync(int id) {
            return base.Channel.DeleteUtilisateursAsync(id);
        }
        
        public System.Threading.Tasks.Task UpdateUtilisateursAsync(LivraisonRepas.LivraisonRepasServiceReference.Utilisateurs u) {
            return base.Channel.UpdateUtilisateursAsync(u);
        }
        
        public System.Threading.Tasks.Task<LivraisonRepas.LivraisonRepasServiceReference.UtilisateursComposite> AuthentificationUtilisateurAsync(string pseudo, string password) {
            return base.Channel.AuthentificationUtilisateurAsync(pseudo, password);
        }
        
        public System.Threading.Tasks.Task<bool> ExistePseudoAsync(string pseudo) {
            return base.Channel.ExistePseudoAsync(pseudo);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<LivraisonRepas.LivraisonRepasServiceReference.CommandesComposite>> GetCommandesAsync() {
            return base.Channel.GetCommandesAsync();
        }
        
        public System.Threading.Tasks.Task<LivraisonRepas.LivraisonRepasServiceReference.CommandesComposite> GetCommandeAsync(int id) {
            return base.Channel.GetCommandeAsync(id);
        }
        
        public System.Threading.Tasks.Task AddCommandesAsync(LivraisonRepas.LivraisonRepasServiceReference.Commandes c) {
            return base.Channel.AddCommandesAsync(c);
        }
        
        public System.Threading.Tasks.Task DeleteCommandesAsync(int id) {
            return base.Channel.DeleteCommandesAsync(id);
        }
        
        public System.Threading.Tasks.Task UpdateCommandesAsync(LivraisonRepas.LivraisonRepasServiceReference.Commandes c) {
            return base.Channel.UpdateCommandesAsync(c);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ILivraisonRepasService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ILivraisonRepasService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:45719/LivraisonRepasService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return LivraisonRepasServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ILivraisonRepasService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return LivraisonRepasServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ILivraisonRepasService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_ILivraisonRepasService,
        }
    }
}
