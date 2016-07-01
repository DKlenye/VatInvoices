namespace Naftan.VatInvoices.Dto
{
    public class AddVatInvoiceRezult
    {
        public bool IsException { get; set; }
        public string Message { get; set; }
        public string VatInvoiceNumber { get; set; }
        public int VatInvoiceId { get; set; }
    }
}
