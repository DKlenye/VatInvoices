using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Validations
{
    public class RosterTotalsValidation : IValidation<VatInvoice>
    {
        private const string exciseMessage = "Неверная итоговая сумма акциза";
        private const string vatMessage = "Неверная итоговая сумма ндс";
        private const string costMessage = "Неверная итоговая сумма стоимость товаров без НДС";
        private const string costVatMessage = "Неверная итоговая сумма стоимость товаров с НДС";

        public IList<string> Validate(VatInvoice obj)
        {
            var messages = new List<string>();

            if (obj.RosterList.Sum(x => x.SummaExcise) != obj.RosterTotalExcise)
                messages.Add(exciseMessage);
            if (obj.RosterList.Sum(x => x.SummaVat) != obj.RosterTotalVat)
                messages.Add(vatMessage);
            if (obj.RosterList.Sum(x => x.Cost) != obj.RosterTotalCost)
                messages.Add(costMessage);
            if (obj.RosterList.Sum(x => x.CostVat) != obj.RosterTotalCostVat)
                messages.Add(costVatMessage);

            return messages;
        }
    }
}
