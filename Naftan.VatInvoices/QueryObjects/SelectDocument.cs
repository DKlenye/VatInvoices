using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.QueryObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectDocument
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public QueryObject All()
        {
            return new QueryObject(@"
            SELECT 
	            Id,
	            ReplicationId,
	            InvoiceId,
	            DocTypeCode,
	            DocTypeValue,
	            BlancCode,
	            Number,
	            Seria,
	            [Date]
            FROM Documents");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public QueryObject ByInvoiceId(int invoiceId)
        {
            return new QueryObject(All().Sql + " WHERE InvoiceId = {invoiceId}".ApplyTemplate(new { invoiceId }));
        }
    }
}
