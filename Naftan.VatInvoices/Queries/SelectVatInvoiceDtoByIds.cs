namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoByIds : SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoByIds(params int[] id)
        {
            Id = id;
        }

        public int[] Id { get; private set; }

        protected override string Sql
        {
            get { return base.Sql + " WHERE InvoiceId in @Id"; }
        }
    }
}
