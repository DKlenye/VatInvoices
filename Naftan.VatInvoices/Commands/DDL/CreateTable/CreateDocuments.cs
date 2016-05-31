
namespace Naftan.VatInvoices.Commands.DDL.CreateTable
{
    public class CreateDocuments : AbstractSqlCommand
    {
        protected override string Sql
        {
            get
            {
                return
                    @"CREATE TABLE [dbo].[Documents](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
                    [DocumentId] [int] NULL,
	                [InvoiceId] [int] NOT NULL,
	                [DocTypeCode] [nvarchar](50) NULL,
	                [BlancCode] [nvarchar](50) NULL,
	                [Number] [nvarchar](50) NULL,
	                [Seria] [nvarchar](50) NULL,
	                [Date] [date] NULL,
                 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]";
            }
        }
    }
}
