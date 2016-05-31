
namespace Naftan.VatInvoices.Commands.DDL.CreateTable
{
    public class CreateRosterList:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"
            CREATE TABLE [dbo].[RosterList](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [InvoiceId] [int] NOT NULL,
	                [Number] [int] NULL,
	                [Name] [nvarchar](512) NULL,
	                [Code] [nvarchar](10) NULL,
	                [CodeOced] [nvarchar](5) NULL,
	                [Units] [int] NULL,
	                [Count] [decimal](18, 6) NULL,
	                [Price] [decimal](18, 3) NULL,
	                [Cost] [decimal](18, 3) NULL,
	                [SummaExcise] [decimal](18, 3) NULL,
	                [VatRate] [decimal](4, 2) NULL,
	                [VatRateTypeId] [tinyint] NULL,
	                [SummaVat] [decimal](18, 3) NULL,
	                [CostVat] [decimal](18, 3) NULL,
                 CONSTRAINT [PK_RosterList] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY];

            CREATE UNIQUE NONCLUSTERED INDEX [IX_RosterList] ON [dbo].[RosterList]
            (
	            [InvoiceId] ASC,
	            [Number] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];

"; }
        }
    }
}
