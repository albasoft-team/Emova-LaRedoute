﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace safeprojectname.ServiceReference1 {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/Fault/1.0")]
    public partial class Fault_10 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string faultIdField;
        
        private string faultMessageField;
        
        private string faultTraceField;
        
        private System.DateTime trcTsField;
        
        private bool trcTsFieldSpecified;
        
        private string msgIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string FaultId {
            get {
                return this.faultIdField;
            }
            set {
                this.faultIdField = value;
                this.RaisePropertyChanged("FaultId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string FaultMessage {
            get {
                return this.faultMessageField;
            }
            set {
                this.faultMessageField = value;
                this.RaisePropertyChanged("FaultMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string FaultTrace {
            get {
                return this.faultTraceField;
            }
            set {
                this.faultTraceField = value;
                this.RaisePropertyChanged("FaultTrace");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.DateTime TrcTs {
            get {
                return this.trcTsField;
            }
            set {
                this.trcTsField = value;
                this.RaisePropertyChanged("TrcTs");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TrcTsSpecified {
            get {
                return this.trcTsFieldSpecified;
            }
            set {
                this.trcTsFieldSpecified = value;
                this.RaisePropertyChanged("TrcTsSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string msgID {
            get {
                return this.msgIDField;
            }
            set {
                this.msgIDField = value;
                this.RaisePropertyChanged("msgID");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0", ConfigurationName="ServiceReference1.portType")]
    public interface portType {
        
        // CODEGEN: Generating message contract since the wrapper namespace (http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0) of message InjectFileToOverride_1.0OpRequest does not match the default value (http://Redcats/File/ESB-TIBCO/File/1.0)
        [System.ServiceModel.OperationContractAttribute(Action="InjectFileToOverride_1.0", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(safeprojectname.ServiceReference1.Fault_10), Action="InjectFileToOverride_1.0", Name="Fault_1.0", Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/Fault/1.0")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        safeprojectname.ServiceReference1.InjectFileToOverride_10OpResponse InjectFileToOverride_10Op(safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="InjectFileToOverride_1.0", ReplyAction="*")]
        System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFileToOverride_10OpResponse> InjectFileToOverride_10OpAsync(safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="InjectFile_1.0", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(safeprojectname.ServiceReference1.Fault_10), Action="InjectFile_1.0", Name="Fault_1.0", Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/Fault/1.0")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        safeprojectname.ServiceReference1.InjectFile_10OpResponse InjectFile_10Op(safeprojectname.ServiceReference1.InjectFile_10OpRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="InjectFile_1.0", ReplyAction="*")]
        System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFile_10OpResponse> InjectFile_10OpAsync(safeprojectname.ServiceReference1.InjectFile_10OpRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="InjectFileFromKwai_1.0", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(safeprojectname.ServiceReference1.Fault_10), Action="InjectFileFromKwai_1.0", Name="Fault_1.0", Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/Fault/1.0")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        safeprojectname.ServiceReference1.InjectFileFromKwai_10OpResponse InjectFileFromKwai_10Op(safeprojectname.ServiceReference1.InjectFileFromKwai_10OpRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="InjectFileFromKwai_1.0", ReplyAction="*")]
        System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFileFromKwai_10OpResponse> InjectFileFromKwai_10OpAsync(safeprojectname.ServiceReference1.InjectFileFromKwai_10OpRequest request);
        
        // CODEGEN: Generating message contract since the operation GetVersion_1.0Op is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="GetVersion_1.0", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(safeprojectname.ServiceReference1.Fault_10), Action="GetVersion_1.0", Name="Fault_1.0", Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/Fault/1.0")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        safeprojectname.ServiceReference1.GetVersion_10OpResponse GetVersion_10Op(safeprojectname.ServiceReference1.GetVersion_10OpRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="GetVersion_1.0", ReplyAction="*")]
        System.Threading.Tasks.Task<safeprojectname.ServiceReference1.GetVersion_10OpResponse> GetVersion_10OpAsync(safeprojectname.ServiceReference1.GetVersion_10OpRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InjectFileToOverrideRequest_1.0", WrapperNamespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", IsWrapped=true)]
    public partial class InjectFileToOverride_10OpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=0)]
        public string EUserId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=1)]
        public string ESystem;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=2)]
        public string FlowName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=3)]
        public string FlowVersion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=4)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=5)]
        public string FilePath;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=6)]
        public int NumberOfElements;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=7)]
        public bool fileAttachedWithSoapMsg;
        
        public InjectFileToOverride_10OpRequest() {
        }
        
        public InjectFileToOverride_10OpRequest(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg) {
            this.EUserId = EUserId;
            this.ESystem = ESystem;
            this.FlowName = FlowName;
            this.FlowVersion = FlowVersion;
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.NumberOfElements = NumberOfElements;
            this.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InjectFileToOverrideResponse_1.0", WrapperNamespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", IsWrapped=true)]
    public partial class InjectFileToOverride_10OpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/FileManagerInterface/ESB-TIBCO/File/1.0/InjectFileToOverride/1.0", Order=0)]
        public string respParameter;
        
        public InjectFileToOverride_10OpResponse() {
        }
        
        public InjectFileToOverride_10OpResponse(string respParameter) {
            this.respParameter = respParameter;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
    public partial class ErrorType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codeField;
        
        private string messageField;
        
        private string typeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("Code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("Message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InjectFileRequest_1.0", WrapperNamespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", IsWrapped=true)]
    public partial class InjectFile_10OpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=0)]
        public string EUserId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=1)]
        public string ESystem;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=2)]
        public string FlowName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=3)]
        public string FlowVersion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=4)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=5)]
        public string FilePath;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=6)]
        public int NumberOfElements;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=7)]
        public bool fileAttachedWithSoapMsg;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=8)]
        public System.Xml.XmlElement FunctionalValidationInformation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=9)]
        public bool Overwrite;
        
        public InjectFile_10OpRequest() {
        }
        
        public InjectFile_10OpRequest(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg, System.Xml.XmlElement FunctionalValidationInformation, bool Overwrite) {
            this.EUserId = EUserId;
            this.ESystem = ESystem;
            this.FlowName = FlowName;
            this.FlowVersion = FlowVersion;
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.NumberOfElements = NumberOfElements;
            this.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
            this.FunctionalValidationInformation = FunctionalValidationInformation;
            this.Overwrite = Overwrite;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InjectFileResponse_1.0", WrapperNamespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", IsWrapped=true)]
    public partial class InjectFile_10OpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=0)]
        public bool processWithSuccess;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=1)]
        public string BatchId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=2)]
        public safeprojectname.ServiceReference1.ErrorType Error;
        
        public InjectFile_10OpResponse() {
        }
        
        public InjectFile_10OpResponse(bool processWithSuccess, string BatchId, safeprojectname.ServiceReference1.ErrorType Error) {
            this.processWithSuccess = processWithSuccess;
            this.BatchId = BatchId;
            this.Error = Error;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InjectFileFromKwaiRequest_1.0", WrapperNamespace="http://RedCats/Inject/ESB-TIBCO/KwaiFile/1.0/InjectFileFromKwai/1.0", IsWrapped=true)]
    public partial class InjectFileFromKwai_10OpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string EUserId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string ESystem;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string FlowName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string FlowVersion;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string FilePath;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public int NumberOfElements;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public bool fileAttachedWithSoapMsg;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public System.Xml.XmlElement FunctionalValidationInformation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=9)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public bool Overwrite;
        
        public InjectFileFromKwai_10OpRequest() {
        }
        
        public InjectFileFromKwai_10OpRequest(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg, System.Xml.XmlElement FunctionalValidationInformation, bool Overwrite) {
            this.EUserId = EUserId;
            this.ESystem = ESystem;
            this.FlowName = FlowName;
            this.FlowVersion = FlowVersion;
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.NumberOfElements = NumberOfElements;
            this.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
            this.FunctionalValidationInformation = FunctionalValidationInformation;
            this.Overwrite = Overwrite;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InjectFileFromKwaiResponse_1.0", WrapperNamespace="http://RedCats/Inject/ESB-TIBCO/KwaiFile/1.0/InjectFileFromKwai/1.0", IsWrapped=true)]
    public partial class InjectFileFromKwai_10OpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public bool processWithSuccess;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public string BatchId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0")]
        public safeprojectname.ServiceReference1.ErrorType Error;
        
        public InjectFileFromKwai_10OpResponse() {
        }
        
        public InjectFileFromKwai_10OpResponse(bool processWithSuccess, string BatchId, safeprojectname.ServiceReference1.ErrorType Error) {
            this.processWithSuccess = processWithSuccess;
            this.BatchId = BatchId;
            this.Error = Error;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/GetVersion/1.0")]
    public partial class GetVersionResponse_10 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string versionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("version");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetVersion_10OpRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetVersionRequest_1.0", Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/GetVersion/1.0", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("GetVersionRequest_1.0")]
        public object GetVersionRequest_10;
        
        public GetVersion_10OpRequest() {
        }
        
        public GetVersion_10OpRequest(object GetVersionRequest_10) {
            this.GetVersionRequest_10 = GetVersionRequest_10;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetVersion_10OpResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetVersionResponse_1.0", Namespace="http://Redcats/File/ESB-TIBCO/File/1.0/GetVersion/1.0", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("GetVersionResponse_1.0")]
        public safeprojectname.ServiceReference1.GetVersionResponse_10 GetVersionResponse_10;
        
        public GetVersion_10OpResponse() {
        }
        
        public GetVersion_10OpResponse(safeprojectname.ServiceReference1.GetVersionResponse_10 GetVersionResponse_10) {
            this.GetVersionResponse_10 = GetVersionResponse_10;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface portTypeChannel : safeprojectname.ServiceReference1.portType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class portTypeClient : System.ServiceModel.ClientBase<safeprojectname.ServiceReference1.portType>, safeprojectname.ServiceReference1.portType {
        
        public portTypeClient() {
        }
        
        public portTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public portTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public portTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public portTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        safeprojectname.ServiceReference1.InjectFileToOverride_10OpResponse safeprojectname.ServiceReference1.portType.InjectFileToOverride_10Op(safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest request) {
            return base.Channel.InjectFileToOverride_10Op(request);
        }
        
        public string InjectFileToOverride_10Op(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg) {
            safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest inValue = new safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest();
            inValue.EUserId = EUserId;
            inValue.ESystem = ESystem;
            inValue.FlowName = FlowName;
            inValue.FlowVersion = FlowVersion;
            inValue.FileName = FileName;
            inValue.FilePath = FilePath;
            inValue.NumberOfElements = NumberOfElements;
            inValue.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
            safeprojectname.ServiceReference1.InjectFileToOverride_10OpResponse retVal = ((safeprojectname.ServiceReference1.portType)(this)).InjectFileToOverride_10Op(inValue);
            return retVal.respParameter;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFileToOverride_10OpResponse> safeprojectname.ServiceReference1.portType.InjectFileToOverride_10OpAsync(safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest request) {
            return base.Channel.InjectFileToOverride_10OpAsync(request);
        }
        
        public System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFileToOverride_10OpResponse> InjectFileToOverride_10OpAsync(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg) {
            safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest inValue = new safeprojectname.ServiceReference1.InjectFileToOverride_10OpRequest();
            inValue.EUserId = EUserId;
            inValue.ESystem = ESystem;
            inValue.FlowName = FlowName;
            inValue.FlowVersion = FlowVersion;
            inValue.FileName = FileName;
            inValue.FilePath = FilePath;
            inValue.NumberOfElements = NumberOfElements;
            inValue.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
            return ((safeprojectname.ServiceReference1.portType)(this)).InjectFileToOverride_10OpAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        safeprojectname.ServiceReference1.InjectFile_10OpResponse safeprojectname.ServiceReference1.portType.InjectFile_10Op(safeprojectname.ServiceReference1.InjectFile_10OpRequest request) {
            return base.Channel.InjectFile_10Op(request);
        }
        
        public bool InjectFile_10Op(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg, System.Xml.XmlElement FunctionalValidationInformation, bool Overwrite, out string BatchId, out safeprojectname.ServiceReference1.ErrorType Error) {
            safeprojectname.ServiceReference1.InjectFile_10OpRequest inValue = new safeprojectname.ServiceReference1.InjectFile_10OpRequest();
            inValue.EUserId = EUserId;
            inValue.ESystem = ESystem;
            inValue.FlowName = FlowName;
            inValue.FlowVersion = FlowVersion;
            inValue.FileName = FileName;
            inValue.FilePath = FilePath;
            inValue.NumberOfElements = NumberOfElements;
            inValue.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
            inValue.FunctionalValidationInformation = FunctionalValidationInformation;
            inValue.Overwrite = Overwrite;
            safeprojectname.ServiceReference1.InjectFile_10OpResponse retVal = ((safeprojectname.ServiceReference1.portType)(this)).InjectFile_10Op(inValue);
            BatchId = retVal.BatchId;
            Error = retVal.Error;
            return retVal.processWithSuccess;
        }
        
        public System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFile_10OpResponse> InjectFile_10OpAsync(safeprojectname.ServiceReference1.InjectFile_10OpRequest request) {
            return base.Channel.InjectFile_10OpAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        safeprojectname.ServiceReference1.InjectFileFromKwai_10OpResponse safeprojectname.ServiceReference1.portType.InjectFileFromKwai_10Op(safeprojectname.ServiceReference1.InjectFileFromKwai_10OpRequest request) {
            return base.Channel.InjectFileFromKwai_10Op(request);
        }
        
        public bool InjectFileFromKwai_10Op(string EUserId, string ESystem, string FlowName, string FlowVersion, string FileName, string FilePath, int NumberOfElements, bool fileAttachedWithSoapMsg, System.Xml.XmlElement FunctionalValidationInformation, bool Overwrite, out string BatchId, out safeprojectname.ServiceReference1.ErrorType Error) {
            safeprojectname.ServiceReference1.InjectFileFromKwai_10OpRequest inValue = new safeprojectname.ServiceReference1.InjectFileFromKwai_10OpRequest();
            inValue.EUserId = EUserId;
            inValue.ESystem = ESystem;
            inValue.FlowName = FlowName;
            inValue.FlowVersion = FlowVersion;
            inValue.FileName = FileName;
            inValue.FilePath = FilePath;
            inValue.NumberOfElements = NumberOfElements;
            inValue.fileAttachedWithSoapMsg = fileAttachedWithSoapMsg;
            inValue.FunctionalValidationInformation = FunctionalValidationInformation;
            inValue.Overwrite = Overwrite;
            safeprojectname.ServiceReference1.InjectFileFromKwai_10OpResponse retVal = ((safeprojectname.ServiceReference1.portType)(this)).InjectFileFromKwai_10Op(inValue);
            BatchId = retVal.BatchId;
            Error = retVal.Error;
            return retVal.processWithSuccess;
        }
        
        public System.Threading.Tasks.Task<safeprojectname.ServiceReference1.InjectFileFromKwai_10OpResponse> InjectFileFromKwai_10OpAsync(safeprojectname.ServiceReference1.InjectFileFromKwai_10OpRequest request) {
            return base.Channel.InjectFileFromKwai_10OpAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        safeprojectname.ServiceReference1.GetVersion_10OpResponse safeprojectname.ServiceReference1.portType.GetVersion_10Op(safeprojectname.ServiceReference1.GetVersion_10OpRequest request) {
            return base.Channel.GetVersion_10Op(request);
        }
        
        public safeprojectname.ServiceReference1.GetVersionResponse_10 GetVersion_10Op(object GetVersionRequest_10) {
            safeprojectname.ServiceReference1.GetVersion_10OpRequest inValue = new safeprojectname.ServiceReference1.GetVersion_10OpRequest();
            inValue.GetVersionRequest_10 = GetVersionRequest_10;
            safeprojectname.ServiceReference1.GetVersion_10OpResponse retVal = ((safeprojectname.ServiceReference1.portType)(this)).GetVersion_10Op(inValue);
            return retVal.GetVersionResponse_10;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<safeprojectname.ServiceReference1.GetVersion_10OpResponse> safeprojectname.ServiceReference1.portType.GetVersion_10OpAsync(safeprojectname.ServiceReference1.GetVersion_10OpRequest request) {
            return base.Channel.GetVersion_10OpAsync(request);
        }
        
        public System.Threading.Tasks.Task<safeprojectname.ServiceReference1.GetVersion_10OpResponse> GetVersion_10OpAsync(object GetVersionRequest_10) {
            safeprojectname.ServiceReference1.GetVersion_10OpRequest inValue = new safeprojectname.ServiceReference1.GetVersion_10OpRequest();
            inValue.GetVersionRequest_10 = GetVersionRequest_10;
            return ((safeprojectname.ServiceReference1.portType)(this)).GetVersion_10OpAsync(inValue);
        }
    }
}