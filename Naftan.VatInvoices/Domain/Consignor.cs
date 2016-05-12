namespace Naftan.VatInvoices.Domain
{
    public class Consignor
    {
        public int ConsignorId { get; set; }
        public int InvoiceId { get; set; }
        public int? ConsignorCounteragentId { get; set; }
        public int? CountryCode { get; set; }
        public string Unp { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
