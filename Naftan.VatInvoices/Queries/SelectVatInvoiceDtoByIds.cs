using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoByIds : SelectVatInvoiceDtoAll
    {
        public SelectVatInvoiceDtoByIds(params int[] id)
        {
            Id = id;
        }

        public int[] Id { get; private set; }

        protected override string Sql
        {
            get { return base.Sql + " WHERE InvoiceId in @Id"; }
        }

        public override IEnumerable<VatInvoiceDto> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.Query<VatInvoiceDto>(Sql, new {Id}, tx);
        }

    }
}
