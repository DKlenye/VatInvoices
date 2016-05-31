using System.Data;

namespace Naftan.VatInvoices
{
    public interface IQuery<T>
    {
        T Execute(IDbConnection db, IDbTransaction tx);
    }
}
