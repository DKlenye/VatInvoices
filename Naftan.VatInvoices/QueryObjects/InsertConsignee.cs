using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.QueryObjects
{
    public class InsertConsignee
    {
        public QueryObject Query(Consignee consignee)
        {
            return new QueryObject(@"
                INSERT INTO Consignees
                (
	                ConsigneeCounteragentId,
	                InvoiceId,
	                CountryCode,
	                Unp,
	                Name,
	                [Address]
                )
                VALUES
                (
	               @ConsigneeCounteragentId,
	               @InvoiceId,
	               @CountryCode,
	               @Unp,
	               @Name,
	               @Address
                ); select SCOPE_IDENTITY();
            ",new
            {
                consignee.ConsigneeCounteragentId,
                consignee.InvoiceId,
                consignee.CountryCode,
                consignee.Unp,
                consignee.Name,
                consignee.Address
            });
        }
    }
}
