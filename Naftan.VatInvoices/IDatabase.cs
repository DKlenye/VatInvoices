namespace Naftan.VatInvoices
{
    public interface IDatabase
    {
        T Execute<T>(IQuery<T> query);
        void Execute(ICommand command);
        void Commit();
    }
}
