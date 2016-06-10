using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoForCheckStatus:SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoForCheckStatus()
        {
            OutStatuses = new[]
            {
                InvoiceStatus.COMPLETED
            };

            InStatuses = new[]
            {
                InvoiceStatus.COMPLETED,
                InvoiceStatus.COMPLETED_SIGNED
            };
        }

        public InvoiceStatus[] OutStatuses { get; private set; }
        public InvoiceStatus[] InStatuses { get; private set; }
        
        protected override string Sql
        {
            get { return base.Sql + " WHERE (StatusId in @OutStatuses and IsIncome = 0) or (StatusId in @InStatuses and IsIncome = 1)"; }
        }

    }
}
