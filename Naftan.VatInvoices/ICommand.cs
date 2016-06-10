using System.Data;

namespace Naftan.VatInvoices
{
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="db">Подключение</param>
        /// <param name="tx">Транзакция</param>
        void Execute(IDbConnection db, IDbTransaction tx);
    }
}
