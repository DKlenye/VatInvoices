using System;
using System.ComponentModel;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Domain
{
    public class Recipient
    {
        [DisplayName("Код получателя")]
        public int? RecipientCounteragentId { get; set; }

        [DisplayName("Статус получателя (по договору/контракту)")]
        public recipientStatusType RecipientStatus { get; set; }

        [DisplayName("Взаимозависимое лицо")]
        public bool RecipientDependentPerson { get; set; }

        [DisplayName("Резидент оффшорной зоны")]
        public bool RecipientResidentsOfOffshore { get; set; }

        [DisplayName(
            "Сделка с товарами по перечню, определяемому Правительством Республики Беларусь, в соответствии с пп. 1.3 п. 1 ст. 30-1 НК"
            )]
        public bool RecipientSpecialDealGoods { get; set; }

        [DisplayName("Организация, включённая в перечень крупных плательщиков")]
        public bool RecipientBigCompany { get; set; }

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
    }
}
