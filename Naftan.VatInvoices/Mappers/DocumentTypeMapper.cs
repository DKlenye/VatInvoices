using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class DocumentTypeMapper:ClassMapper<DocumentType>
    {
        public DocumentTypeMapper()
        {
            Map(x => x.DocumentTypeCode).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
