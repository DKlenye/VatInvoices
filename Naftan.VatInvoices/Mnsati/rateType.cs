using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3schools.com")]
    public enum rateType
    {

        /// <remarks/>
        [Description("фиксированная")] DECIMAL = 1,

        /// <remarks/>
        [Description("0%")] ZERO = 2,

        /// <remarks/>
        [Description("без ндс")] NO_VAT = 3,

        /// <remarks/>
        [Description("расчетная")] CALCULATED = 4,
    }
}