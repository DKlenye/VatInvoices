using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    public enum InvoiceType
    {
        [Description("Исходный")] ORIGINAL = 1,
        [Description("Дополнительный")] ADDITIONAL = 2,
        [Description("Исправленный")] FIXED = 3,
        [Description("Дополнительный без ссылки на ЭСЧФ")] ADD_NO_REFERENCE = 4,
    }
}
