using DapperExtensions.Mapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Mappers
{
    public class EEUCountryMapper:ClassMapper<EEUCountry>
    {
        public EEUCountryMapper()
        {
            Table("view_EEUCountries");
            Map(x => x.Id).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}
