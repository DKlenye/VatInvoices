using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoAll : AbstractSqlQuery<VatInvoiceDto>
    {
        protected override string Sql
        {
            get
            {
                return @"
             SELECT       
                    InvoiceId,
                    IsIncome, 
                    AccountingDate,
                    ReplicationSourceId, 
                    BuySaleTypeId as BuySaleType,
                    VatAccount, 
                    Account, 
                    StatusId as InvoiceStatus, 
                    StatusMessage,
                    Sender, 
                    NumberString,
                    DateIssuance, 
                    DateTransaction, 
                    InvoiceTypeId as InvoiceType, 
                    OriginalInvoiceNumber,
                    SendToRecipient, 
                    DateCancelled, 
                    ProviderCounteragentId, 
                    ProviderStatusId as ProviderStatus,
                    ProviderDependentPerson, 
                    ProviderResidentsOfOffshore,
                    ProviderSpecialDealGoods, 
                    ProviderBigCompany, 
                    ProviderCountryCode,
                    ProviderUnp, 
                    ProviderBranchCode, 
                    ProviderName, 
                    ProviderAddress,
                    PrincipalInvoiceNumber, 
                    PrincipalInvoiceDate, 
                    VendorInvoiceNumber,
                    VendorInvoiceDate,
                    ProviderDeclaration,
                    DateRelease,
                    DateActualExport,
                    ProviderTaxeNumber, 
                    ProviderTaxeDate,
                    RecipientCounteragentId,
                    RecipientStatusId as RecipientStatus, 
                    RecipientDependentPerson,
                    RecipientResidentsOfOffshore,
                    RecipientSpecialDealGoods,
                    RecipientBigCompany,
                    RecipientCountryCode,
                    RecipientUnp,
                    RecipientBranchCode,
                    RecipientName,
                    RecipientAddress,
                    RecipientDeclaration,
                    RecipientTaxeNumber,
                    RecipientTaxeDate,
                    DateImport,
                    ContractId, 
                    ContractNumber, 
                    ContractDate,
                    ContractDescription,
                    RosterTotalCostVat,
                    RosterTotalExcise, 
                    RosterTotalVat,
                    RosterTotalCost,
                    ApproveDate,
                    ApproveUser,
                    IsValidate
                FROM VatInvoice ";
            }
        }

    }
}
