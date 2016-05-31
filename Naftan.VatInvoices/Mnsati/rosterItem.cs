namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public partial class rosterItem {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string number;
        
        /// <remarks/>
        public string name;
        
        /// <remarks/>
        public string code;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string code_oced;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string units;
        
        /// <remarks/>
        public decimal count;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool countSpecified;
        
        /// <remarks/>
        public decimal price;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool priceSpecified;
        
        /// <remarks/>
        public decimal cost;
        
        /// <remarks/>
        public decimal summaExcise;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool summaExciseSpecified;
        
        /// <remarks/>
        public vat vat;
        
        /// <remarks/>
        public decimal costVat;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("description", IsNullable=false)]
        public descriptionType[] descriptions;
    }
}