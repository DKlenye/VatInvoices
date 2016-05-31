using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoByPeriod:SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoByPeriod(DatePeriod period)
        {
            Start = period.From;
            End = period.To;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        protected override string Sql
        {
            get { return base.Sql + " WHERE AccountingDate between @Start and @End "; }
        }

        public override IEnumerable<VatInvoiceDto> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.Query<VatInvoiceDto>(Sql, new DynamicParameters(this), transaction: tx);
        }
    }
}
