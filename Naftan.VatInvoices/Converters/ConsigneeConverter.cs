using System;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Converters
{
    public class ConsigneeConverter:IConverter<Consignee,consignee>
    {
        public Consignee To(consignee obj)
        {
            return new Consignee
            {
                Address = obj.address,
                CountryCode = string.IsNullOrEmpty(obj.countryCode)?0:int.Parse(obj.countryCode),
                Name = obj.name,
                Unp = obj.unp
            };
        }

        public consignee From(Consignee obj)
        {
            return new consignee
            {
                address = obj.Address,
                countryCode = obj.CountryCode==null ? null:obj.CountryCode.ToString(),
                name = obj.Name,
                unp = String.IsNullOrEmpty(obj.Unp)?"":obj.Unp
            };
        }
    }
}
