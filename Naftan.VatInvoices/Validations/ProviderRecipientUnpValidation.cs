using System.Collections.Generic;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Validations
{
    public class ProviderRecipientUnpValidation:IValidation<VatInvoice>
    {

        private const string message1 = "УНП составителя должен содержаться либо в разделе поставщика, либо в разделе получателя";

        private const string message2 = "УНП (идент. код) поставщика не должен совпадать с УНП (идент. код) получателя";


        public IList<string> Validate(VatInvoice obj)
        {
            var messages = new List<string>();

            if(obj.Provider.ProviderUnp!=Settings.SenderUnp && obj.Recipient.RecipientUnp!=Settings.SenderUnp)
                messages.Add(message1);

            if (obj.Provider.ProviderUnp == obj.Recipient.RecipientUnp)
                messages.Add(message2);

            return messages;
        }
    }
}
