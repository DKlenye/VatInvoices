using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    public enum RosterDescription
    {
        [Description("Вычет в полном объёме")] DEDUCTION_IN_FULL = 1,
        [Description("Освобождение от НДС")] VAT_EXEMPTION = 2,
        [Description("Реализация за пределами РБ")] OUTSIDE_RB = 3,
        [Description("Ввозной НДС")] IMPORT_VAT = 4,
    }
}