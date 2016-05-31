using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class RosterMapper:ClassMapper<Roster>
    {
        public RosterMapper()
        {
            Table("RosterList");
            Map(x => x.VatRateType).Column("VatRateTypeId");
            Map(x => x.Description).Ignore();
            AutoMap();
        }
    }
}
