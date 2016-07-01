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

            var consignees = obj.senderReceiver.consignees;
            var consignors = obj.senderReceiver.consignors;
            var documents = obj.deliveryCondition.contract.documents;

            return new VatInvoice
            {
                Sender = obj.sender,
                VatNumber = new VatInvoiceNumber(obj.general.number),
                DateIssuance = obj.general.dateIssuanceSpecified ? obj.general.dateIssuance : (DateTime?) null,
                DateTransaction = obj.general.dateTransaction,
                InvoiceType = obj.general.documentType,
                ContractNumber = obj.deliveryCondition.contract.number,
                ContractDate = obj.deliveryCondition.contract.date,
                ContractDescription = obj.deliveryCondition.description,
                Consignees = consignees == null ? null : consignees.Select(x => x.ConvertTo<Consignee>()),
                Consignors = consignors == null ? null : consignors.Select(x => x.ConvertTo<Consignor>()),
                Documents = documents == null? null:documents.Select(x => x.ConvertTo<Document>()),
                RosterList = obj.roster.rosterItem.Select(x => x.ConvertTo<Roster>()),
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
                        date = obj.ContractDate.Value,
                        number = obj.ContractNumber??"",
                        documents = obj.Documents.Any()?obj.Documents.Select(x=>x.ConvertTo<document>()).ToArray():null
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
