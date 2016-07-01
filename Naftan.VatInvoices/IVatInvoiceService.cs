using System;
using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Users;

namespace Naftan.VatInvoices
{
    /// <summary>
    /// Интерфейс сервиса для работы с ЭСЧФ
    /// </summary>
    public interface IVatInvoiceService
    {
        /// <summary>
        /// Загрузить информацию по ЭСЧФ
        /// </summary>
        /// <param name="period">формат периода yyyymm</param>
        /// <returns></returns>
        IEnumerable<VatInvoiceDto> LoadVatInvoices(int? period = null);

        /// <summary>
        /// Загрузить ЭСЧФ по Id
        /// </summary>
        /// <param name="InvoiceId"></param>
        /// <returns></returns>
        VatInvoice LoadVatInvoice(int InvoiceId);

        /// <summary>
        /// Сохранить информацию по ЭСЧФ
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        VatInvoiceDto SaveVatInvoice(VatInvoice invoice);

        /// <summary>
        /// Загрузить список документов по id ЭСЧФ
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        IEnumerable<Document> LoadDocuments(int invoiceId);
        
        /// <summary>
        /// Загрузить список грузополучателей по id ЭСЧФ
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        IEnumerable<Consignee> LoadConsignees(int invoiceId);
        
        /// <summary>
        /// Загрузить список грузоотправителей по id ЭСЧФ
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        IEnumerable<Consignor> LoadConsignors(int invoiceId);

        /// <summary>
        /// Загрузить список продуктов(работ,услуг) по id ЭСЧФ
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        IEnumerable<Roster> LoadRosterList(int invoiceId);

        /// <summary>
        /// Подтверждение проверки информации от ответственного бухгалтера
        /// </summary>
        /// <param name="invoiceId"></param>
        IEnumerable<VatInvoiceDto> ApproveVatInvoice(params int[] invoiceId);

        /// <summary>
        /// Отмена подтверждения проверки информации от ответственного бухгалтера
        /// </summary>
        /// <param name="invoiceId"></param>
        IEnumerable<VatInvoiceDto> CancelApproveVatInvoice(params int[] invoiceId);
        
        /// <summary>
        /// Подписать и отправить ЭСЧФ на портал налоговой
        /// </summary>
        /// <param name="invoiceId">Id (Ключ) ЭСЧФ</param>
        IEnumerable<SendRezult> SignAndSend(params int[] invoiceId);

        /// <summary>
        /// Проверить статус выставленных ЭСЧФ
        /// </summary>
        IEnumerable<VatInvoiceDto> CheckStatus();

        /// <summary>
        /// Получить входящие ЭСЧФ с портала 
        /// </summary>
        IEnumerable<VatInvoiceDto> ReceiveIncoming(DateTime? date = null);

        /// <summary>
        /// Получить список ролей текущего пользователя
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserRoles> GetUserRoles();

        /// <summary>
        /// Получить список бухгалтерских счетов
        /// </summary>
        /// <param name="period">yyyymm</param>
        /// <param name="accounts">Список счетов, через запятую</param>
        /// <returns></returns>
        IEnumerable<AccountList> LoadAccountList(int period, string accounts);
        
    }
}
