using System.Data;
using DapperExtensions;

namespace Naftan.VatInvoices.Commands
{
    public class AbstractUpdateCommand<T>:ICommand
        where T:class 
    {
        public AbstractUpdateCommand(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Update(Entity, tx);
        }

    }
}
