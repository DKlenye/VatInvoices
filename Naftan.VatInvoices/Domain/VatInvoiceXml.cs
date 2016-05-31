namespace Naftan.VatInvoices.Domain
{
    public class VatInvoiceXml : IVatInvoiceId
    {
        public int InvoiceId { get; set; }
        public string Xml { get; set; }
        public string SignXml { get; set; }
        public string Sign2Xml { get; set; }
    }
}
