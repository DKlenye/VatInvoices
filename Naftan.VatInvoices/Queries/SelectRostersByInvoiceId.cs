using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Queries
{
    public class SelectRostersByInvoiceId:AbstractSelectByInvoiceId<Roster>
    {
        public SelectRostersByInvoiceId(int invoiceId) : base(invoiceId)
        {
        }

        public override IEnumerable<Roster> Execute(IDbConnection db, IDbTransaction tx)
        {

            var lookup = new Dictionary<int, Roster>();
            var descriptionLookup = new Dictionary<int, List<descriptionType>>();


            db.Query<Roster, descriptionType?, Roster>(@"
                SELECT 
	            l.Id,
	            l.InvoiceId,
	            l.Number,
                l.Name,
	            l.Code,
	            l.CodeOced,
	            l.Units,
	            l.[Count],
	            l.Price,
	            l.Cost,
	            l.SummaExcise,
	            l.VatRate,
	            l.VatRateTypeId AS VatRateType,
	            l.SummaVat,
	            l.CostVat,
	            d.DescriptionTypeId
            FROM RosterList l
            LEFT JOIN RosterDescription d on d.RosterId = l.Id
            WHERE l.InvoiceId = @InvoiceId
            ", (r, d) =>
            {
                Roster roster;
                if (!lookup.TryGetValue(r.Id, out roster))
                {
                    lookup.Add(r.Id, roster = r);
                }
                if (d != null)
                {
                    var descriptions = new List<descriptionType>();
                    if (descriptionLookup.ContainsKey(r.Id))
                    {
                        descriptions = descriptionLookup[r.Id];
                    }
                    else
                    {
                        descriptionLookup.Add(r.Id, descriptions);
                    }
                    
                    descriptions.Add(d.Value);
                }
                
                return roster;
            }, new { InvoiceId }, tx, splitOn: "DescriptionTypeId");
            
            descriptionLookup.Keys.ToList().ForEach(key =>
            {
                lookup[key].Description = descriptionLookup[key].ToArray();
            });
            
            return lookup.Values;

        }
    }
}
