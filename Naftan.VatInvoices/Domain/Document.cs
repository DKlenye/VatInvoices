using System;
using System.ComponentModel;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// Первичный документ
    /// </summary>
    /// 
    public class Document : IVatInvoiceId
    {
        [DisplayName("Код документа")]
        public int Id { get; set; }

        [DisplayName("Код документа в учётной системе")]
        public int? DocumentId { get; set; }

        [DisplayName("Код ЭСЧФ")]
        public int InvoiceId { get; set; }

        [DisplayName("Код типа документа")]
        public int? DocTypeCode { get; set; }

        [DisplayName("Код бланка")]
        public string BlancCode { get; set; }

        [DisplayName("Номер")]
        public string Number { get; set; }

        [DisplayName("Серия")]
        public string Seria { get; set; }

        [DisplayName("Дата")]
        public DateTime? Date { get; set; }
    }
}
