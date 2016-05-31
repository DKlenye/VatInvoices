using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum invoiceDocType {
        
        /// <remarks/>
        [Description("Исходный")] ORIGINAL = 1,
        
        /// <remarks/>
         [Description("Дополнительный")] ADDITIONAL = 2,
        
        /// <remarks/>
        [Description("Исправленный")] FIXED = 3,
        
        /// <remarks/>
        [Description("Дополнительный без ссылки на ЭСЧФ")] ADD_NO_REFERENCE = 4,
    }
}