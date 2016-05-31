using System.Collections.Generic;
using System.Data;
using Dapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectAccountListByPeriod:IQuery<IEnumerable<AccountList>>
    {
        public SelectAccountListByPeriod(DatePeriod period)
        {
            Year = period.Year;
            Month = period.Month;
        }

        public int Year { get; private set; }
        public int Month { get; private set; }

        public IEnumerable<AccountList> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.Query<AccountList>(@"
                exec spu_Accounts_List @Month,@Year,'90,91,58,18,60'
            ", new DynamicParameters(this),tx);
        }
    }
}
