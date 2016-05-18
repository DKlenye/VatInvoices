using System.Collections.Generic;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    /// <summary>
    /// Сервис для работы с порталом МНС
    /// </summary>
    public interface IPortalService
    {
        /// <summary>
        /// Подписать и предать на портал налоговой иходящие ЭСЧФ
        /// </summary>
        /// <param name="invoice">ЭСЧФ для передачи</param>
        /// <returns></returns>
        IEnumerable<SignUpAndSendInfo> SignUpAndSend(params VatInvoice[] invoice);

        /// <summary>
        ///  Проверить статус ЭСЧФ на портале МНС
        /// </summary>
        /// <param name="invoice">ЭСЧФ для проверки статуса<</param>
        /// <returns></returns>
        IEnumerable<StatusInfo> CheckStatus(params VatInvoice[] invoice);
    }
}
