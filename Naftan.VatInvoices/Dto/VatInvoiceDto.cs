using System;
using System.ComponentModel;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Dto
{
    /// <summary>
    /// Информация по ЭСЧФ
    /// </summary>
    public class VatInvoiceDto
    {
        [DisplayName("Код")]
        public int InvoiceId { get; set; }

        [DisplayName("Входящий ЭСЧФ")]
        public bool IsIncome { get; set; }

        [DisplayName("Учётная система")]
        public int? ReplicationSourceId { get; set; }

        [DisplayName("Покупка продажа")]
        public BuySaleType BuySaleType { get; set; }

        [DisplayName("Счёт НДС")]
        public string VatAccount { get; set; }

        [DisplayName("Бухгалтерский счёт")]
        public string Account { get; set; }

        [DisplayName("Статус ЭСЧФ")]
        public InvoiceStatus InvoiceStatus { get; set; }

        [DisplayName("УНП отправителя")]
        public string Sender { get; set; }

        [DisplayName("№ ЭСЧФ")]
        public string NumberString { get; set; }

        [DisplayName("Дата выписки ЭСЧФ")]
        public DateTime? DateIssuance { get; set; }

        [DisplayName("Дата совершения операции")]
        public DateTime DateTransaction { get; set; }

        [DisplayName("Тип ЭСЧФ")]
        public InvoiceType InvoiceType { get; set; }

        [DisplayName("№ исходномго ЭСЧФ")]
        public string OriginalInvoiceNumber { get; set; }

        [DisplayName("Отобразить получателю")]
        public bool? SendToRecipient { get; set; }

        [DisplayName("Дата аннулирования ЭСЧФ")]
        public DateTime? DateCancelled { get; set; }

        #region Provider (Поставщик)

        [DisplayName("Код поставщика")]
        public int? ProviderCounteragentId { get; set; }

        [DisplayName("Статус поставщика")]
        public ProviderStatus ProviderStatus { get; set; }

        [DisplayName("Взаимозависимое лицо")]
        public bool? ProviderDependentPerson { get; set; }

        [DisplayName("Резидент оффшорной зоны")]
        public bool? ProviderResidentsOfOffshore { get; set; }

        [DisplayName("Сделка с товарами по перечню, определяемому Правительством Республики Беларусь, в соответствии с пп. 1.3 п. 1 ст. 30-1 НК")]
        public bool? ProviderSpecialDealGoods { get; set; }

        [DisplayName("Организация, включённая в перечень крупных плательщиков")]
        public bool? ProviderBigCompany { get; set; }

        [DisplayName("Код страны")]
        public int? ProviderCountryCode { get; set; }

        [DisplayName("УНП")]
        public string ProviderUnp { get; set; }

        [DisplayName("Код филиала")]
        public string ProviderBranchCode { get; set; }

        [DisplayName("Поставщик")]
        public string ProviderName { get; set; }

        [DisplayName("Юридический адрес (адрес места жительства ИП)")]
        public string ProviderAddress { get; set; }

        [DisplayName("Номер счета комитента")]
        public string PrincipalInvoiceNumber { get; set; }

        [DisplayName("Дата выписки счета комитента")]
        public DateTime? PrincipalInvoiceDate { get; set; }

        [DisplayName("Номер счета продавца")]
        public string VendorInvoiceNumber { get; set; }

        [DisplayName("Дата выписки счета продавца")]
        public DateTime? VendorInvoiceDate { get; set; }

        [DisplayName("Регистрационный номер выпуска товаров")]
        public string ProviderDeclaration { get; set; }

        [DisplayName("Дата выпуска товаров")]
        public DateTime? DateRelease { get; set; }

        [DisplayName("Дата разрешения на убытие товаров")]
        public DateTime? DateActualExport { get; set; }

        [DisplayName("Номер заявления о ввозе товаров и уплате косвенных налогов")]
        public string ProviderTaxeNumber { get; set; }

        [DisplayName("Дата заявления о ввозе товаров и уплате косвенных налогов")]
        public DateTime? ProviderTaxeDate { get; set; }

        #endregion

        #region Recipient(Получатель)

        [DisplayName("Код получателя")]
        public int? RecipientCounteragentId { get; set; }

        [DisplayName("Статус получателя (по договору/контракту)")]
        public RecipientStatus RecipientStatus { get; set; }

        [DisplayName("Взаимозависимое лицо")]
        public bool? RecipientDependentPerson { get; set; }

        [DisplayName("Резидент оффшорной зоны")]
        public bool? RecipientResidentsOfOffshore { get; set; }

        [DisplayName(
            "Сделка с товарами по перечню, определяемому Правительством Республики Беларусь, в соответствии с пп. 1.3 п. 1 ст. 30-1 НК"
            )]
        public bool? RecipientSpecialDealGoods { get; set; }

        [DisplayName("Организация, включённая в перечень крупных плательщиков")]
        public bool? RecipientBigCompany { get; set; }

        [DisplayName("Код страны")]
        public int? RecipientCountryCode { get; set; }

        [DisplayName("УНП")]
        public string RecipientUnp { get; set; }

        [DisplayName("Код филиала")]
        public string RecipientBranchCode { get; set; }

        [DisplayName("Получатель")]
        public string RecipientName { get; set; }

        [DisplayName("Юридический адрес (адрес места жительства ИП)")]
        public string RecipientAddress { get; set; }

        [DisplayName("Регистрационный номер выпуска товаров")]
        public string RecipientDeclaration { get; set; }

        [DisplayName("Номер заявления о ввозе товаров и уплате косвенных налогов")]
        public string RecipientTaxeNumber { get; set; }

        [DisplayName("Дата заявления о ввозе товаров и уплате косвенных налогов")]
        public DateTime? RecipientTaxeDate { get; set; }

        [DisplayName("Дата ввоза товара")]
        public DateTime? DateImport { get; set; }

        #endregion

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
        public decimal? RosterTotalExcise { get; set; }

        [DisplayName("сумма НДС, бел.руб")]
        public decimal? RosterTotalVat { get; set; }

        [DisplayName("Стоимость товаров (работ, услуг), имущественных прав без НДС, бел.руб")]
        public decimal? RosterTotalCost { get; set; }

        [DisplayName("Итоговая стоимость товаров (работ, услуг), имущественных прав с учетом НДС, бел.руб")]
        public decimal? RosterTotalCostVat { get; set; }

        [DisplayName("Дата подтверждения бухгалтером")]
        public DateTime? ApproveDate { get; set; }

    }
}
