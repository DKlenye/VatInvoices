using System.Collections.Generic;
using System.Data;
using DapperExtensions;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectEEUCountryAll:IQuery<IEnumerable<EEUCountry>>
    {
        public IEnumerable<EEUCountry> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.GetList<EEUCountry>(transaction: tx);
        }
    }
}
