using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3schools.com")]
    public enum providerStatusType {
        
        /// <remarks/>
       [Description("Продавец")] SELLER = 1,
        
        /// <remarks/>
       [Description("Комитент")] CONSIGNOR = 2,
        
        /// <remarks/>
       [Description("Комиссионер")] COMMISSIONAIRE=3,
        
        /// <remarks/>
        [Description("Плательщик")]  TAX_DEDUCTION_PAYER=4,
        
        /// <remarks/>
        [Description("Доверительный")] TRUSTEE=5,
        
        /// <remarks/>
        [Description("Иностранная организация")] FOREIGN_ORGANIZATION=6,
        
        /// <remarks/>
       [Description("Посредник")] AGENT=7,
        
        /// <remarks/>
       [Description("Заказчик (застройщик)")] DEVELOPER=8
    }
}