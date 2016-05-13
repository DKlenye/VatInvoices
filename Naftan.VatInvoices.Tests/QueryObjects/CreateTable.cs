using Naftan.VatInvoices.QueryObjects;

namespace Naftan.VatInvoices.Tests.QueryObjects
{
    public class CreateTable
    {
        public QueryObject BuySaleType()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[BuySaleType](
	                [BuySaleTypeId] [tinyint] NOT NULL,
	                [BuySaleTypeName] [nvarchar](50) NOT NULL,
	                [BuySaleTypeShortName] [nvarchar](50) NOT NULL,
                 CONSTRAINT [PK_BuySaleType] PRIMARY KEY CLUSTERED 
                (
	                [BuySaleTypeId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject InvoiceStatus()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[InvoiceStatus](
	                [StatusId] [tinyint] NOT NULL,
	                [StatusName] [nvarchar](50) NOT NULL,
                 CONSTRAINT [PK_InvoiceStatus] PRIMARY KEY CLUSTERED 
                (
	                [StatusId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject InvoiceType()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[InvoiceType](
	                [InvoiceTypeId] [tinyint] NOT NULL,
	                [InvoiceTypeName] [nvarchar](50) NOT NULL,
	                [InvoiceTypeXmlName] [nvarchar](50) NOT NULL,
                 CONSTRAINT [PK_InvoiceType] PRIMARY KEY CLUSTERED 
                (
	                [InvoiceTypeId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject ProviderStatus()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[ProviderStatus](
	                [ProviderStatusId] [tinyint] NOT NULL,
	                [ProviderStatusName] [nvarchar](50) NOT NULL,
	                [ProviderStatusXmlName] [nvarchar](50) NOT NULL,
                 CONSTRAINT [PK_ProviderStatus] PRIMARY KEY CLUSTERED 
                (
	                [ProviderStatusId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject RecipientStatus()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[RecipientStatus](
	                [RecipientStatusId] [tinyint] NOT NULL,
	                [RecipientStatusName] [nvarchar](50) NOT NULL,
	                [RecipientStatusXmlName] [nvarchar](50) NOT NULL,
                 CONSTRAINT [PK_RecipientStatus] PRIMARY KEY CLUSTERED 
                (
	                [RecipientStatusId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject ReplicationSource()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[ReplicationSource](
	                [ReplicationSourceId] [int] NOT NULL,
	                [Name] [nvarchar](100) NOT NULL,
	                [XmlName] [nvarchar](50) NOT NULL,
	                [ServerName] [nvarchar](100) NOT NULL,
	                [DatabaseName] [nvarchar](100) NOT NULL,
	                [Description] [text] NULL,
                 CONSTRAINT [PK_ReplicationSource] PRIMARY KEY CLUSTERED 
                (
	                [ReplicationSourceId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                );
        }

        public QueryObject Replication()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[Replication](
	                [ReplicationSourceId] [int] NOT NULL,
	                [IsApprove] [bit] NULL,
	                [BuySaleTypeId] [tinyint] NOT NULL,
	                [VatAccount] [nvarchar](8) NULL,
	                [Account] [nvarchar](8) NOT NULL,
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
	                [ProviderName] [nvarchar](200) NULL,
	                [ProviderAddress] [nvarchar](200) NULL,
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
	                [RecipientName] [nvarchar](200) NULL,
	                [RecipientAddress] [nvarchar](200) NULL,
	                [RecipientDeclaration] [nvarchar](50) NULL,
	                [RecipientTaxeNumber] [nvarchar](50) NULL,
	                [RecipientTaxeDate] [date] NULL,
	                [DateImport] [date] NULL,
	                [ContractId] [int] NULL,
	                [ContractNumber] [nvarchar](50) NULL,
	                [ContractDate] [date] NULL,
	                [ContractDescription] [nvarchar](100) NULL,
	                [DocumentId] [int] NOT NULL,
	                [DocumentTypeCode] [nvarchar](50) NULL,
	                [DocumentTypeValue] [nvarchar](50) NULL,
	                [DocumentBlancCode] [nvarchar](50) NULL,
	                [DocumentNumber] [nvarchar](50) NULL,
	                [DocumentSeria] [nvarchar](50) NULL,
	                [DocumentDate] [date] NULL,
	                [ConsignorCounteragentId] [int] NULL,
	                [ConsignorCountryCode] [int] NULL,
	                [ConsignorUnp] [nchar](9) NULL,
	                [ConsignorName] [nvarchar](200) NULL,
	                [ConsignorAddress] [nvarchar](200) NULL,
	                [ConsigneeCounteragentId] [int] NULL,
	                [ConsigneeCountryCode] [int] NULL,
	                [ConsigneeUnp] [nchar](9) NULL,
	                [ConsigneeName] [nvarchar](200) NULL,
	                [ConsigneeAddress] [nvarchar](200) NULL,
	                [RosterNumber] [int] NOT NULL,
	                [RosterName] [nvarchar](100) NOT NULL,
	                [RosterCode] [nvarchar](10) NULL,
	                [RosterCodeOced] [nvarchar](5) NULL,
	                [RosterUnits] [nvarchar](50) NULL,
	                [RosterCount] [decimal](18, 6) NULL,
	                [RosterPrice] [decimal](18, 3) NULL,
	                [RosterCost] [decimal](18, 3) NOT NULL,
	                [RosterSummaExcise] [decimal](18, 3) NULL,
	                [RosterVatRate] [decimal](4, 2) NULL,
	                [RosterVatRateTypeId] [tinyint] NOT NULL,
	                [RosterSummaVat] [decimal](18, 3) NOT NULL,
	                [RosterCostVat] [decimal](18, 3) NULL,
	                [RosterDescription] [nvarchar](256) NULL
                ) ON [PRIMARY]"
                );
        }

        public QueryObject VatInvoice()
        {
            return new QueryObject(@"
                CREATE TABLE [dbo].[VatInvoice](
	                [InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	                [IsIncome] [bit] NOT NULL,
	                [ReplicationSourceId] [int] NULL,
	                [ReplicationId] [int] NULL,
	                [BuySaleTypeId] [tinyint] NOT NULL,
	                [VatAccount] [nvarchar](8) NULL,
	                [Account] [nvarchar](8) NULL,
	                [StatusId] [tinyint] NOT NULL,
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
	                [ProviderName] [nvarchar](200) NULL,
	                [ProviderAddress] [nvarchar](200) NULL,
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
	                [RecipientName] [nvarchar](200) NULL,
	                [RecipientAddress] [nvarchar](200) NULL,
	                [RecipientDeclaration] [nvarchar](50) NULL,
	                [RecipientTaxeNumber] [nvarchar](50) NULL,
	                [RecipientTaxeDate] [date] NULL,
	                [DateImport] [date] NULL,
	                [ContractId] [int] NULL,
	                [ContractNumber] [nvarchar](50) NULL,
	                [ContractDate] [date] NULL,
	                [ContractDescription] [nvarchar](100) NULL,
	                [RosterTotalCostVat] [decimal](18, 3) NULL,
	                [RosterTotalExcise] [decimal](18, 3) NULL,
	                [RosterTotalVat] [decimal](18, 3) NULL,
	                [RosterTotalCost] [decimal](18, 3) NULL,
	                [ApproveDate] [datetime] NULL,
	                [Xml] [xml] NULL,
                 CONSTRAINT [PK_VatInvoice] PRIMARY KEY CLUSTERED 
                (
	                [InvoiceId] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
                ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]"
                );
        }

        public QueryObject Consignees()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[Consignees](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ConsigneeCounteragentId] [int] NULL,
	                [InvoiceId] [int] NOT NULL,
	                [CountryCode] [int] NULL,
	                [Unp] [nchar](9) NULL,
	                [Name] [nvarchar](200) NULL,
	                [Address] [nvarchar](200) NULL,
                 CONSTRAINT [PK_Consignees] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject Consignors()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[Consignors](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ConsignorCounteragentId] [int] NULL,
	                [InvoiceId] [int] NOT NULL,
	                [CountryCode] [int] NULL,
	                [Unp] [nchar](9) NULL,
	                [Name] [nvarchar](200) NULL,
	                [Address] [nvarchar](200) NULL,
                 CONSTRAINT [PK_Consignors_1] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject Documents()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[Documents](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ReplicationId] [int] NOT NULL,
	                [InvoiceId] [int] NOT NULL,
	                [DocTypeCode] [nvarchar](50) NULL,
	                [DocTypeValue] [nvarchar](50) NULL,
	                [BlancCode] [nvarchar](50) NULL,
	                [Number] [nvarchar](50) NULL,
	                [Seria] [nvarchar](50) NULL,
	                [Date] [date] NULL,
                 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }

        public QueryObject RosterList()
        {
            return new QueryObject(
                @"CREATE TABLE [dbo].[RosterList](
	                [Id] [int] IDENTITY(1,1) NOT NULL,
	                [ReplicationId] [int] NULL,
	                [InvoiceId] [int] NOT NULL,
	                [Number] [int] NULL,
	                [Name] [nvarchar](100) NULL,
	                [Code] [nvarchar](10) NULL,
	                [CodeOced] [nvarchar](5) NULL,
	                [Units] [nvarchar](50) NULL,
	                [Count] [decimal](18, 6) NULL,
	                [Price] [decimal](18, 3) NULL,
	                [Cost] [decimal](18, 3) NULL,
	                [SummaExcise] [decimal](18, 3) NULL,
	                [VatRate] [decimal](4, 2) NULL,
	                [VatRateTypeId] [tinyint] NULL,
	                [SummaVat] [decimal](18, 3) NULL,
	                [CostVat] [decimal](18, 3) NULL,
	                [Description] [nvarchar](50) NULL,
                 CONSTRAINT [PK_RosterList] PRIMARY KEY CLUSTERED 
                (
	                [Id] ASC
                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                ) ON [PRIMARY]"
                );
        }
    }
}
