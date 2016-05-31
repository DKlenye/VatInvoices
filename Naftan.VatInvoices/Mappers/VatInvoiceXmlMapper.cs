using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class VatInvoiceXmlMapper:ClassMapper<VatInvoiceXml>
    {
        public VatInvoiceXmlMapper()
        {
            Map(x => x.InvoiceId).Key(KeyType.Assigned);
            AutoMap();
;        }
    }
}
