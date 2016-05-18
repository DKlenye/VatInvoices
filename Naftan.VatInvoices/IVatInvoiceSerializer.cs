using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    public interface IVatInvoiceSerializer
    {
        string Serialize(VatInvoice invoice);
        VatInvoice Deserialize(string xml);
    }
}
