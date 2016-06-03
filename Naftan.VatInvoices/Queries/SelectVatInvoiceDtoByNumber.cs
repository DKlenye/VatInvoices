namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoByNumber:SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoByNumber(string numberString)
        {
            NumberString = numberString;
        }

        public string NumberString { get; private set; }

        protected override string Sql
        {
            get
            {
                return base.Sql + " where NumberString = @NumberString";
            }
        }
    }
}
