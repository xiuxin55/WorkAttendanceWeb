﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Winsoft.Web.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseModel", Namespace="http://schemas.datacontract.org/2004/07/BusinessModel")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Winsoft.Web.ServiceReference1.StatisticsModel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Winsoft.Web.ServiceReference1.WorkAttendanceInfo))]
    public partial class BaseModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EndIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSelectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderbyColomnNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RowNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StartIndexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubOrderbyColomnNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EndIndex {
            get {
                return this.EndIndexField;
            }
            set {
                if ((this.EndIndexField.Equals(value) != true)) {
                    this.EndIndexField = value;
                    this.RaisePropertyChanged("EndIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSelected {
            get {
                return this.IsSelectedField;
            }
            set {
                if ((this.IsSelectedField.Equals(value) != true)) {
                    this.IsSelectedField = value;
                    this.RaisePropertyChanged("IsSelected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderbyColomnName {
            get {
                return this.OrderbyColomnNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderbyColomnNameField, value) != true)) {
                    this.OrderbyColomnNameField = value;
                    this.RaisePropertyChanged("OrderbyColomnName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RowNumber {
            get {
                return this.RowNumberField;
            }
            set {
                if ((this.RowNumberField.Equals(value) != true)) {
                    this.RowNumberField = value;
                    this.RaisePropertyChanged("RowNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int StartIndex {
            get {
                return this.StartIndexField;
            }
            set {
                if ((this.StartIndexField.Equals(value) != true)) {
                    this.StartIndexField = value;
                    this.RaisePropertyChanged("StartIndex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SubOrderbyColomnName {
            get {
                return this.SubOrderbyColomnNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SubOrderbyColomnNameField, value) != true)) {
                    this.SubOrderbyColomnNameField = value;
                    this.RaisePropertyChanged("SubOrderbyColomnName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="StatisticsModel", Namespace="http://schemas.datacontract.org/2004/07/BusinessModel")]
    [System.SerializableAttribute()]
    public partial class StatisticsModel : Winsoft.Web.ServiceReference1.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ConfirmStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ReviewStateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> StatisticsEndtimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> StatisticsStarttimeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ConfirmState {
            get {
                return this.ConfirmStateField;
            }
            set {
                if ((this.ConfirmStateField.Equals(value) != true)) {
                    this.ConfirmStateField = value;
                    this.RaisePropertyChanged("ConfirmState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ReviewState {
            get {
                return this.ReviewStateField;
            }
            set {
                if ((this.ReviewStateField.Equals(value) != true)) {
                    this.ReviewStateField = value;
                    this.RaisePropertyChanged("ReviewState");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> StatisticsEndtime {
            get {
                return this.StatisticsEndtimeField;
            }
            set {
                if ((this.StatisticsEndtimeField.Equals(value) != true)) {
                    this.StatisticsEndtimeField = value;
                    this.RaisePropertyChanged("StatisticsEndtime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> StatisticsStarttime {
            get {
                return this.StatisticsStarttimeField;
            }
            set {
                if ((this.StatisticsStarttimeField.Equals(value) != true)) {
                    this.StatisticsStarttimeField = value;
                    this.RaisePropertyChanged("StatisticsStarttime");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WorkAttendanceInfo", Namespace="http://schemas.datacontract.org/2004/07/BusinessModel")]
    [System.SerializableAttribute()]
    public partial class WorkAttendanceInfo : Winsoft.Web.ServiceReference1.BaseModel {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AbsenceCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AbsenceTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AffairLeaveCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AffairLeaveTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AnnualleaveCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double AnnualleaveTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double BelateCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double BelateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double BussinessstripTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double CommonWorkTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataEndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DataStartTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsFullTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LeaveTotalTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LeftAnnualleaveTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LeftearlyCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LeftearlyTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double OvertimeTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double RealOvertimeTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double RealWorkTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SecondOvertimeTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SickleaveCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double SickleaveTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StaffCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StaffNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AbsenceCount {
            get {
                return this.AbsenceCountField;
            }
            set {
                if ((this.AbsenceCountField.Equals(value) != true)) {
                    this.AbsenceCountField = value;
                    this.RaisePropertyChanged("AbsenceCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AbsenceTime {
            get {
                return this.AbsenceTimeField;
            }
            set {
                if ((this.AbsenceTimeField.Equals(value) != true)) {
                    this.AbsenceTimeField = value;
                    this.RaisePropertyChanged("AbsenceTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AffairLeaveCount {
            get {
                return this.AffairLeaveCountField;
            }
            set {
                if ((this.AffairLeaveCountField.Equals(value) != true)) {
                    this.AffairLeaveCountField = value;
                    this.RaisePropertyChanged("AffairLeaveCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AffairLeaveTime {
            get {
                return this.AffairLeaveTimeField;
            }
            set {
                if ((this.AffairLeaveTimeField.Equals(value) != true)) {
                    this.AffairLeaveTimeField = value;
                    this.RaisePropertyChanged("AffairLeaveTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AnnualleaveCount {
            get {
                return this.AnnualleaveCountField;
            }
            set {
                if ((this.AnnualleaveCountField.Equals(value) != true)) {
                    this.AnnualleaveCountField = value;
                    this.RaisePropertyChanged("AnnualleaveCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double AnnualleaveTime {
            get {
                return this.AnnualleaveTimeField;
            }
            set {
                if ((this.AnnualleaveTimeField.Equals(value) != true)) {
                    this.AnnualleaveTimeField = value;
                    this.RaisePropertyChanged("AnnualleaveTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double BelateCount {
            get {
                return this.BelateCountField;
            }
            set {
                if ((this.BelateCountField.Equals(value) != true)) {
                    this.BelateCountField = value;
                    this.RaisePropertyChanged("BelateCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double BelateTime {
            get {
                return this.BelateTimeField;
            }
            set {
                if ((this.BelateTimeField.Equals(value) != true)) {
                    this.BelateTimeField = value;
                    this.RaisePropertyChanged("BelateTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double BussinessstripTime {
            get {
                return this.BussinessstripTimeField;
            }
            set {
                if ((this.BussinessstripTimeField.Equals(value) != true)) {
                    this.BussinessstripTimeField = value;
                    this.RaisePropertyChanged("BussinessstripTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double CommonWorkTime {
            get {
                return this.CommonWorkTimeField;
            }
            set {
                if ((this.CommonWorkTimeField.Equals(value) != true)) {
                    this.CommonWorkTimeField = value;
                    this.RaisePropertyChanged("CommonWorkTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataEndTime {
            get {
                return this.DataEndTimeField;
            }
            set {
                if ((this.DataEndTimeField.Equals(value) != true)) {
                    this.DataEndTimeField = value;
                    this.RaisePropertyChanged("DataEndTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DataStartTime {
            get {
                return this.DataStartTimeField;
            }
            set {
                if ((this.DataStartTimeField.Equals(value) != true)) {
                    this.DataStartTimeField = value;
                    this.RaisePropertyChanged("DataStartTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsFullTime {
            get {
                return this.IsFullTimeField;
            }
            set {
                if ((this.IsFullTimeField.Equals(value) != true)) {
                    this.IsFullTimeField = value;
                    this.RaisePropertyChanged("IsFullTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LeaveTotalTime {
            get {
                return this.LeaveTotalTimeField;
            }
            set {
                if ((this.LeaveTotalTimeField.Equals(value) != true)) {
                    this.LeaveTotalTimeField = value;
                    this.RaisePropertyChanged("LeaveTotalTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LeftAnnualleaveTime {
            get {
                return this.LeftAnnualleaveTimeField;
            }
            set {
                if ((this.LeftAnnualleaveTimeField.Equals(value) != true)) {
                    this.LeftAnnualleaveTimeField = value;
                    this.RaisePropertyChanged("LeftAnnualleaveTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LeftearlyCount {
            get {
                return this.LeftearlyCountField;
            }
            set {
                if ((this.LeftearlyCountField.Equals(value) != true)) {
                    this.LeftearlyCountField = value;
                    this.RaisePropertyChanged("LeftearlyCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double LeftearlyTime {
            get {
                return this.LeftearlyTimeField;
            }
            set {
                if ((this.LeftearlyTimeField.Equals(value) != true)) {
                    this.LeftearlyTimeField = value;
                    this.RaisePropertyChanged("LeftearlyTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double OvertimeTime {
            get {
                return this.OvertimeTimeField;
            }
            set {
                if ((this.OvertimeTimeField.Equals(value) != true)) {
                    this.OvertimeTimeField = value;
                    this.RaisePropertyChanged("OvertimeTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double RealOvertimeTime {
            get {
                return this.RealOvertimeTimeField;
            }
            set {
                if ((this.RealOvertimeTimeField.Equals(value) != true)) {
                    this.RealOvertimeTimeField = value;
                    this.RaisePropertyChanged("RealOvertimeTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double RealWorkTime {
            get {
                return this.RealWorkTimeField;
            }
            set {
                if ((this.RealWorkTimeField.Equals(value) != true)) {
                    this.RealWorkTimeField = value;
                    this.RaisePropertyChanged("RealWorkTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SecondOvertimeTime {
            get {
                return this.SecondOvertimeTimeField;
            }
            set {
                if ((this.SecondOvertimeTimeField.Equals(value) != true)) {
                    this.SecondOvertimeTimeField = value;
                    this.RaisePropertyChanged("SecondOvertimeTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SickleaveCount {
            get {
                return this.SickleaveCountField;
            }
            set {
                if ((this.SickleaveCountField.Equals(value) != true)) {
                    this.SickleaveCountField = value;
                    this.RaisePropertyChanged("SickleaveCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double SickleaveTime {
            get {
                return this.SickleaveTimeField;
            }
            set {
                if ((this.SickleaveTimeField.Equals(value) != true)) {
                    this.SickleaveTimeField = value;
                    this.RaisePropertyChanged("SickleaveTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StaffCode {
            get {
                return this.StaffCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.StaffCodeField, value) != true)) {
                    this.StaffCodeField = value;
                    this.RaisePropertyChanged("StaffCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StaffName {
            get {
                return this.StaffNameField;
            }
            set {
                if ((object.ReferenceEquals(this.StaffNameField, value) != true)) {
                    this.StaffNameField = value;
                    this.RaisePropertyChanged("StaffName");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IWorkAttendanceInfoService")]
    public interface IWorkAttendanceInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkAttendanceInfoService/Add", ReplyAction="http://tempuri.org/IWorkAttendanceInfoService/AddResponse")]
        bool Add(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkAttendanceInfoService/Update", ReplyAction="http://tempuri.org/IWorkAttendanceInfoService/UpdateResponse")]
        bool Update(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkAttendanceInfoService/Delete", ReplyAction="http://tempuri.org/IWorkAttendanceInfoService/DeleteResponse")]
        bool Delete(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkAttendanceInfoService/Select", ReplyAction="http://tempuri.org/IWorkAttendanceInfoService/SelectResponse")]
        Winsoft.Web.ServiceReference1.WorkAttendanceInfo[] Select(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWorkAttendanceInfoService/GetWorkAttendanceInfoByTime", ReplyAction="http://tempuri.org/IWorkAttendanceInfoService/GetWorkAttendanceInfoByTimeResponse" +
            "")]
        Winsoft.Web.ServiceReference1.WorkAttendanceInfo[] GetWorkAttendanceInfoByTime(Winsoft.Web.ServiceReference1.StatisticsModel model);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWorkAttendanceInfoServiceChannel : Winsoft.Web.ServiceReference1.IWorkAttendanceInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WorkAttendanceInfoServiceClient : System.ServiceModel.ClientBase<Winsoft.Web.ServiceReference1.IWorkAttendanceInfoService>, Winsoft.Web.ServiceReference1.IWorkAttendanceInfoService {
        
        public WorkAttendanceInfoServiceClient() {
        }
        
        public WorkAttendanceInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WorkAttendanceInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkAttendanceInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WorkAttendanceInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Add(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info) {
            return base.Channel.Add(info);
        }
        
        public bool Update(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info) {
            return base.Channel.Update(info);
        }
        
        public bool Delete(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info) {
            return base.Channel.Delete(info);
        }
        
        public Winsoft.Web.ServiceReference1.WorkAttendanceInfo[] Select(Winsoft.Web.ServiceReference1.WorkAttendanceInfo info) {
            return base.Channel.Select(info);
        }
        
        public Winsoft.Web.ServiceReference1.WorkAttendanceInfo[] GetWorkAttendanceInfoByTime(Winsoft.Web.ServiceReference1.StatisticsModel model) {
            return base.Channel.GetWorkAttendanceInfoByTime(model);
        }
    }
}
