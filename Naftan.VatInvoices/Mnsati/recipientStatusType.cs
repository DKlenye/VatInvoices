using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3schools.com")]
    public enum recipientStatusType
    {
        
        /// <summary>
        /// Покупатель
        /// </summary>
        [Description("Покупатель")] CUSTOMER = 1,

        /// <summary>
        /// Потребитель
        /// </summary>
        [Description("Потребитель")] CONSUMER = 2,

        /// <summary>
        /// Комитент
        /// </summary>
        [Description("Комитент")] CONSIGNOR = 3,

        /// <summary>
        /// Комиссионер
        /// </summary>
        [Description("Комиссионер")] COMMISSIONAIRE = 4,

        /// <summary>
        /// Покупатель, получающий налоговые вычеты
        /// </summary>
        [Description("Покупатель, получающий налоговые вычеты")] TAX_DEDUCTION_RECIPIENT = 5,

        /// <summary>
        /// Покупатель объектов у иностранной организации
        /// </summary>
        [Description("Покупатель объектов у иностранной организации")] FOREIGN_ORGANIZATION_BUYER = 6,

        /// <summary>
        /// Посредник
        /// </summary> 
        [Description("Посредник")] AGENT = 7,

        /// <summary>
        /// Плательщик, получающий обороты по реализации
        /// </summary>
        [Description("Плательщик, получающий обороты по реализации")] TURNOVERS_ON_SALE_RECIPIENT = 8

    }
}