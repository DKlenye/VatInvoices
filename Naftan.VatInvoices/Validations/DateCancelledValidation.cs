using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Validations
{
    public class DateCancelledValidation:IValidation<VatInvoice>
    {
        private const string message = "Дата аннулирования обязательна для исправленного ЭСЧФ";

        public IList<string> Validate(VatInvoice obj)
        {
            var messages = new List<string>();

            if (obj.InvoiceType == invoiceDocType.ADDITIONAL && obj.DateCancelled==null)
                messages.Add(message);

            return messages;
        }
    }
}
