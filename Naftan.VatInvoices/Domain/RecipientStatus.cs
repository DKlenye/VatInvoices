using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    public enum RecipientStatus
    {
        [Description("Покупатель")]CUSTOMER = 1,
         [Description("Потребитель")]CONSUMER = 2,
         [Description("Комитент")]CONSIGNOR = 3,
         [Description("Комиссионер")]COMMISSIONAIRE = 4,
         [Description("Покупатель, получающий налоговые вычеты")]TAX_DEDUCTION_RECIPIENT = 5,
         [Description("Покупатель объектов у иностранной организации")] FOREIGN_ORGANIZATION_BUYER= 6
    }
}