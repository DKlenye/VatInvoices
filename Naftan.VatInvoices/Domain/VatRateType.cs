using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    public enum VatRateType
    {
        [Description("фиксированная")] DECIMAL = 1,
        [Description("0%")] ZERO = 2,
        [Description("без ндс")] NO_VAT = 3,
        [Description("расчетная")] CALCULATED = 4

    }
}

