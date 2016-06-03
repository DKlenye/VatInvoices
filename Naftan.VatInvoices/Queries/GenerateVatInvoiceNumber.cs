using System;
using System.Data;
using Dapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class GenerateVatInvoiceNumber : IQuery<VatInvoiceNumber>
    {
        public GenerateVatInvoiceNumber(int year)
        {
            Year = year;
        }

        public int Year { get; private set; }
        public string NumberString { get; set; }
        public Int64 Number { get; private set; }

        public VatInvoiceNumber Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Execute(@"
            EXEC spu_GenerateVatInvoiceNumber
                @Year = @Year,
                @Number = @Number OUTPUT,
                @NumberString = @NumberString OUTPUT
            ",
                new DynamicParameters(this)
                    .Output(this, x => x.Number)
                    .Output(this, x => x.NumberString)
                    ,tx);

            return new VatInvoiceNumber(NumberString);
        }
    }
}
