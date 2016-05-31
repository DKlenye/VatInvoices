using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class ConsignorMapper:ClassMapper<Consignor>
    {
        public ConsignorMapper()
        {
            Table("Consignors");
            AutoMap();
        }
    }
}
