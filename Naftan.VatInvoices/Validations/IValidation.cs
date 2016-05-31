namespace Naftan.VatInvoices.Validations
{
    public interface IValidation<T>
    {
        bool IsValid(T obj);
    }
}
