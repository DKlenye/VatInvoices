using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceXmlByInvoiceId:AbstractSelectByInvoiceId<VatInvoiceXml>
    {
        public SelectVatInvoiceXmlByInvoiceId(int invoiceId) : base(invoiceId)
        {
        }
    }
}
