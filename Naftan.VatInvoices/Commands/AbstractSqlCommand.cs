using System.Data;
using Dapper;

namespace Naftan.VatInvoices.Commands
{
    public abstract class AbstractSqlCommand:ICommand
    {
        abstract protected string Sql { get; }
        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Execute(Sql, transaction: tx);
        }
    }
}
