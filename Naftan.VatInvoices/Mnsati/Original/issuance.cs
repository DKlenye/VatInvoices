namespace Naftan.VatInvoices.Mnsati.Original
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.w3schools.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.w3schools.com", IsNullable=false)]
    public partial class issuance {
        
        /// <remarks/>
        public general general;
        
        /// <remarks/>
        public provider provider;
        
        /// <remarks/>
        public recipient recipient;
        
        /// <remarks/>
        public senderReceiver senderReceiver;
        
        /// <remarks/>
        public deliveryCondition deliveryCondition;
        
        /// <remarks/>
        public rosterList roster;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sender;
    }
}