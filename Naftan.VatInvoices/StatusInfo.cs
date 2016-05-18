using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    public class StatusInfo
    {
        public StatusInfo(VatInvoice invoice, string status, string message, string since)
        {
            Invoice = invoice;
            Since = since;
            Message = message;
            Status = status;
        }

        public VatInvoice Invoice { get; private set; }
        public string Status { get; private set; }
        public string Message { get; private set; }
        public string Since { get; private set; }
    }
}
