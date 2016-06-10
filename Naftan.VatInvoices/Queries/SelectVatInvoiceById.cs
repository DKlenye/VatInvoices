using System.Data;
using System.Linq;
using Dapper;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectVatInvoiceById:IQuery<VatInvoice>
    {
        public SelectVatInvoiceById(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public VatInvoice Execute(IDbConnection db, IDbTransaction tx)
        {
           var i =  db.Query<VatInvoiceNumber, Provider, Recipient, VatInvoice, VatInvoice>(
                @"
                       SELECT 

                       Sender as Unp,
                       [Year],
                       Number,

                        ProviderStatusId as ProviderStatus,
                        ProviderUnp, 
                        ProviderCounteragentId,
                                           
                        ProviderDependentPerson,
                        ProviderResidentsOfOffshore,                    
                        ProviderSpecialDealGoods, 
                        ProviderBigCompany, 
                        ProviderCountryCode,                 
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

                        RecipientStatusId as RecipientStatus,
                        RecipientUnp,
                        RecipientCounteragentId,                 
                        RecipientDependentPerson, 
                        RecipientResidentsOfOffshore,                  
                        RecipientSpecialDealGoods,
                        RecipientBigCompany,
                        RecipientCountryCode,                 
                        RecipientBranchCode,
                        RecipientName, 
                        RecipientAddress,                 
                        RecipientDeclaration, 
                        RecipientTaxeNumber, 
                        RecipientTaxeDate, 
                        DateImport,       

                        InvoiceId,
                        IsIncome,
                        ReplicationSourceId,
                        ReplicationId,
                        BuySaleTypeId  as BuySaleType,
                        VatAccount,                        
                        Account,
                        AccountingDate,
                        StatusId as Status, 
                        StatusMessage,
                        Sender,
                        DateIssuance, 
                        DateTransaction, 
                        InvoiceTypeId as InvoiceType, 
                        OriginalInvoiceNumber,                     
                        SendToRecipient,
                        DateCancelled, 
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
                  FROM VatInvoice where InvoiceId = @Id",
                       (number, provider, recipient, invoice) =>
                       {
                           invoice.VatNumber = number;
                           invoice.Provider = provider;
                           invoice.Recipient = recipient;
                           return invoice;
                       }, new{Id}, tx, splitOn: "ProviderStatus, RecipientStatus, InvoiceId").Single();

            i.Documents = new SelectDocumentsByInvoiceId(Id).Execute(db, tx);
            i.Consignees = new SelectConsigneesByInvoiceId(Id).Execute(db, tx);
            i.Consignors = new SelectConsignorsByInvoiceId(Id).Execute(db, tx);
            i.RosterList = new SelectRostersByInvoiceId(Id).Execute(db, tx);

            return i;
        }
    }
}
