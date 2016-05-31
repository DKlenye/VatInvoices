using System.Data;

namespace Naftan.VatInvoices.Impl
{
    public class Database : IDatabase
    {
        private readonly IDbConnection db;
        private IDbTransaction tx;

        private IDbTransaction transaction
        {
            get
            {
                if (tx == null)
                {
                    db.Open();
                    tx = db.BeginTransaction();
                }
                return tx;
            }
        }
            
        public Database(IDbConnection db)
        {
            this.db = db;
        }

        public T Execute<T>(IQuery<T> query)
        {
            return query.Execute(db,transaction);
        }

        public void Execute(ICommand command)
        {
            command.Execute(db,transaction);
        }

        public void Commit()
        {
            if (tx != null)
            {
                tx.Commit();
                tx.Dispose();
                tx = null;
                db.Close();
            }
        }
    }
}
