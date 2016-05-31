using System.Collections.Generic;
using System.Data;
using DapperExtensions;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class AbstractSelectByInvoiceId<T>:IQuery<IEnumerable<T>>
        where T:class,IVatInvoiceId
    {
        public AbstractSelectByInvoiceId(int invoiceId)
        {
            InvoiceId = invoiceId;
        }

        public int InvoiceId { get; private set; }

        public virtual IEnumerable<T> Execute(IDbConnection db, IDbTransaction tx)
        {
            var predicate = Predicates.Field<T>(f => f.InvoiceId, Operator.Eq, InvoiceId);
            return db.GetList<T>(
                predicate: predicate,
                transaction: tx
                );
        }
    }
}
