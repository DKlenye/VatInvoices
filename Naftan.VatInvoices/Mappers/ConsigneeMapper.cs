using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class ConsigneeMapper:ClassMapper<Consignee>
    {
        public ConsigneeMapper()
        {
            Table("Consignees");
            AutoMap();
        }
    }
}
