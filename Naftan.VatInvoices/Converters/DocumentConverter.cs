using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Converters
{
    public class DocumentConverter:IConverter<Document,document>
    {
        public Document To(document obj)
        {
            return new Document
            {
                BlancCode = obj.blankCode,
                Date = obj.date,
                DocTypeCode = int.Parse(obj.docType.code),
                Number = obj.number,
                Seria = obj.seria
            };
        }

        public document From(Document obj)
        {
            return new document
            {
                blankCode = obj.BlancCode,
                date = obj.Date.Value,
                number = obj.Number,
                docType = new docType
                {
                    code = obj.DocTypeCode.ToString()
                },
                seria = obj.Seria
            };
        }
    }
}
