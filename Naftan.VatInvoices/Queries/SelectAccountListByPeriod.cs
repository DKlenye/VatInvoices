using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectAccountListByPeriod : AbstractSqlQuery<AccountList>
    {
        public SelectAccountListByPeriod(DatePeriod period)
        {
            Year = period.Year;
            Month = period.Month;
        }

        public int Year { get; private set; }
        public int Month { get; private set; }

        protected override string Sql
        {
            get { return "exec spu_Accounts_List @Month,@Year,'90,91,58,18,60'"; }
        }

    }
}
