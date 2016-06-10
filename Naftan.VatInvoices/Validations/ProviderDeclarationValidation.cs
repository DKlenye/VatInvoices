using System;
using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Validations
{
    public class ProviderDeclarationValidation:IValidation<VatInvoice>
    {

        public string message1 = "Необходимо заполнить реквизиты деклараций на товары";
        public string message2 = "Необходимо заполнить реквизиты заявления о ввозе товаров и уплате косвенных налогов";

        public ProviderDeclarationValidation(IEnumerable<EEUCountry> eeucountries)
        {
            EEUCountries = eeucountries;
        }

        public IEnumerable<EEUCountry> EEUCountries { get; private set; }

        public IList<string> Validate(VatInvoice obj)
        {

            var messages = new List<string>();

            //если код страны поставщика РБ, а код страны получателя указан

            if (
                obj.Provider.ProviderCountryCode != null &&
                obj.Provider.ProviderCountryCode.Value == EEUCountry.BelarusCode &&
                obj.Recipient.RecipientCountryCode != null
                )
            {
                //если не входит в ЕАЭС
                if( !EEUCountries.Select(x => x.Code).Contains(obj.Recipient.RecipientCountryCode.Value.ToString()) && 
                    ( 
                        String.IsNullOrEmpty(obj.Provider.ProviderDeclaration) ||
                        obj.Provider.DateRelease==null ||
                        obj.Provider.DateActualExport==null)
                    )
                    messages.Add(message1);


                //если входит в ЕАЭС
                if (EEUCountries.Select(x => x.Code).Contains(obj.Recipient.RecipientCountryCode.Value.ToString()) &&
                    obj.Recipient.RecipientCountryCode.Value!=EEUCountry.BelarusCode &&
                    (
                        String.IsNullOrEmpty(obj.Provider.ProviderTaxeNumber) ||
                        obj.Provider.ProviderTaxeDate == null)
                    )
                    messages.Add(message2);
                
            }

            return messages;

        }
    }
}
