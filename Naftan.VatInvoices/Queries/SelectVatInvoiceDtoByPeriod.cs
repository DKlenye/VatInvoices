using System;
using Naftan.VatInvoices.Domain;

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

    }
}
