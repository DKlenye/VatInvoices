namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class recipient {
        
        /// <remarks/>
        public recipientStatusType recipientStatus;
        
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
        public string declaration;
        
        /// <remarks/>
        public taxesType taxes;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime dateImport;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateImportSpecified;
        
        public recipient() {
            this.recipientStatus = recipientStatusType.CUSTOMER;
            this.dependentPerson = false;
            this.residentsOfOffshore = false;
            this.specialDealGoods = false;
            this.bigCompany = false;
        }
    }
}