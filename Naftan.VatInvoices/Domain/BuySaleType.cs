using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    ///  Покупка \ Продажа
    /// </summary>
    public enum BuySaleType:short
    {
        [Description("покупка")] Buy = 1,
        [Description("продажа")] Sale = 2
    }
}