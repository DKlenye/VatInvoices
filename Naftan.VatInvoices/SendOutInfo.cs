using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    public class SendOutInfo
    {
        public SendOutInfo(VatInvoice invoice, bool isException, string message, string xml = null, string signXml = null, InvoiceStatus? status = null)
        {
            Status = status;
            SignXml = signXml;
            Xml = xml;
            Invoice = invoice;
            Message = message;
            IsException = isException;
        }

        public VatInvoice Invoice { get; private set; }
        public bool IsException { get; private set; }
        public string Message { get; private set; }
        public string Xml { get; private set; }
        public string SignXml { get; private set; }
        public InvoiceStatus? Status { get; private set; }
    }
}