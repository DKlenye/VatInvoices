using System;
using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Validations
{
    public class ProviderValidation : IValidation<VatInvoice>
    {
        
        private const string message1 =
            "Если статус поставщика – «иностранная организация», то код страны – не Республика Беларусь";

        private const string message2 = "УНП поставщика - обязательный реквизит для резидента Республики Беларусь";
        

        private const string message4 =
            "Наименование поставщика - обязательный реквизит для резидента Республики Беларусь";

        private const string message5 =
            "Юридический адрес поставщика - обязательный реквизит для резидента Республики Беларусь";

        private const string message6 =
            "Если поставщик не иностранная организация, то поставщик должен быть составителем ЭСЧФ";

        public IList<string> Validate(VatInvoice obj)
        {
            var messages = new List<string>();

            var providerIsBelarus = obj.Provider.ProviderCountryCode != null &&
                                    obj.Provider.ProviderCountryCode.Value == EEUCountry.BelarusCode;


            if (obj.Provider.ProviderStatus == providerStatusType.FOREIGN_ORGANIZATION && providerIsBelarus)
                messages.Add(message1);
            
            if (providerIsBelarus && String.IsNullOrEmpty(obj.Provider.ProviderUnp))
                messages.Add(message2);

            

            if (providerIsBelarus && String.IsNullOrEmpty(obj.Provider.ProviderName))
                messages.Add(message4);

            if (providerIsBelarus && String.IsNullOrEmpty(obj.Provider.ProviderAddress))
                messages.Add(message5);

            if (obj.Provider.ProviderStatus != providerStatusType.FOREIGN_ORGANIZATION && obj.Provider.ProviderUnp != Settings.SenderUnp)
                messages.Add(message6);
            
            return messages;

        }
    }
}
