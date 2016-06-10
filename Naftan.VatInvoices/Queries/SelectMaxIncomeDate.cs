using System;
using System.Data;
using System.Linq;
using Dapper;

namespace Naftan.VatInvoices.Queries
{
    public class SelectMaxIncomeDate:IQuery<DateTime>
    {
        public DateTime Execute(IDbConnection db, IDbTransaction tx)
        {
            var date = db.Query<DateTime?>(@"
            SELECT MAX(DateIssuance) FROM VatInvoice WHERE IsIncome = 1
            ",transaction:tx).FirstOrDefault();

            return date ?? DateTime.Now.AddDays(-31);
        }
    }
}
