using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.QueryObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectRoster
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
	            InvoiceId,
	            Number,
	            Name,
	            Code,
	            CodeOced,
	            Units,
	            [Count],
	            Price,
	            Cost,
	            SummaExcise,
	            VatRate,
	            VatRateTypeId ,
	            SummaVat,
	            CostVat,
	            [Description] 
            FROM RosterList
            ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public QueryObject ByInvoiceId(int invoiceId)
        {
            return new QueryObject(All().Sql + " WHERE InvoiceId = {invoiceId}".ApplyTemplate(new {invoiceId}));
        }

    }
}
