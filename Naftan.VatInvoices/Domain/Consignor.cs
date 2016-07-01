using System.ComponentModel;
using System.Xml.Serialization;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Грузополучатель
    /// </summary>
    public class Consignor : IVatInvoiceId
    {
        [DisplayName("Код"),XmlIgnore]
        public int Id { get; set; }

        [DisplayName("Код ЭСЧФ"),XmlIgnore]
        public int InvoiceId { get; set; }

        [DisplayName("Код грузополучателя")]
        public int? ConsignorCounteragentId { get; set; }

        [DisplayName("Код страны")]
        public int? CountryCode { get; set; }

        [DisplayName("УНП")]
        public string Unp { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Адрес доставки")]
        public string Address { get; set; }
    }
}
