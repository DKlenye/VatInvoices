using System.Data;

namespace Naftan.VatInvoices
{
    public interface ICommand
    {
        void Execute(IDbConnection db, IDbTransaction tx);
    }
}
