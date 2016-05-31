using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Converters
{
    class ConsignorConverter:IConverter<Consignor,consignor>
    {
        public Consignor To(consignor obj)
        {
            return new Consignor
            {
                Address = obj.address,
                CountryCode = string.IsNullOrEmpty(obj.countryCode) ? 0 : int.Parse(obj.countryCode),
                Name = obj.name,
                Unp = obj.unp
            };
        }

        public consignor From(Consignor obj)
        {
            return new consignor
            {
                address = obj.Address,
                countryCode = obj.CountryCode == null ? null : obj.CountryCode.ToString(),
                name = obj.Name,
                unp = obj.Unp
            };
        }
    }
}
