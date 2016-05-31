using System;
using System.ComponentModel;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class Provider
    {
        [DisplayName("Код поставщика")]
        public int? ProviderCounteragentId { get; set; }

        [DisplayName("Статус поставщика")]
        public providerStatusType ProviderStatus { get; set; }

        [DisplayName("Взаимозависимое лицо")]
        public bool ProviderDependentPerson { get; set; }

        [DisplayName("Резидент оффшорной зоны")]
        public bool ProviderResidentsOfOffshore { get; set; }

        [DisplayName(
            "Сделка с товарами по перечню, определяемому Правительством Республики Беларусь, в соответствии с пп. 1.3 п. 1 ст. 30-1 НК"
            )]
        public bool ProviderSpecialDealGoods { get; set; }

        [DisplayName("Организация, включённая в перечень крупных плательщиков")]
        public bool ProviderBigCompany { get; set; }

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
    }
}
