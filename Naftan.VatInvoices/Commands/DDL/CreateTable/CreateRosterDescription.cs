namespace Naftan.VatInvoices.Commands.DDL.CreateTable
{
    public class CreateRosterDescription : AbstractSqlCommand
    {
        protected override string Sql
        {
            get
            {
                return @"
                CREATE TABLE [dbo].[RosterDescription](
	            [RosterId] [int] NOT NULL,
	            [DescriptionTypeId] [int] NOT NULL,
             CONSTRAINT [PK_RosterDescription] PRIMARY KEY CLUSTERED 
            (
	            [RosterId] ASC,
	            [DescriptionTypeId] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
            ) ON [PRIMARY]            
            ";
            }
        }
    }
}
