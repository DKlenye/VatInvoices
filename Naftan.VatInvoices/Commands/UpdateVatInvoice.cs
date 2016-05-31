using System.Data;
using Dapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class UpdateVatInvoice:ICommand
    {
        public UpdateVatInvoice(VatInvoice invoice)
        {
            Invoice = invoice;
        }

        public VatInvoice Invoice { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            var param = new DynamicParameters(Invoice);

            db.Execute(@"
             UPDATE VatInvoice 
	            SET 
                ApproveDate = @ApproveDate,
                ApproveUser=  @ApproveUser,
                ApproveDateExport = @ApproveDateExport,
                StatusId = @Status,
                StatusMessage = @StatusMessage
            WHERE 
                InvoiceId = @InvoiceId", param, tx);
        }
    }
}
