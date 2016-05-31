using System;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati;
using Naftan.VatInvoices.Mnsati.Original;

namespace Naftan.VatInvoices.Converters
{
    public class InvoiceOriginalConverter:IConverter<VatInvoice,issuance>
    {
        public VatInvoice To(issuance obj)
        {
            return new VatInvoice
            {
                Sender = obj.sender,
                VatNumber = new VatInvoiceNumber(obj.general.number),
                DateIssuance = obj.general.dateIssuanceSpecified?obj.general.dateIssuance:(DateTime?)null,
                DateTransaction = obj.general.dateTransaction,
                InvoiceType = obj.general.documentType,
                ContractNumber = obj.deliveryCondition.contract.number,
                ContractDate = obj.deliveryCondition.contract.date,
                ContractDescription = obj.deliveryCondition.description,
                Consignees = obj.senderReceiver.consignees.Select(x => x.ConvertTo<Consignee>()),
                Consignors = obj.senderReceiver.consignors.Select(x => x.ConvertTo<Consignor>()),
                Documents = obj.deliveryCondition.contract.documents.Select(x=>x.ConvertTo<Document>()),
                RosterList = obj.roster.rosterItem.Select(x=>x.ConvertTo<Roster>()),
                RosterTotalCost = obj.roster.totalCost,
                RosterTotalCostVat = obj.roster.totalCostVat,
                RosterTotalExcise = obj.roster.totalExcise,
                RosterTotalVat = obj.roster.totalVat,

                Provider = obj.provider.ConvertTo<Provider>(),
                Recipient = obj.recipient.ConvertTo<Recipient>()
                

            };

        }

        public issuance From(VatInvoice obj)
        {
            return new issuance()
            {
                sender = obj.Sender,
                general = new general
                {
                  number  = obj.VatNumber.NumberString,
                  dateIssuanceSpecified = obj.DateIssuance!=null,
                  dateIssuance = obj.DateIssuance??new DateTime(),
                  dateTransaction = obj.DateTransaction,
                  documentType = obj.InvoiceType
                },
                senderReceiver = new senderReceiver
                {
                    consignees = obj.Consignees.Select(x => x.ConvertTo<consignee>()).ToArray(),
                    consignors = obj.Consignors.Select(x => x.ConvertTo<consignor>()).ToArray()
                },
                deliveryCondition = new deliveryCondition
                {
                    contract = new contract
                    {
                        date = obj.ContractDate,
                        number = obj.ContractNumber,
                        documents = obj.Documents.Select(x=>x.ConvertTo<document>()).ToArray()
                    },
                    description = obj.ContractDescription
                },
                provider = obj.Provider.ConvertTo<provider>(),
                recipient = obj.Recipient.ConvertTo<recipient>(),
                roster = new rosterList
                {
                    totalCost = obj.RosterTotalCost,
                    totalCostVat = obj.RosterTotalCostVat,
                    totalExcise = obj.RosterTotalExcise,
                    totalVat = obj.RosterTotalVat,
                    rosterItem = obj.RosterList.Select(x=>x.ConvertTo<rosterItem>()).ToArray()
                }
            };
        }
    }
}
