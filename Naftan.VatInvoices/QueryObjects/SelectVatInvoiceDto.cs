using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.QueryObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectVatInvoiceDto
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public QueryObject All()
        {
            return new QueryObject(@"
                SELECT
                    InvoiceId,
                    IsIncome, 
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
                    ApproveDate
                FROM VatInvoice
            ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryObject ById(int id)
        {
            return new QueryObject(All().Sql + " WHERE InvoiceId = {id}".ApplyTemplate(new {id}));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public QueryObject ByNumber(string number)
        {
            return new QueryObject(All().Sql + " WHERE NumberString = {number}".ApplyTemplate(new { number }));
        }
    }
}
