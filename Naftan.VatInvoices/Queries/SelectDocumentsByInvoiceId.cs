using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectDocumentsByInvoiceId : AbstractSelectByInvoiceId<Document>
    {
        public SelectDocumentsByInvoiceId(int invoiceId) : base(invoiceId)
        {
        }
    }
}
    
