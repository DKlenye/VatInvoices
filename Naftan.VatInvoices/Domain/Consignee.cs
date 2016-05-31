using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Грузоотправитель
    /// </summary>
    public class Consignee : IVatInvoiceId
    {
        [DisplayName("Код")]
        public int Id { get; set; }

        [DisplayName("Код ЭСЧФ")]
        public int InvoiceId { get; set; }

        [DisplayName("Код грузоотправителя")]
        public int? ConsigneeCounteragentId { get; set; }

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
