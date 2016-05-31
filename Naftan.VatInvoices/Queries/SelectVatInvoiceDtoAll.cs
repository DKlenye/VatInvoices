using System.Collections.Generic;
using System.Data;
using Dapper;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceDtoAll:IQuery<IEnumerable<VatInvoiceDto>>
    {
        protected virtual string Sql
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
                    ApproveDateExport
                FROM VatInvoice ";
            }
        }

        public virtual IEnumerable<VatInvoiceDto> Execute(IDbConnection db, IDbTransaction tx)
        {
            return db.Query<VatInvoiceDto>(Sql, transaction: tx);
        }


    }
}
