using System.Data;
using DapperExtensions;

namespace Naftan.VatInvoices.Commands
{
    public abstract class AbstractInsertCommand<T>:ICommand
        where T:class 
    {
        protected AbstractInsertCommand(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Insert(Entity, tx);
        }
    }
}
