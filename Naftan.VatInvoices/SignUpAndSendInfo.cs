using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    public class SignUpAndSendInfo
    {
        public SignUpAndSendInfo(VatInvoice invoice, bool isException, string message )
        {
            Invoice = invoice;
            Message = message;
            IsException = isException;
        }

        public VatInvoice Invoice { get; private set; }
        public bool IsException { get; private set; }
        public string Message { get; private set; }
    }
}