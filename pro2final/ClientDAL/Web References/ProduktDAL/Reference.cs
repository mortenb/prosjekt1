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

namespace myApp.ClientDAL.ProduktDAL {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ProduktDALSoap", Namespace="http://tempuri.org/")]
    public partial class ProduktDAL : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getProdukterOperationCompleted;
        
        private System.Threading.SendOrPostCallback getProduktOperationCompleted;
        
        private System.Threading.SendOrPostCallback getProduktTilbudOperationCompleted;
        
        private System.Threading.SendOrPostCallback nyttProduktOperationCompleted;
        
        private System.Threading.SendOrPostCallback endreProduktOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNyesteProduktFraPKOperationCompleted;
        
        private System.Threading.SendOrPostCallback getKjoepteProdukterOperationCompleted;
        
        private System.Threading.SendOrPostCallback getNyesteProduktAvKategoriOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ProduktDAL() {
            this.Url = global::myApp.ClientDAL.Properties.Settings.Default.ClientDAL_ProduktDAL_ProduktDAL;
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
        public event getProdukterCompletedEventHandler getProdukterCompleted;
        
        /// <remarks/>
        public event getProduktCompletedEventHandler getProduktCompleted;
        
        /// <remarks/>
        public event getProduktTilbudCompletedEventHandler getProduktTilbudCompleted;
        
        /// <remarks/>
        public event nyttProduktCompletedEventHandler nyttProduktCompleted;
        
        /// <remarks/>
        public event endreProduktCompletedEventHandler endreProduktCompleted;
        
        /// <remarks/>
        public event getNyesteProduktFraPKCompletedEventHandler getNyesteProduktFraPKCompleted;
        
        /// <remarks/>
        public event getKjoepteProdukterCompletedEventHandler getKjoepteProdukterCompleted;
        
        /// <remarks/>
        public event getNyesteProduktAvKategoriCompletedEventHandler getNyesteProduktAvKategoriCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getProdukter", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Produkt[] getProdukter(int produktkategoriID) {
            object[] results = this.Invoke("getProdukter", new object[] {
                        produktkategoriID});
            return ((Produkt[])(results[0]));
        }
        
        /// <remarks/>
        public void getProdukterAsync(int produktkategoriID) {
            this.getProdukterAsync(produktkategoriID, null);
        }
        
