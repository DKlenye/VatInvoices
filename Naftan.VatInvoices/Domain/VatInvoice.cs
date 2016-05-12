using System;
using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.Domain
{
    public class VatInvoice
    {

        public int InvoiceId { get; set; }

        public int? ReplicationSourceId { get; set; }

        public BuySaleType BuySaleType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public InvoiceType InvoiceType { get; set; }
        
        public bool InOut { get; set; }
        public int? ReplicationId { get; set; }
        public string VatAccount { get; set; }
        public string Account { get; set; }
        public string Sender { get; set; }
        public VatInvoiceNumber Number { get; set; }
        public DateTime? DateIssuance { get; set; }
        public DateTime DateTransaction { get; set; }
        public string OriginalInvoiceNumber { get; set; }
        public bool? SendToRecipient { get; set; }
        public DateTime? DateCancelled { get; set; }

        #region Provider (Поставщик)
        public int? ProviderCounteragentId { get; set; }
        public ProviderStatus ProviderStatus { get; set; }
        public bool? ProviderDependentPerson { get; set; }
        public bool? ProviderResidentsOfOffshore { get; set; }
        public bool? ProviderSpecialDealGoods { get; set; }
        public bool? ProviderBigCompany { get; set; }
        public int? ProviderCountryCode { get; set; }
        public string ProviderUnp { get; set; }
        public string ProviderBranchCode { get; set; }
        public string ProviderName { get; set; }
        public string ProviderAddress { get; set; }
        public string PrincipalInvoiceNumber { get; set; }
        public DateTime? PrincipalInvoiceDate { get; set; }
        public string VendorInvoiceNumber { get; set; }
        public DateTime? VendorInvoiceDate { get; set; }
        public string ProviderDeclaration { get; set; }
        public DateTime? DateRelease { get; set; }
        public DateTime? DateActualExport { get; set; }
        public string ProviderTaxeNumber { get; set; }
        public DateTime? ProviderTaxeDate { get; set; }
        #endregion

        #region Recipient(Получатель)
        public int? RecipientCounteragentId { get; set; }
        public RecipientStatus RecipientStatus { get; set; }
        public bool? RecipientDependentPerson { get; set; }
        public bool? RecipientResidentsOfOffshore { get; set; }
        public bool? RecipientSpecialDealGoods { get; set; }
        public bool? RecipientBigCompany { get; set; }
        public int? RecipientCountryCode { get; set; }
        public string RecipientUnp { get; set; }
        public string RecipientBranchCode { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientDeclaration { get; set; }
        public string RecipientTaxeNumber { get; set; }
        public DateTime? RecipientTaxeDate { get; set; }
        public DateTime? DateImport { get; set; }
        #endregion

        #region Contract(Договор)
        public int? ContractId { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractDescription { get; set; }
        #endregion

        public decimal? RosterTotalCostVat { get; set; }
        public decimal? RosterTotalExcise { get; set; }
        public decimal? RosterTotalVat { get; set; }
        public decimal? RosterTotalCost { get; set; }

        public DateTime? ApproveDate { get; set; }

        public string Xml { get; set; }

        public IEnumerable<Consignee> Consignees { get; set; }
        public IEnumerable<Consignor> Consignors { get; set; }
        public IEnumerable<Document> Documents { get; set; } 
        public IEnumerable<Roster> RosterList { get; set; }

        public void Approve()
        {
            if(!IsApprove) ApproveDate = DateTime.Now;
        }

        public bool IsApprove { get { return ApproveDate != null; } }
        
        /// <summary>
        /// Построить исходный ЭСЧФ из объекта по формату портала МНС
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static VatInvoice FromIssuance(Mnsati.Original.issuance original)
        {

            var general = original.general;
            var provider = original.provider;
            var recipient = original.recipient;
            var delivery = original.deliveryCondition;
            var contract = delivery.contract;
            var consignees = original.senderReceiver.consignees;
            var consignors = original.senderReceiver.consignors;
            var roster = original.roster;

            var invoice = new VatInvoice()
            {
                BuySaleType = BuySaleType.Buy,
                InOut = false,

                Sender = original.sender,
                Number = new VatInvoiceNumber(general.number),
                DateIssuance = general.dateIssuance,
                DateTransaction = general.dateTransaction,
                InvoiceType = general.documentType.ToString().ConvertToEnum<InvoiceType>(),

                ProviderStatus = provider.providerStatus.ToString().ConvertToEnum<ProviderStatus>(),
                ProviderDependentPerson = provider.dependentPerson,
                ProviderResidentsOfOffshore = provider.residentsOfOffshore,
                ProviderSpecialDealGoods = provider.specialDealGoods,
                ProviderBigCompany = provider.bigCompany,
                ProviderCountryCode = int.Parse(provider.countryCode),
                ProviderUnp = provider.unp,
                ProviderName = provider.name,
                ProviderAddress = provider.address,
                ProviderBranchCode = provider.branchCode,
                ProviderDeclaration = provider.declaration,
                DateActualExport = provider.dateActualExportSpecified ? provider.dateActualExport: (DateTime?) null,
                DateRelease = provider.dateReleaseSpecified?provider.dateRelease:(DateTime?) null,
                
                RecipientStatus = recipient.recipientStatus.ToString().ConvertToEnum<RecipientStatus>(),
                RecipientDependentPerson = recipient.dependentPerson,
                RecipientResidentsOfOffshore = recipient.residentsOfOffshore,
                RecipientSpecialDealGoods = recipient.specialDealGoods,
                RecipientBigCompany = recipient.bigCompany,
                RecipientCountryCode = int.Parse(recipient.countryCode),
                RecipientUnp = recipient.unp,
                RecipientName = recipient.name,
                RecipientAddress = recipient.address,
                RecipientBranchCode = recipient.branchCode,
                RecipientDeclaration = recipient.declaration,
                DateImport = recipient.dateImportSpecified ? recipient.dateImport : (DateTime?)null,

                ContractDate = contract.date,
                ContractNumber = contract.number,
                ContractDescription = delivery.description,
               
                Consignees = consignees.Select(c => new Consignee
                {
                        CountryCode = int.Parse(c.countryCode),
                        Name = c.name,
                        Address = c.address,
                        Unp = c.unp
                }).ToList(),

                Consignors = consignors.Select(c=>new Consignor
                {
                    CountryCode = int.Parse(c.countryCode),
                    Name = c.name,
                    Address = c.address,
                    Unp = c.unp
                }).ToList(),
               
                Documents = contract.documents.Select(d=>new Document
                {
                    BlancCode = d.blankCode,
                    Date = d.date,
                    DocTypeCode = d.docType.code,
                    DocTypeValue = d.docType.value,
                    Seria = d.seria,
                    Number = d.number
                }).ToList(),
                
                RosterTotalCost = roster.totalCost,
                RosterTotalCostVat = roster.totalCostVat,
                RosterTotalExcise = roster.totalExcise,
                RosterTotalVat = roster.totalVat,

               RosterList = roster.rosterItem.Select(r=>new Roster
               {
                    Code    = r.code,
                    CodeOced = r.code_oced,
                    Cost = r.cost,
                    CostVat = r.costVat,
                    Count = r.count,
                    Number = int.Parse(r.number),
                    Name = r.name,
                    Price = r.price,
                    SummaExcise = r.summaExcise,
                    SummaVat = r.vat.summaVat,
                    Units = r.units,
                    VatRate = r.vat.rate,
                    VatRateType = r.vat.rateType.ToString().ConvertToEnum<VatRateType>(),
                    Description = r.descriptions == null ? (RosterDescription?)null:r.descriptions.ToString().ConvertToEnum<RosterDescription>(),
               }).ToList()
               
            };

            if (recipient.taxes != null)
            {
                invoice.RecipientTaxeDate = recipient.taxes.date;
                invoice.RecipientTaxeNumber = recipient.taxes.number;
            }

            if (provider.vendor != null)
            {
                invoice.VendorInvoiceNumber = provider.vendor.number;
                invoice.VendorInvoiceDate = provider.vendor.date;
            }

            if (provider.principal != null)
            {
                invoice.PrincipalInvoiceNumber = provider.principal.number;
                invoice.PrincipalInvoiceDate = provider.principal.date;
            }

            if (provider.taxes != null)
            {
                invoice.ProviderTaxeDate = provider.taxes.date;
                invoice.ProviderTaxeNumber = provider.taxes.number;
            }

            
            return invoice;
        }

        /// <summary>
        /// Построить исходный ЭСЧФ из объекта по формату портала МНС
        /// </summary>
        /// <param name="additional"></param>
        /// <returns></returns>
        public static VatInvoice FromIssuance(Mnsati.Additional.issuance additional)
        {
            return new VatInvoice();
        }

    }
}
