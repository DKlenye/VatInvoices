using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    public class Consignor
    {
        [DisplayName("Код")]
        public int ConsignorId { get; set; }

        [DisplayName("Код ЭСЧФ")]
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
