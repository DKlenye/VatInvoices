using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Статус ЭСЧФ
    /// </summary>
    public enum InvoiceStatus
    {
        [Description("В разработке")] IN_PROGRESS = 1,
        [Description("В разработке. Ошибка")] IN_PROGRESS_ERROR = 2,
        [Description("Выставлен")] COMPLETED = 3,
        [Description("Выставлен. Подписан получателем")] COMPLETED_SIGNED = 4,
        [Description("Выставлен. Аннулирован поставщиком")] ON_AGREEMENT_CANCEL = 5,
        [Description("На согласовании")] ON_AGREEMENT = 6,
        [Description("Аннулирован")] CANCELLED = 7
    }
}