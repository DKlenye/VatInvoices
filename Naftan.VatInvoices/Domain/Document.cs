using System;

namespace Naftan.VatInvoices.Domain
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int InvoiceId { get; set; }
        public int ReplicationId { get; set; }
        public string DocTypeCode { get; set; }
        public string DocTypeValue { get; set; }
        public string BlancCode { get; set; }
        public string Number { get; set; }
        public string Seria { get; set; }
        public DateTime? Date { get; set; }
    }
}
