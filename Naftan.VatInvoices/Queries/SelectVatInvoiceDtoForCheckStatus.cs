using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoForCheckStatus:SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoForCheckStatus()
        {
            Statuses = new []
            {
                InvoiceStatus.IN_PROGRESS, 
                InvoiceStatus.IN_PROGRESS_ERROR,
                InvoiceStatus.COMPLETED,
                InvoiceStatus.CANCELLED,
            };
        }

        public InvoiceStatus[] Statuses { get; private set; }

        protected override string Sql
        {
            get { return base.Sql + " WHERE  StatusId in @Statuses and IsIncome = 0"; }
        }

    }
}