        /// <remarks/>
        public void getProdukterAsync(int produktkategoriID, object userState) {
            if ((this.getProdukterOperationCompleted == null)) {
                this.getProdukterOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetProdukterOperationCompleted);
            }
            this.InvokeAsync("getProdukter", new object[] {
                        produktkategoriID}, this.getProdukterOperationCompleted, userState);
        }
        
        private void OngetProdukterOperationCompleted(object arg) {
            if ((this.getProdukterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getProdukterCompleted(this, new getProdukterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getProdukt", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Produkt getProdukt(int produktID) {
            object[] results = this.Invoke("getProdukt", new object[] {
                        produktID});
            return ((Produkt)(results[0]));
        }
        
        /// <remarks/>
        public void getProduktAsync(int produktID) {
            this.getProduktAsync(produktID, null);
        }
        
        /// <remarks/>
        public void getProduktAsync(int produktID, object userState) {
            if ((this.getProduktOperationCompleted == null)) {
                this.getProduktOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetProduktOperationCompleted);
            }
            this.InvokeAsync("getProdukt", new object[] {
                        produktID}, this.getProduktOperationCompleted, userState);
        }
        
        private void OngetProduktOperationCompleted(object arg) {
            if ((this.getProduktCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getProduktCompleted(this, new getProduktCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getProduktTilbud", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Produkt[] getProduktTilbud() {
            object[] results = this.Invoke("getProduktTilbud", new object[0]);
            return ((Produkt[])(results[0]));
        }
        
        /// <remarks/>
        public void getProduktTilbudAsync() {
            this.getProduktTilbudAsync(null);
        }
        
        /// <remarks/>
        public void getProduktTilbudAsync(object userState) {
            if ((this.getProduktTilbudOperationCompleted == null)) {
                this.getProduktTilbudOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetProduktTilbudOperationCompleted);
            }
            this.InvokeAsync("getProduktTilbud", new object[0], this.getProduktTilbudOperationCompleted, userState);
        }
        
        private void OngetProduktTilbudOperationCompleted(object arg) {
            if ((this.getProduktTilbudCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getProduktTilbudCompleted(this, new getProduktTilbudCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/nyttProdukt", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void nyttProdukt(Produkt p) {
            this.Invoke("nyttProdukt", new object[] {
                        p});
        }
        
        /// <remarks/>
        public void nyttProduktAsync(Produkt p) {
            this.nyttProduktAsync(p, null);
        }
        
        /// <remarks/>
        public void nyttProduktAsync(Produkt p, object userState) {
            if ((this.nyttProduktOperationCompleted == null)) {
                this.nyttProduktOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnyttProduktOperationCompleted);
            }
            this.InvokeAsync("nyttProdukt", new object[] {
                        p}, this.nyttProduktOperationCompleted, userState);
        }
        
        private void OnnyttProduktOperationCompleted(object arg) {
            if ((this.nyttProduktCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nyttProduktCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/endreProdukt", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void endreProdukt(Produkt p) {
            this.Invoke("endreProdukt", new object[] {
                        p});
        }
        
        /// <remarks/>
        public void endreProduktAsync(Produkt p) {
            this.endreProduktAsync(p, null);
        }
        
        /// <remarks/>
        public void endreProduktAsync(Produkt p, object userState) {
            if ((this.endreProduktOperationCompleted == null)) {
                this.endreProduktOperationCompleted = new System.Threading.SendOrPostCallback(this.OnendreProduktOperationCompleted);
            }
            this.InvokeAsync("endreProdukt", new object[] {
                        p}, this.endreProduktOperationCompleted, userState);
        }
        
        private void OnendreProduktOperationCompleted(object arg) {
            if ((this.endreProduktCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.endreProduktCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getNyesteProduktFraPK", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Produkt getNyesteProduktFraPK(string brukernavn) {
            object[] results = this.Invoke("getNyesteProduktFraPK", new object[] {
                        brukernavn});
            return ((Produkt)(results[0]));
        }
        
        /// <remarks/>
        public void getNyesteProduktFraPKAsync(string brukernavn) {
            this.getNyesteProduktFraPKAsync(brukernavn, null);
        }
        
        /// <remarks/>
        public void getNyesteProduktFraPKAsync(string brukernavn, object userState) {
            if ((this.getNyesteProduktFraPKOperationCompleted == null)) {
                this.getNyesteProduktFraPKOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNyesteProduktFraPKOperationCompleted);
            }
            this.InvokeAsync("getNyesteProduktFraPK", new object[] {
                        brukernavn}, this.getNyesteProduktFraPKOperationCompleted, userState);
        }
        
        private void OngetNyesteProduktFraPKOperationCompleted(object arg) {
            if ((this.getNyesteProduktFraPKCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNyesteProduktFraPKCompleted(this, new getNyesteProduktFraPKCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getKjoepteProdukter", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Produkt[] getKjoepteProdukter(string brukernavn) {
            object[] results = this.Invoke("getKjoepteProdukter", new object[] {
                        brukernavn});
            return ((Produkt[])(results[0]));
        }
        
        /// <remarks/>
        public void getKjoepteProdukterAsync(string brukernavn) {
            this.getKjoepteProdukterAsync(brukernavn, null);
        }
        
        /// <remarks/>
        public void getKjoepteProdukterAsync(string brukernavn, object userState) {
            if ((this.getKjoepteProdukterOperationCompleted == null)) {
                this.getKjoepteProdukterOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetKjoepteProdukterOperationCompleted);
            }
            this.InvokeAsync("getKjoepteProdukter", new object[] {
                        brukernavn}, this.getKjoepteProdukterOperationCompleted, userState);
        }
        
        private void OngetKjoepteProdukterOperationCompleted(object arg) {
            if ((this.getKjoepteProdukterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getKjoepteProdukterCompleted(this, new getKjoepteProdukterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getNyesteProduktAvKategori", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Produkt getNyesteProduktAvKategori(int pkID) {
            object[] results = this.Invoke("getNyesteProduktAvKategori", new object[] {
                        pkID});
            return ((Produkt)(results[0]));
        }
        
        /// <remarks/>
        public void getNyesteProduktAvKategoriAsync(int pkID) {
            this.getNyesteProduktAvKategoriAsync(pkID, null);
        }
        
        /// <remarks/>
        public void getNyesteProduktAvKategoriAsync(int pkID, object userState) {
            if ((this.getNyesteProduktAvKategoriOperationCompleted == null)) {
                this.getNyesteProduktAvKategoriOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetNyesteProduktAvKategoriOperationCompleted);
            }
            this.InvokeAsync("getNyesteProduktAvKategori", new object[] {
                        pkID}, this.getNyesteProduktAvKategoriOperationCompleted, userState);
        }
        
        private void OngetNyesteProduktAvKategoriOperationCompleted(object arg) {
            if ((this.getNyesteProduktAvKategoriCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getNyesteProduktAvKategoriCompleted(this, new getNyesteProduktAvKategoriCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class Produkt {
        
        private int produktIDField;
        
        private string tittelField;
        
        private int antallPaaLagerField;
        
        private string beskrivelseField;
        
        private string bildeURLField;
        
        private int prisField;
        
        private int produktkategoriIDField;
        
        /// <remarks/>
        public int ProduktID {
            get {
                return this.produktIDField;
            }
            set {
                this.produktIDField = value;
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
        public int AntallPaaLager {
            get {
                return this.antallPaaLagerField;
            }
            set {
                this.antallPaaLagerField = value;
            }
        }
        
        /// <remarks/>
        public string Beskrivelse {
            get {
                return this.beskrivelseField;
            }
            set {
                this.beskrivelseField = value;
            }
        }
        
        /// <remarks/>
        public string BildeURL {
            get {
                return this.bildeURLField;
            }
            set {
                this.bildeURLField = value;
            }
        }
        
        /// <remarks/>
        public int Pris {
            get {
                return this.prisField;
            }
            set {
                this.prisField = value;
            }
        }
        
        /// <remarks/>
        public int ProduktkategoriID {
            get {
                return this.produktkategoriIDField;
            }
            set {
                this.produktkategoriIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getProdukterCompletedEventHandler(object sender, getProdukterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getProdukterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getProdukterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Produkt[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Produkt[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getProduktCompletedEventHandler(object sender, getProduktCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getProduktCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getProduktCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Produkt Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Produkt)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getProduktTilbudCompletedEventHandler(object sender, getProduktTilbudCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getProduktTilbudCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getProduktTilbudCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Produkt[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Produkt[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void nyttProduktCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void endreProduktCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getNyesteProduktFraPKCompletedEventHandler(object sender, getNyesteProduktFraPKCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNyesteProduktFraPKCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNyesteProduktFraPKCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Produkt Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Produkt)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getKjoepteProdukterCompletedEventHandler(object sender, getKjoepteProdukterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getKjoepteProdukterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getKjoepteProdukterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Produkt[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Produkt[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void getNyesteProduktAvKategoriCompletedEventHandler(object sender, getNyesteProduktAvKategoriCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getNyesteProduktAvKategoriCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getNyesteProduktAvKategoriCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Produkt Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Produkt)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591