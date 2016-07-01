using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    ///  Покупка \ Продажа
    /// </summary>
    public enum BuySaleType:short
    {
        /// <summary>
        /// покупка
        /// </summary>
        [Description("покупка")] Buy = 1,
        /// <summary>
        /// продажа
        /// </summary>
        [Description("продажа")] Sale = 2,
        /// <summary>
        /// продажа
        /// </summary>
        [Description("возмещение")] Compensation = 3
    }
}