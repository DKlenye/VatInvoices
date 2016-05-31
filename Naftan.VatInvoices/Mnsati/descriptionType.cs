using System.ComponentModel;

namespace Naftan.VatInvoices.Mnsati
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3schools.com")]
    public enum descriptionType
    {

        /// <remarks/>
        [Description("Вычет в полном объёме")] DEDUCTION_IN_FULL = 1,

        /// <remarks/>
        [Description("Освобождение от НДС")] VAT_EXEMPTION = 2,

        /// <remarks/>
        [Description("Реализация за пределами РБ")] OUTSIDE_RB = 3,

        /// <remarks/>
        [Description("Ввозной НДС")] IMPORT_VAT = 4,
    }
}