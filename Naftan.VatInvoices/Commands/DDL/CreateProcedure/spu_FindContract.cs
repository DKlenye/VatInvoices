
namespace Naftan.VatInvoices.Commands.DDL.CreateProcedure
{
    public class spu_FindContract:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"

    CREATE PROCEDURE [dbo].[spu_FindContract] 
	@ContractId INT,
	@Number NVARCHAR(100) OUTPUT,
	@Date Date OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		@Number = isnull(@Number,''),
		@Date = isnull(@Date,null) 
	RETURN;
END
"; }
        }
    }
}
