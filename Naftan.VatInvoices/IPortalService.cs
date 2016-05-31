using System;
using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices
{
    /// <summary>
    /// Сервис для работы с порталом МНС
    /// </summary>
    public interface IPortalService
    {
        /// <summary>
        /// Подписать и передать на портал налоговой иходящие ЭСЧФ
        /// </summary>
        /// <param name="invoice">ЭСЧФ для передачи</param>
        /// <returns></returns>
        IEnumerable<SendOutInfo> SignAndSendOut(params VatInvoice[] invoice);

        /// <summary>
        /// Подписать и передать на портал налоговой входящие ЭСЧФ
        /// </summary>
        /// <param name="invoice">ЭСЧФ для передачи</param>
        /// <returns></returns>
        IEnumerable<SendInInfo> SignAndSendIn(params VatInvoiceXml[] invoice);

        /// <summary>
        ///  Проверить статус ЭСЧФ на портале МНС
        /// </summary>
        /// <param name="invoice">ЭСЧФ для проверки статуса</param>
        /// <returns></returns>
        IEnumerable<StatusInfo> CheckStatus(params VatInvoiceDto[] invoice);

        /// <summary>
        /// Загрузка входящих ЭСЧФ с портала
        /// </summary>
        IEnumerable<LoadInfo> LoadIncomeVatInvoice(DateTime date);


    }
}
