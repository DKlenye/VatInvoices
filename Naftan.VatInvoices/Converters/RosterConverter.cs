using System;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Converters
{
    public class RosterConverter:IConverter<Roster,rosterItem>
    {
        public Roster To(rosterItem obj)
        {
            return new Roster()
            {
                Code = obj.code,
                CodeOced = obj.code_oced,
                Cost = obj.cost,
                CostVat = obj.costVat,
                Count = obj.count,
                Number = int.Parse(obj.number),
                Name = obj.name,
                Price = obj.price,
                SummaExcise = obj.summaExcise,
                SummaVat = obj.vat.summaVat,
                Units = int.Parse(obj.units),
                VatRate = obj.vat.rate,
                VatRateType = obj.vat.rateType,
                Description = obj.descriptions,
            };
        }

        public rosterItem From(Roster obj)
        {
            return new rosterItem
            {
                code = obj.Code,
                code_oced = String.IsNullOrEmpty(obj.CodeOced)?null:obj.CodeOced,
                cost = obj.Cost,
                costVat = obj.CostVat,
                count = obj.Count ?? 0,
                countSpecified = obj.Count != null,
                descriptions = obj.Description,
                name = obj.Name,
                number = obj.Number.ToString(),
                price = obj.Price ?? 0,
                priceSpecified = obj.Price != null,
                summaExcise = obj.SummaExcise ?? 0,
                summaExciseSpecified = obj.SummaExcise != null,
                units = obj.Units.ToString(),
                vat = new vat
                {
                    rate = obj.VatRate,
                    rateType = obj.VatRateType,
                    summaVat = obj.SummaVat
                }
            };
        }
    }
}
