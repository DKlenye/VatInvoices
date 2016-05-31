using System.Data;
using Dapper;

namespace Naftan.VatInvoices.Commands
{
    public class GenerateVatInvoiceNumber : ICommand
    {
        public GenerateVatInvoiceNumber(int year)
        {
            Year = year;
        }

        public int Year { get; private set; }
        public string NumberString { get; set; }
        public int Number { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Execute(@"
            EXEC spu_GenerateVatInvoiceNumber
                @Year = @Year,
                @Number = @Number OUTPUT,
                @NumberString = @NumberString OUTPUT
            ",
                new DynamicParameters(this)
                    .Output(this, x => x.Number)
                    .Output(this, x => x.NumberString));
        }
    }
}
