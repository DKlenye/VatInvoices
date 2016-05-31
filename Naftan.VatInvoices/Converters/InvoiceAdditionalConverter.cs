using System;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati;
using Naftan.VatInvoices.Mnsati.Additional;

namespace Naftan.VatInvoices.Converters
{
    public class InvoiceAdditionalConverter:IConverter<VatInvoice,issuance>
    {
        public VatInvoice To(issuance obj)
        {
            return new VatInvoice
            {
                Sender = obj.sender,
                VatNumber = new VatInvoiceNumber(obj.general.number),
                InvoiceType = obj.general.documentType,
                DateIssuance = obj.general.dateIssuanceSpecified ? obj.general.dateIssuance:(DateTime?)null,
                OriginalInvoiceNumber = obj.general.invoice,
                SendToRecipient = obj.general.sendToRecipient,
                RosterList = obj.roster.rosterItem.Select(x => x.ConvertTo<Roster>()),
                RosterTotalCost = obj.roster.totalCost,
                RosterTotalCostVat = obj.roster.totalCostVat,
                RosterTotalExcise = obj.roster.totalExcise,
                RosterTotalVat = obj.roster.totalVat
            };
        }

        public issuance From(VatInvoice obj)
        {
            return new issuance
            {
                sender = obj.Sender,
                general = new general
                {
                    number = obj.VatNumber.NumberString,
                    documentType = obj.InvoiceType,
                    dateIssuanceSpecified = obj.DateIssuance != null,
                    dateIssuance = obj.DateIssuance ?? new DateTime(),
                    dateTransaction = obj.DateTransaction,
                    invoice = obj.OriginalInvoiceNumber,
                    sendToRecipient = obj.SendToRecipient
                },
                roster = new rosterList
                {
                    totalCost = obj.RosterTotalCost,
                    totalCostVat = obj.RosterTotalCostVat,
                    totalExcise = obj.RosterTotalExcise,
                    totalVat = obj.RosterTotalVat,
                    rosterItem = obj.RosterList.Select(x => x.ConvertTo<rosterItem>()).ToArray()
                }
            };
        }
    }
}
