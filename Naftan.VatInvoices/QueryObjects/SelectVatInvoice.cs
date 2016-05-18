using System.Collections.Generic;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.QueryObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class SelectVatInvoice
    {
        /// <summary>
        /// Загузить все записи
        /// </summary>
        /// <returns></returns>
        public QueryObject All()
        {
            return new QueryObject(@"
                SELECT 

                       Sender as Unp,[Year],Number,
    
                        InvoiceId,
                        IsIncome,
                        ReplicationSourceId,
                        ReplicationId,
                        BuySaleTypeId  as BuySaleType,
                        AccountingDate, 
                        VatAccount, 
                        Account,
                        StatusId as Status, 
                        Sender,
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
                        [Xml] 
                  FROM VatInvoice
            ");
        }

        /// <summary>
        /// Загрузить одну запись по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QueryObject ById(int id)
        {
            return new QueryObject(All().Sql + " WHERE InvoiceId = @id",new { id });
        }

        public QueryObject ById(int[] ids)
        {
            return new QueryObject(All().Sql + "WHERE InvoiceId in (@ids) ", new { ids });
        }


        /// <summary>
        /// Загрузить одну запись по номеру ЭСЧФ
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public QueryObject ByNumber(string number)
        {
            return new QueryObject(All().Sql + " WHERE NumberString = @number",new { number });
        }


        /// <summary>
        ///  Загрузить ЭСЧФ нобходимые для проверки статуса на портале
        /// </summary>
        /// <returns></returns>
        public QueryObject ForCheck()
        {

            var statuses = new List<InvoiceStatus>
            {
                InvoiceStatus.COMPLETED
            };
            
            return new QueryObject(All().Sql + " WHERE  StattusId in @statuses", new {statuses });
        }
    }
}
