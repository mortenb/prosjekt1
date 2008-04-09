﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.832.
// 
#pragma warning disable 1591

namespace myApp.ClientDAL.WSAnmeldelseDAL {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AnmeldelseDALSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Nyhet))]
    public partial class AnmeldelseDAL : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getAnmeldelserOperationCompleted;
        
        private System.Threading.SendOrPostCallback getAnmeldelseOperationCompleted;
        
        private System.Threading.SendOrPostCallback nyAnmeldelseOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AnmeldelseDAL() {
            this.Url = global::myApp.ClientDAL.Properties.Settings.Default.ClientDAL_AnmeldelseDAL_AnmeldelseDAL;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event getAnmeldelserCompletedEventHandler getAnmeldelserCompleted;
        
        /// <remarks/>
        public event getAnmeldelseCompletedEventHandler getAnmeldelseCompleted;
        
        /// <remarks/>
        public event nyAnmeldelseCompletedEventHandler nyAnmeldelseCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getAnmeldelser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Anmeldelse[] getAnmeldelser(int produktID) {
            object[] results = this.Invoke("getAnmeldelser", new object[] {
                        produktID});
            return ((Anmeldelse[])(results[0]));
        }
        
        /// <remarks/>
        public void getAnmeldelserAsync(int produktID) {
            this.getAnmeldelserAsync(produktID, null);
        }
        
        /// <remarks/>
        public void getAnmeldelserAsync(int produktID, object userState) {
            if ((this.getAnmeldelserOperationCompleted == null)) {
                this.getAnmeldelserOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAnmeldelserOperationCompleted);
            }
            this.InvokeAsync("getAnmeldelser", new object[] {
                        produktID}, this.getAnmeldelserOperationCompleted, userState);
        }
        
        private void OngetAnmeldelserOperationCompleted(object arg) {
            if ((this.getAnmeldelserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAnmeldelserCompleted(this, new getAnmeldelserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getAnmeldelse", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Anmeldelse getAnmeldelse(int anmID) {
            object[] results = this.Invoke("getAnmeldelse", new object[] {
                        anmID});
            return ((Anmeldelse)(results[0]));
        }
        
        /// <remarks/>
        public void getAnmeldelseAsync(int anmID) {
            this.getAnmeldelseAsync(anmID, null);
        }
        
        /// <remarks/>
        public void getAnmeldelseAsync(int anmID, object userState) {
            if ((this.getAnmeldelseOperationCompleted == null)) {
                this.getAnmeldelseOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetAnmeldelseOperationCompleted);
            }
            this.InvokeAsync("getAnmeldelse", new object[] {
                        anmID}, this.getAnmeldelseOperationCompleted, userState);
        }
        
        private void OngetAnmeldelseOperationCompleted(object arg) {
            if ((this.getAnmeldelseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getAnmeldelseCompleted(this, new getAnmeldelseCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/nyAnmeldelse", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void nyAnmeldelse(Anmeldelse anm) {
            this.Invoke("nyAnmeldelse", new object[] {
                        anm});
        }
        
        /// <remarks/>
        public void nyAnmeldelseAsync(Anmeldelse anm) {
            this.nyAnmeldelseAsync(anm, null);
        }
        
        /// <remarks/>
        public void nyAnmeldelseAsync(Anmeldelse anm, object userState) {
            if ((this.nyAnmeldelseOperationCompleted == null)) {
                this.nyAnmeldelseOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnyAnmeldelseOperationCompleted);
            }
            this.InvokeAsync("nyAnmeldelse", new object[] {
                        anm}, this.nyAnmeldelseOperationCompleted, userState);
        }
        
        private void OnnyAnmeldelseOperationCompleted(object arg) {
            if ((this.nyAnmeldelseCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nyAnmeldelseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Anmeldelse : Nyhet {
        
        private int karakterField;
        
        private int produktIDField;
        
        /// <remarks/>
        public int Karakter {
            get {
                return this.karakterField;
            }
            set {
                this.karakterField = value;
            }
        }
        
        /// <remarks/>
        public int ProduktID {
            get {
                return this.produktIDField;
            }
            set {
                this.produktIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Anmeldelse))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.832")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Nyhet {
        
        private int nyhetsIDField;
        
        private string tittelField;
        
        private string tekstField;
        
        /// <remarks/>
        public int NyhetsID {
            get {
                return this.nyhetsIDField;
            }
            set {
                this.nyhetsIDField = value;
            }
        }
        
        /// <remarks/>
        public string Tittel {
            get {
                return this.tittelField;
            }
            set {
                this.tittelField = value;
            }
        }
        
        /// <remarks/>
        public string Tekst {
            get {
                return this.tekstField;
            }
            set {
                this.tekstField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getAnmeldelserCompletedEventHandler(object sender, getAnmeldelserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAnmeldelserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAnmeldelserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Anmeldelse[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Anmeldelse[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getAnmeldelseCompletedEventHandler(object sender, getAnmeldelseCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getAnmeldelseCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getAnmeldelseCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Anmeldelse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Anmeldelse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void nyAnmeldelseCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591