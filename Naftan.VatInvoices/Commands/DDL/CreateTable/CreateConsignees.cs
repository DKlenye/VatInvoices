namespace Naftan.VatInvoices.Commands.DDL.CreateTable
{
    public class CreateConsignees : AbstractSqlCommand
    {
        protected override string Sql
        {
            get
            {
                return
                    @"CREATE TABLE [dbo].[Consignees](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ConsigneeCounteragentId] [int] NULL,
	                [InvoiceId] [int] NOT NULL,
	                [CountryCode] [int] NULL,
	                [Unp] [nchar](9) NULL,
	                [Name] [nvarchar](512) NULL,
	                [Address] [nvarchar](512) NULL,
                 CONSTRAINT [PK_Consignees] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]";

            }
        }
    }
}
