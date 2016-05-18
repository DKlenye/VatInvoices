using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.QueryObjects
{
    public class InsertConsignor
    {
        public QueryObject Query(Consignor consignor)
        {
            return new QueryObject(@"
                INSERT INTO Consignors
                (
	                ConsignorCounteragentId,
	                InvoiceId,
	                CountryCode,
	                Unp,
	                Name,
	                [Address]
                )
                VALUES
                (
	               @ConsignorCounteragentId,
	               @InvoiceId,
	               @CountryCode,
	               @Unp,
	               @Name,
	               @Address
                ); select SCOPE_IDENTITY();
            ", new
             {
                 consignor.ConsignorCounteragentId,
                 consignor.InvoiceId,
                 consignor.CountryCode,
                 consignor.Unp,
                 consignor.Name,
                 consignor.Address
             });
        }
    }
}
