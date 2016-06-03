namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoForValidate:SelectVatInvoiceDtoAll
    {
        protected override string Sql
        {
            get { return base.Sql + " WHERE IsValidate = 0 AND IsIncome = 0"; }
        }

    }
}
