using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum providerStatusType {
        
        
       /// <summary>
        /// Продавец
       /// </summary>
       [Description("Продавец")] SELLER = 1,

       /// <summary>
       /// Комитент
       /// </summary>
       [Description("Комитент")] CONSIGNOR = 2,

       /// <summary>
       /// Комиссионер
       /// </summary>
       [Description("Комиссионер")] COMMISSIONAIRE=3,

       /// <summary>
       /// Плательщик
       /// </summary>
        [Description("Плательщик")]  TAX_DEDUCTION_PAYER=4,

        /// <summary>
        /// Доверительный
        /// </summary>
        [Description("Доверительный")] TRUSTEE=5,

        /// <summary>
        /// Иностранная организация
        /// </summary>
        [Description("Иностранная организация")] FOREIGN_ORGANIZATION=6,

        /// <summary>
        /// Посредник
        /// </summary>
       [Description("Посредник")] AGENT=7,

       /// <summary>
       /// Заказчик (застройщик)
       /// </summary>
       [Description("Заказчик (застройщик)")] DEVELOPER=8,

        /// <summary>
       /// Плательщик, передающий обороты по реализации
       /// </summary>
       [Description("Плательщик, передающий обороты по реализации")]TURNOVERS_ON_SALE_PAYER = 9

    }
}