using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.QueryObjects
{
    public class InsertRoster
    {
        public QueryObject Query(Roster roster)
        {
            return new QueryObject(@"
            INSERT INTO RosterList
            (
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
	            VatRateTypeId,
	            SummaVat,
	            CostVat,
	            [Description]
            )
            VALUES
            (
	            @InvoiceId,
	            @Number,
	            @Name,
	            @Code,
	            @CodeOced,
	            @Units,
	            @Count,
	            @Price,
	            @Cost,
	            @SummaExcise,
	            @VatRate,
	            @VatRateType,
	            @SummaVat,
	            @CostVat,
	            @Description
            ); select SCOPE_IDENTITY();
            ", new
            {
                roster.InvoiceId,
                roster.Number,
                roster.Name,
                roster.Code,
                roster.CodeOced,
                roster.Units,
                roster.Count,
                roster.Price,
                roster.Cost,
                roster.SummaExcise,
                roster.VatRate,
                roster.VatRateType,
                roster.SummaVat,
                roster.CostVat,
                roster.Description
            });
        }
    }
}
