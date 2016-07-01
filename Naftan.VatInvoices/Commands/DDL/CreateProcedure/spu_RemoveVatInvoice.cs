namespace Naftan.VatInvoices.Commands.DDL.CreateProcedure
{
    public class spu_RemoveVatInvoice:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"

CREATE PROCEDURE [dbo].[spu_RemoveVatInvoice]
	@InvoiceId INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @status TINYINT, @isIncome bit
	SELECT 
		@isIncome = IsIncome,
		@status = StatusId
	FROM VatInvoice WHERE InvoiceId = @InvoiceId 
	
	/* если ЭСЧФ не отправлен на портал, то его можно удалить из системы */
	IF((@isIncome = 0 AND  @status in (1,2,8)) OR (@isIncome = 1 AND @status = 3))
	BEGIN
		DELETE FROM RosterDescription WHERE RosterId IN (SELECT rosterId FROM RosterList WHERE InvoiceId = @invoiceId )
		DELETE FROM Consignees WHERE InvoiceId = @invoiceId
		DELETE FROM Consignors WHERE InvoiceId = @invoiceId
		DELETE FROM RosterList WHERE InvoiceId = @invoiceId
		DELETE FROM Documents WHERE InvoiceId = @invoiceId
		DELETE FROM VatInvoiceXml WHERE InvoiceId = @invoiceId
		DELETE FROM VatInvoice WHERE InvoiceId = @invoiceId	
		RETURN 0
	END
	RETURN -1
END
"; }
        }
    }
}
