using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices
{
    /// <summary>
    /// Результат подписи и отправки ЭСЧФ
    /// </summary>
    public class SignUpAndSendRezult
    {
        public SignUpAndSendRezult(VatInvoiceDto invoice, string message, bool isException)
        {
            IsException = isException;
            Message = message;
            Invoice = invoice;
        }

        /// <summary>
        /// Признак ошибки
        /// </summary>
        public bool IsException { get; private set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// ЭСЧФ
        /// </summary>
        public VatInvoiceDto Invoice { get; private set; }
    }
}
