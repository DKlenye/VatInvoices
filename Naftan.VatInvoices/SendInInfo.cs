using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    public class SendInInfo
    {
        public SendInInfo(VatInvoiceXml invoiceXml, bool isException, string message)
        {
            InvoiceXml = invoiceXml;
            Message = message;
            IsException = isException;
        }

        public VatInvoiceXml InvoiceXml { get; private set; }
        public bool IsException { get; private set; }
        public string Message { get; private set; }
    }
}
