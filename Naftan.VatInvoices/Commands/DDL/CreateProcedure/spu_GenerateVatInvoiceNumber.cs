namespace Naftan.VatInvoices.Commands.DDL.CreateProcedure
{
    public class spu_GenerateVatInvoiceNumber:AbstractSqlCommand
    {
        protected override string Sql
        {
            get
            {
                return @"

                    CREATE PROC [dbo].[spu_GenerateVatInvoiceNumber] 
	                @Year INT, 
	                @Number BIGINT OUTPUT, 
	                @NumberString NCHAR(25) OUTPUT
                AS
                BEGIN
	
	                SET NOCOUNT ON;
	
	                DECLARE @NaftanUNP CHAR(9)
	                SET @NaftanUNP = '300042199'
	
	                SELECT 
		                @Number =  isnull(MAX(Number),0)+1 
	                FROM VatInvoice 
	                WHERE 
		                Sender = @NaftanUNP AND
		                [Year] = @year
	
	                SET @NumberString = @NaftanUNP+'-'+CAST(@Year AS CHAR(4))+'-'+ RIGHT(REPLICATE('0', 10) + CAST(@Number AS varchar(10)), 10)
	
	                RETURN
                END

                ";
            }
        }
    }
}
