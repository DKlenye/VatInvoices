namespace Naftan.VatInvoices.Domain
{
    public class Consignee
    {
        public int ConsigneeId { get; set; }
        public int InvoiceId { get; set; }
        public int? ConsigneeCounteragentId { get; set; }
        public int? CountryCode { get; set; }
        public string Unp { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
