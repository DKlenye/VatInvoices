
using System;

namespace Naftan.VatInvoices.Commands.DDL.CreateTable
{
    public class CreateVatInvoiceXml:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"
    CREATE TABLE [dbo].[VatInvoiceXml](
	[InvoiceId] [int] NOT NULL,
	[Xml] [xml] NOT NULL,
	[SignXml] [xml] NOT NULL,
	[Sign2Xml] [xml] NULL,
 CONSTRAINT [PK_VatInvoiceXml] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

"; }
        }
    }
}
