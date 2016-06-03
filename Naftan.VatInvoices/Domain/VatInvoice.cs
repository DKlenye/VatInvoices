using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati;
using Naftan.VatInvoices.Validations;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// ЭСЧФ
    /// </summary>
    public class VatInvoice
    {
        [DisplayName("Код")]
        public int InvoiceId { get; set; }

        [DisplayName("Входящий ЭСЧФ")]
        public bool IsIncome { get; set; }

        [DisplayName("Учётная система")]
        public int? ReplicationSourceId { get; private set; }

        [DisplayName("Код учётной системы")]
        public int? ReplicationId { get; private set; }

        [DisplayName("Покупка продажа")]
        public BuySaleType BuySaleType { get; set; }

        [DisplayName("Счёт НДС")]
        public string VatAccount { get; set; }

        [DisplayName("Бухгалтерский счёт")]
        public string Account { get; set; }

        [DisplayName("Дата бухг. учёта")]
        public DateTime AccountingDate { get; set; }

        [DisplayName("Статус ЭСЧФ")]
        public InvoiceStatus Status { get; private set; }

        [DisplayName("Информация по статусу")]
        public string StatusMessage { get; private set; }

        [DisplayName("УНП отправителя")]
        public string Sender { get; set; }

        [DisplayName("№ ЭСЧФ")]
        public VatInvoiceNumber VatNumber { get; set; }

        [DisplayName("Дата выписки ЭСЧФ")]
        public DateTime? DateIssuance { get; set; }

        [DisplayName("Дата совершения операции")]
        public DateTime DateTransaction { get; set; }

        [DisplayName("Тип ЭСЧФ")]
        public invoiceDocType InvoiceType { get; set; }

        [DisplayName("№ исходномго ЭСЧФ")]
        public string OriginalInvoiceNumber { get; set; }

        [DisplayName("Отобразить получателю")]
        public bool SendToRecipient { get; set; }

        [DisplayName("Дата аннулирования ЭСЧФ")]
        public DateTime? DateCancelled { get; set; }

        [DisplayName("Поставщик")]
        public Provider Provider { get; set; }

        [DisplayName("Получатель")]
        public Recipient Recipient { get; set; }

        #region Contract(Договор)

        [DisplayName("Код договора")]
        public int? ContractId { get; set; }

        [DisplayName("Номер договора")]
        public string ContractNumber { get; set; }

        [DisplayName("Дата договора")]
        public DateTime? ContractDate { get; set; }

        [DisplayName("Доп. сведения")]
        public string ContractDescription { get; set; }

        #endregion

        [DisplayName("В том числе сумма акциза, бел.руб")]
        public decimal RosterTotalExcise { get; set; }

        [DisplayName("сумма НДС, бел.руб")]
        public decimal RosterTotalVat { get; set; }

        [DisplayName("Стоимость товаров (работ, услуг), имущественных прав без НДС, бел.руб")]
        public decimal RosterTotalCost { get; set; }

        [DisplayName("Итоговая стоимость товаров (работ, услуг), имущественных прав с учетом НДС, бел.руб")]
        public decimal RosterTotalCostVat { get; set; }

        [DisplayName("Дата подтверждения бухгалтером")]
        public DateTime? ApproveDate { get; private set; }

        [DisplayName("Подтверждено бухгалтером")]
        public string ApproveUser { get; private set; }

        [DisplayName("Пройден форматно-логический контроль")]
        public bool IsValidate { get; private set; }

        [DisplayName("Подтверждение вывоза ")]
        public DateTime? ApproveDateExport { get; private set; }

        [DisplayName("Грузоотправители")]
        public IEnumerable<Consignee> Consignees { get; set; }

        [DisplayName("Грузополучатели")]
        public IEnumerable<Consignor> Consignors { get; set; }

        [DisplayName("Документы")]
        public IEnumerable<Document> Documents { get; set; }

        [DisplayName("Продукты, товары, услуги")]
        public IEnumerable<Roster> RosterList { get; set; }

        
        /// <summary>
        /// Подтверждение счёта фактуры для передачи на портал МНС
        /// </summary>
        public void Approve(string user)
        {
            if (!IsApprove())
            {
                ApproveDate = DateTime.Now;
                ApproveUser = user;
            }

        }

        /// <summary>
        /// Отмена подтверждения счёта фактуры для передачи на портал МНС
        /// </summary>
        public void CancelApprove()
        {
            if (! new[] {InvoiceStatus.IN_PROGRESS, InvoiceStatus.IN_PROGRESS_ERROR}
                .Contains(Status))
            {
                throw new Exception("Отменить подтверждение невозможно. ЭСЧФ отправлен на портал.");
            }

            if (IsApprove())
            {
                ApproveDate = null;
                ApproveUser = null;
            }
        }

        public bool IsApprove()
        {
            return ApproveDate != null;
        }

        public void SetStatus(InvoiceStatus status, string message = "")
        {
            Status = status;
            StatusMessage = message;
        }

        public void Validate(params IValidation<VatInvoice>[] validations)
        {
            var enableValidateStatus = new[]
            {
                InvoiceStatus.IN_PROGRESS,
                InvoiceStatus.IN_PROGRESS_ERROR
            };
            
            if (enableValidateStatus.Contains(Status))
            {
                var errors = new List<string>();
                validations.ToList().ForEach(v => errors.AddRange(v.IsValid(this)));

                if (!IsValidate) IsValidate = true;

                if (errors.Any()) SetStatus(InvoiceStatus.IN_PROGRESS_ERROR,String.Join(",",errors));
                else SetStatus(InvoiceStatus.IN_PROGRESS);
            }
        }
    }
}
