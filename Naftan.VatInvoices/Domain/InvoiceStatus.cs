using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Статус ЭСЧФ
    /// </summary>
    public enum InvoiceStatus
    {

        /// <summary>
        /// В разработке
        /// </summary>
        [Description("В разработке")] IN_PROGRESS = 1,
        /// <summary>
        /// В разработке. Ошибка
        /// </summary>
        [Description("В разработке. Ошибка")] IN_PROGRESS_ERROR = 2,
        /// <summary>
        /// Выставлен
        /// </summary>
        [Description("Выставлен")] COMPLETED = 3,
        /// <summary>
        /// Выставлен. Подписан получателем
        /// </summary>
        [Description("Выставлен. Подписан получателем")] COMPLETED_SIGNED = 4,
        /// <summary>
        /// Выставлен. Аннулирован поставщиком
        /// </summary>
        [Description("Выставлен. Аннулирован поставщиком")] ON_AGREEMENT_CANCEL = 5,
        /// <summary>
        /// На согласовании
        /// </summary>
        [Description("На согласовании")] ON_AGREEMENT = 6,
        /// <summary>
        /// Аннулирован
        /// </summary>
        [Description("Аннулирован")] CANCELLED = 7
    }
}