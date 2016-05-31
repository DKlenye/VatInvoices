using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectConsigneesByInvoiceId:AbstractSelectByInvoiceId<Consignee>
    {
        public SelectConsigneesByInvoiceId(int invoiceId) : base(invoiceId)
        {
        }
    }
}
