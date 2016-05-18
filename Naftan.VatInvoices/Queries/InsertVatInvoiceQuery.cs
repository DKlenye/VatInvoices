using System.Data;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.QueryObjects;

namespace Naftan.VatInvoices.Queries
{
    public class InsertVatInvoiceQuery:AbstractQuery<VatInvoice>
    {
        public InsertVatInvoiceQuery(IDbConnection connection, VatInvoice invoice) : base(connection)
        {
            Invoice = invoice;
        }

        public VatInvoice Invoice { get; private set; }

        public override VatInvoice Query()
        {

            var transaction = Connection.BeginTransaction();

            var id = Connection.Query<int>(new InsertVatInvoice().Query(Invoice), transaction).Single();
            Invoice.InvoiceId = id;

            Invoice.Documents.ToList().ForEach(d =>
            {
                d.InvoiceId = id;
                Connection.Execute(new InsertDocument().Query(d), transaction);
            });

            Invoice.Consignees.ToList().ForEach(c =>
            {
                c.InvoiceId = id;
                Connection.Execute(new InsertConsignee().Query(c), transaction);
            });

            Invoice.Consignors.ToList().ForEach(c =>
            {
                c.InvoiceId = id;
                Connection.Execute(new InsertConsignor().Query(c), transaction);
            });

            Invoice.RosterList.ToList().ForEach(r =>
            {
                r.InvoiceId = id;
                Connection.Execute(new InsertRoster().Query(r), transaction);
            });

            transaction.Commit();

            return Invoice;

        }
    }
}
