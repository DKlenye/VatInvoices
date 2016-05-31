namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class provider {
        
        /// <remarks/>
        public providerStatusType providerStatus;
        
        /// <remarks/>
        public bool dependentPerson;
        
        /// <remarks/>
        public bool residentsOfOffshore;
        
        /// <remarks/>
        public bool specialDealGoods;
        
        /// <remarks/>
        public bool bigCompany;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string countryCode;
        
        /// <remarks/>
        public string unp;
        
        /// <remarks/>
        public string branchCode;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string address;
        
        /// <remarks/>
        public forInvoiceType principal;
        
        /// <remarks/>
        public forInvoiceType vendor;
        
        /// <remarks/>
        public string declaration;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateRelease;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateReleaseSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateActualExport;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateActualExportSpecified;
        
        /// <remarks/>
        public taxesType taxes;
        
        public provider() {
            this.providerStatus = providerStatusType.SELLER;
            this.dependentPerson = false;
            this.residentsOfOffshore = false;
            this.specialDealGoods = false;
            this.bigCompany = false;
        }
    }
}