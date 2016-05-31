using System.Collections.Generic;
using System.Data;
using Dapper;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoForCheckStatus:SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoForCheckStatus()
        {
            Statuses = new []
            {
                InvoiceStatus.COMPLETED,
                InvoiceStatus.CANCELLED,
            };
        }

        public InvoiceStatus[] Statuses { get; private set; }

        protected override string Sql
        {
            get { return base.Sql + " WHERE  StatusId in @Statuses and IsIncome = 0"; }
        }

        public override IEnumerable<VatInvoiceDto> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.Query<VatInvoiceDto>(Sql,new DynamicParameters(this), transaction: tx);
        }
    }
}
