using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Статус ЭСЧФ
    /// </summary>
    public enum InvoiceStatus
    {
        [Description("В разработке")] A = 1,
        [Description("В разработке. Ошибка")] B = 2,
        [Description("Выставлен")] COMPLETED = 3,
        [Description("Выставлен. Подписан получателем")] COMPLETED_SIGNED = 4,
        [Description("Выставлен. Начато аннулирование")] E = 5,
        [Description("На согласовании")] F = 6,
        [Description("Аннулирован")] G = 7,
    }
}