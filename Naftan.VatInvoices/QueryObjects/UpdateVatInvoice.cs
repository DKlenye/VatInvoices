using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.QueryObjects
{
    public class UpdateVatInvoice
    {
        public QueryObject Query(VatInvoice invoice)
        {
            return new QueryObject(@"
                UPDATE VatInvoice 
	                SET 
                        ApproveDate = @ApproveDate,
                        ApproveUser=  @ApproveUser,
                        StatusId = @Status
                    WHERE 
                        InvoiceId = @InvoiceId
                ",
                new
                {
                    invoice.ApproveDate,
                    invoice.ApproveUser,
                    invoice.Status,
                    invoice.InvoiceId
                });
        }
    }
}
