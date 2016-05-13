using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices
{
    /// <summary>
    /// Интерфейс сервиса для работы с ЭСЧФ
    /// </summary>
    public interface IVatInvoiceService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="period">формат периода yyyymm</param>
        /// <returns></returns>
        IEnumerable<VatInvoiceDto> LoadVatInvoices(int? period = null);
        
        /// <summary>
        /// Загрузить список документов по id ЭСЧФ
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        IEnumerable<Document> LoadDocuments(int invoiceId);
        
        /// <summary>
        /// Загрузить список грузоотправителей по id ЭСЧФ
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        IEnumerable<Consignee> LoadConsignees(int invoiceId);
        
        /// <summary>
        /// Загрузить список грузополучателей по id ЭСЧФ
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
        VatInvoiceDto ApproveVatInvoice(int invoiceId);
        
        /// <summary>
        /// Подписать и отправить ЭСЧФ на портал налоговой
        /// </summary>
        /// <param name="invoiceId">Id (Ключ) ЭСЧФ</param>
        void SignUpAndSend(params int[] invoiceId);
        
    }
}
