using System;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati.Cancelled;

namespace Naftan.VatInvoices.Converters
{
    public class InvoiceCancelledConverter : IConverter<VatInvoice, issuance>
    {
        public VatInvoice To(issuance obj)
        {
            return new VatInvoice
            {
                Sender = obj.sender,
                OriginalInvoiceNumber = obj.general.invoice,
                InvoiceType = obj.general.documentType,
                DateCancelled = obj.general.dateCancelled
            };
        }

        public issuance From(VatInvoice obj)
        {
            return new issuance
            {
                general = new general
                {
                    dateCancelled = obj.DateCancelled ?? new DateTime(),
                    documentType = obj.InvoiceType,
                    invoice = obj.OriginalInvoiceNumber
                },
                sender = obj.Sender
            };
        }
    }
}
