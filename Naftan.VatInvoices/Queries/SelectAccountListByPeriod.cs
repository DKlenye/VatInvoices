using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectAccountListByPeriod : AbstractSqlQuery<AccountList>
    {
        public SelectAccountListByPeriod(DatePeriod period, string accounts)
        {
            Accounts = accounts;
            Year = period.Year;
            Month = period.Month;
        }

        public int Year { get; private set; }
        public int Month { get; private set; }
        public string Accounts { get; private set; }

        protected override string Sql
        {
            get { return "exec spu_Accounts_List @Month,@Year, @Accounts"; }
        }

    }
}
