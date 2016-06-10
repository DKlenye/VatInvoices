using System;
using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Validations
{
    public class ProviderRecipientStatusValidation:IValidation<VatInvoice>
    {

        private readonly Dictionary<providerStatusType, List<recipientStatusType>> statusMap =
            new Dictionary<providerStatusType, List<recipientStatusType>>
            {
                {
                    providerStatusType.SELLER,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.CUSTOMER,
                        recipientStatusType.CONSUMER,
                        recipientStatusType.COMMISSIONAIRE,
                        recipientStatusType.AGENT
                    }
                },
                {
                    providerStatusType.CONSIGNOR,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.COMMISSIONAIRE
                    }
                },
                {
                    providerStatusType.COMMISSIONAIRE,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.CUSTOMER,
                        recipientStatusType.CONSUMER,
                        recipientStatusType.CONSIGNOR,
                        recipientStatusType.COMMISSIONAIRE
                    }
                },
                {
                    providerStatusType.TRUSTEE,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.CUSTOMER
                    }
                },
                {
                    providerStatusType.TAX_DEDUCTION_PAYER,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.TAX_DEDUCTION_RECIPIENT
                    }
                },
                {
                    providerStatusType.FOREIGN_ORGANIZATION,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.CUSTOMER,
                        recipientStatusType.FOREIGN_ORGANIZATION_BUYER
                    }
                },
                {
                    providerStatusType.AGENT,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.CONSUMER
                    }
                },
                {
                    providerStatusType.DEVELOPER,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.CONSUMER
                    }
                },
                {
                    providerStatusType.TURNOVERS_ON_SALE_PAYER,
                    new List<recipientStatusType>
                    {
                        recipientStatusType.TURNOVERS_ON_SALE_RECIPIENT
                    }
                }
            };

        private const string message = "Неверное соответствие статусов поставщика и получателя";
        
        public IList<string> Validate(VatInvoice obj)
        {
            var messages = new List<String>();
            if( !statusMap[obj.Provider.ProviderStatus].Contains(obj.Recipient.RecipientStatus))
                messages.Add(message);

            return messages;

        }
    }
}
