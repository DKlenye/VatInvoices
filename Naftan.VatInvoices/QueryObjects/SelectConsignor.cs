using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.QueryObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectConsignor
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
	            ConsignorCounteragentId,
	            InvoiceId,
	            CountryCode,
	            Unp,
	            Name,
	            [Address]
            FROM Consignors");
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
