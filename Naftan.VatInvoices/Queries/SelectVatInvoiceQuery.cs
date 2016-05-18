using System.Data;
using System.Linq;
using Dapper;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.QueryObjects;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceQuery:AbstractQuery<VatInvoice>
    {

        public int InvoiceId { get; private set; }

        public SelectVatInvoiceQuery(IDbConnection connection, int invoiceId) : base(connection)
        {
            InvoiceId = invoiceId;
        }

        public override VatInvoice Query()
        {
            var transaction = Connection.BeginTransaction();

            var vatInvoice = Connection.Query<VatInvoiceNumber,VatInvoice,VatInvoice>(new SelectVatInvoice().ById(InvoiceId).Sql,
                (n, i) =>
                {
                    i.VatNumber = n;
                    return i;
                }, transaction:transaction,splitOn:"InvoiceId").Single();
            
            vatInvoice.Documents = Connection.Query<Document>(new SelectDocument().ByInvoiceId(InvoiceId),transaction);
         
            vatInvoice.Consignees = Connection.Query<Consignee>(new SelectConsignee().ByInvoiceId(InvoiceId),transaction);
            
            vatInvoice.Consignors = Connection.Query<Consignor>(new SelectConsignor().ByInvoiceId(InvoiceId),transaction);
            
            vatInvoice.RosterList = Connection.Query<Roster>(new SelectRoster().ByInvoiceId(InvoiceId),transaction);

            transaction.Commit();

            return vatInvoice;
        }
    }
}
