
namespace Naftan.VatInvoices.Commands.DDL.CreateTable
{
    public class CreateVatInvoice:AbstractSqlCommand
    {
        protected override string Sql
        {
            get { return @"
CREATE TABLE [dbo].[VatInvoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[IsIncome] [bit] NOT NULL,
	[ReplicationSourceId] [int] NULL,
	[ReplicationId] [int] NULL,
	[BuySaleTypeId] [tinyint] NOT NULL,
	[VatAccount] [nvarchar](8) NULL,
	[Account] [nvarchar](8) NULL,
	[AccountingDate] [date] NULL,
	[StatusId] [tinyint] NOT NULL,
    [StatusMessage] [nvarchar](200) NULL,
	[Sender] [nchar](9) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Number] [int] NOT NULL,
	[NumberString] [nchar](25) NOT NULL,
	[DateIssuance] [date] NULL,
	[DateTransaction] [date] NOT NULL,
	[InvoiceTypeId] [tinyint] NOT NULL,
	[OriginalInvoiceNumber] [nchar](25) NULL,
	[SendToRecipient] [bit] NULL,
	[DateCancelled] [date] NULL,
	[ProviderCounteragentId] [int] NULL,
	[ProviderStatusId] [tinyint] NULL,
	[ProviderDependentPerson] [bit] NULL,
	[ProviderResidentsOfOffshore] [bit] NULL,
	[ProviderSpecialDealGoods] [bit] NULL,
	[ProviderBigCompany] [bit] NULL,
	[ProviderCountryCode] [int] NULL,
	[ProviderUnp] [nchar](9) NULL,
	[ProviderBranchCode] [nvarchar](50) NULL,
	[ProviderName] [nvarchar](512) NULL,
	[ProviderAddress] [nvarchar](512) NULL,
	[PrincipalInvoiceNumber] [nchar](25) NULL,
	[PrincipalInvoiceDate] [date] NULL,
	[VendorInvoiceNumber] [nchar](25) NULL,
	[VendorInvoiceDate] [date] NULL,
	[ProviderDeclaration] [nvarchar](50) NULL,
	[DateRelease] [date] NULL,
	[DateActualExport] [date] NULL,
	[ProviderTaxeNumber] [nvarchar](50) NULL,
	[ProviderTaxeDate] [date] NULL,
	[RecipientCounteragentId] [int] NULL,
	[RecipientStatusId] [tinyint] NULL,
	[RecipientDependentPerson] [bit] NULL,
	[RecipientResidentsOfOffshore] [bit] NULL,
	[RecipientSpecialDealGoods] [bit] NULL,
	[RecipientBigCompany] [bit] NULL,
	[RecipientCountryCode] [int] NULL,
	[RecipientUnp] [nchar](9) NULL,
	[RecipientBranchCode] [nvarchar](50) NULL,
	[RecipientName] [nvarchar](512) NULL,
	[RecipientAddress] [nvarchar](512) NULL,
	[RecipientDeclaration] [nvarchar](50) NULL,
	[RecipientTaxeNumber] [nvarchar](50) NULL,
	[RecipientTaxeDate] [date] NULL,
	[DateImport] [date] NULL,
	[ContractId] [int] NULL,
	[ContractNumber] [nvarchar](50) NULL,
	[ContractDate] [date] NULL,
	[ContractDescription] [nvarchar](512) NULL,
	[RosterTotalCostVat] [decimal](18, 3) NULL,
	[RosterTotalExcise] [decimal](18, 3) NULL,
	[RosterTotalVat] [decimal](18, 3) NULL,
	[RosterTotalCost] [decimal](18, 3) NULL,
	[ApproveDate] [datetime] NULL,
	[ApproveUser] [nvarchar](100) NULL,
    [IsValidate] [bit] NULL
 CONSTRAINT [PK_VatInvoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]                
            "; }
        }
    }
}
