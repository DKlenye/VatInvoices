using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Validations
{
    /// <summary>
    /// Проверка ЭСЧФ. При указании ставки НДС 0%, либо «Без НДС» сумма НДС должна равняться нулю.
    /// </summary>
    public class VatZeroValidation : IValidation<VatInvoice>
    {
        private const string message = 
            "При указании ставки НДС 0%, либо «Без НДС» сумма НДС должна равняться нулю";

      
        public IList<string> IsValid(VatInvoice obj)
        {
            var errorList = new List<string>();

            if (obj.RosterList.Any(r =>
               (
                   r.VatRateType == rateType.ZERO ||
                   (r.VatRateType == rateType.DECIMAL && r.VatRate == 0)
                   ) && r.SummaVat != 0))
            {
                errorList.Add(message);
            }

            return errorList;
        }
    }
}
