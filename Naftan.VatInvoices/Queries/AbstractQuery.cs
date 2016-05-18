using System.Data;

namespace Naftan.VatInvoices.Queries
{
   public abstract class AbstractQuery<TResult>
    {
        protected AbstractQuery(IDbConnection connection)
        {
            Connection = connection;
        }

        protected IDbConnection Connection { get; set; }

        public abstract TResult Query();
    }
}
