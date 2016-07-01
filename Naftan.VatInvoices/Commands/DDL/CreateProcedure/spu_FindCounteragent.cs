namespace Naftan.VatInvoices.Commands.DDL.CreateProcedure
{
    public class spu_FindCounteragent:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"

CREATE PROCEDURE [dbo].[spu_FindCounteragent] 
	@CounteragentId INT,
	@Name NVARCHAR(200) OUTPUT,
	@Unp NCHAR(9) OUTPUT,
	@CountryCode INT OUTPUT,
	@Address NVARCHAR(200) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		@Name = isnull(@Name,''),
		@Unp = isnull(@Unp,''),
		@CountryCode = isnull(@CountryCode,0),
		@Address = isnull(@Address, '')

	RETURN;
END

"; }
        }
    }
}
