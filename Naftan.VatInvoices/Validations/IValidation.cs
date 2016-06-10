using System.Collections.Generic;

namespace Naftan.VatInvoices.Validations
{
    public interface IValidation<T>
    {
        IList<string> Validate(T obj);
    }
}
