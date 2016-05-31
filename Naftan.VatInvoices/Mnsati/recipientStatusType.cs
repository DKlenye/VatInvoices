using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3schools.com")]
    public enum recipientStatusType
    {

        /// <remarks/>
        [Description("Покупатель")] CUSTOMER = 1,

        /// <remarks/>
        [Description("Потребитель")] CONSUMER = 2,

        /// <remarks/>
        [Description("Комитент")] CONSIGNOR = 3,

        /// <remarks/>
        [Description("Комиссионер")] COMMISSIONAIRE = 4,

        /// <remarks/>
        [Description("Покупатель, получающий налоговые вычеты")] TAX_DEDUCTION_RECIPIENT = 5,

        /// <remarks/>
        [Description("Покупатель объектов у иностранной организации")] FOREIGN_ORGANIZATION_BUYER = 6,
    }
}