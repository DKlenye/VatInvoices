using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Naftan.VatInvoices.Queries
{
    public abstract class AbstractSqlQuery<T>:IQuery<IEnumerable<T>>
    {
        abstract protected string Sql { get; }

        public IEnumerable<T> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.Query<T>(Sql, new DynamicParameters(this), tx);
        }
    }
}
