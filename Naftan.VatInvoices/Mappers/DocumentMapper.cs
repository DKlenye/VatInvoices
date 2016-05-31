using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class DocumentMapper:ClassMapper<Document>
    {
        public DocumentMapper()
        {
            Table("Documents");
            AutoMap();
        }
    }
}
