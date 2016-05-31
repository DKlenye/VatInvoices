namespace Naftan.VatInvoices.Converters
{
    public interface IConverter<Type1,Type2>
    {
        Type1 To(Type2 obj);
        Type2 From(Type1 obj);
    }
}
