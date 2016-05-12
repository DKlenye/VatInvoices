using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    public enum ProviderStatus
    {

        [Description("Продавец")] SELLER = 1,
        [Description("Комитент")] CONSIGNOR = 2,
        [Description("Комиссионер")] COMMISSIONAIRE = 3,
        [Description("Плательщик")] TAX_DEDUCTION_PAYER = 4,
        [Description("Доверительный")] TRUSTEE = 5,
        [Description("Иностранная организация")] FOREIGN_ORGANIZATION = 6,
        [Description("Посредник")] AGENT = 7,
        [Description("Заказчик (застройщик)")] DEVELOPER = 8
    }
}
