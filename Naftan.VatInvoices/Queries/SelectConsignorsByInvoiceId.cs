using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectConsignorsByInvoiceId:AbstractSelectByInvoiceId<Consignor>
    {
        public SelectConsignorsByInvoiceId(int invoiceId) : base(invoiceId)
        {
        }
    }
}
