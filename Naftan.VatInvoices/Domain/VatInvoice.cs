using System;
using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati.Original;

namespace Naftan.VatInvoices.Domain
{
    /// <summary>
    /// ЭСЧФ
    /// </summary>
    public class VatInvoice
    {

        public int InvoiceId { get; set; }

        public int? ReplicationSourceId { get; set; }

        public BuySaleType BuySaleType { get; set; }
        public InvoiceStatus Status { get; set; }
        public InvoiceType InvoiceType { get; set; }

        public object IsIncome { get; set; }
        public int? ReplicationId { get; set; }
        public string VatAccount { get; set; }
        public DateTime AccountingDate { get; set; }
        public string Account { get; set; }
        public string Sender { get; set; }
        public VatInvoiceNumber VatNumber { get; set; }
        public DateTime? DateIssuance { get; set; }
        public DateTime? DateTransaction { get; set; }
        public string OriginalInvoiceNumber { get; set; }
        public bool? SendToRecipient { get; set; }
        public DateTime? DateCancelled { get; set; }

        #region Provider (Поставщик)
        public int? ProviderCounteragentId { get; set; }
        public ProviderStatus ProviderStatus { get; set; }
        public bool ProviderDependentPerson { get; set; }
        public bool ProviderResidentsOfOffshore { get; set; }
        public bool ProviderSpecialDealGoods { get; set; }
        public bool ProviderBigCompany { get; set; }
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
        public bool RecipientDependentPerson { get; set; }
        public bool RecipientResidentsOfOffshore { get; set; }
        public bool RecipientSpecialDealGoods { get; set; }
        public bool RecipientBigCompany { get; set; }
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
        public DateTime ContractDate { get; set; }
        public string ContractDescription { get; set; }
        #endregion

        public decimal RosterTotalCostVat { get; set; }
        public decimal RosterTotalExcise { get; set; }
        public decimal RosterTotalVat { get; set; }
        public decimal RosterTotalCost { get; set; }

        public DateTime? ApproveDate { get; set; }
        public string ApproveUser { get; set; }

        public string Xml { get; set; }

        public IEnumerable<Consignee> Consignees { get; set; }
        public IEnumerable<Consignor> Consignors { get; set; }
        public IEnumerable<Document> Documents { get; set; } 
        public IEnumerable<Roster> RosterList { get; set; }

            
        /// <summary>
        /// Подтверждение счёта фактуры для передачи на портал МНС
        /// </summary>
        public void Approve(string user)
        {
            if (!IsApprove)
            {
                ApproveDate = DateTime.Now;
                ApproveUser = user;
            }

        }

        public bool IsApprove { get { return ApproveDate != null; } }
        

        public void SetStatus(InvoiceStatus status)
        {
            Status = status;
        }


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

            var invoice = new VatInvoice
            {
                BuySaleType = BuySaleType.Buy,
                IsIncome = true,

                Sender = original.sender,
                VatNumber = new VatInvoiceNumber(general.number),
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

        public Mnsati.Original.issuance ToIssuanceOriginal()
        {
            var issuance = new issuance
            {
                sender = Sender,
                general = new general
                {
                    //dateIssuance = DateIssuance??new DateTime(),
                    dateTransaction = DateTransaction??new DateTime(),
                    dateTransactionSpecified = DateTransaction!=null,
                    documentType = invoiceDocType.ORIGINAL,
                    number = VatNumber.NumberString
                },
                provider = new provider
                {
                    address = ProviderAddress,
                    bigCompany = ProviderBigCompany,
                    branchCode = ProviderBranchCode,
                    countryCode = ProviderCountryCode.ToString(),
                    dateActualExport = DateActualExport ?? new DateTime(),
                    dateActualExportSpecified = DateActualExport != null,
                    dateRelease = DateRelease ?? new DateTime(),
                    dateReleaseSpecified = DateRelease != null,
                    declaration = ProviderDeclaration,
                    dependentPerson = ProviderDependentPerson,
                    name = ProviderName,
                    principal = PrincipalInvoiceDate != null
                        ? new forInvoiceType
                        {
                            date = PrincipalInvoiceDate.Value,
                            number = PrincipalInvoiceNumber
                        }
                        : null,
                    providerStatus = ProviderStatus.ToString().ConvertToEnum<providerStatusType>(),
                    residentsOfOffshore = ProviderResidentsOfOffshore,
                    specialDealGoods = ProviderSpecialDealGoods,
                    taxes = ProviderTaxeDate != null
                        ? new taxesType()
                        {
                            date = ProviderTaxeDate.Value,
                            number = ProviderTaxeNumber
                        }
                        : null,
                    unp = ProviderUnp,
                    vendor = VendorInvoiceDate != null
                        ? new forInvoiceType
                        {
                            date = VendorInvoiceDate.Value,
                            number = VendorInvoiceNumber
                        }
                        : null
                },
                recipient = new recipient
                {
                    address = RecipientAddress,
                    bigCompany = RecipientBigCompany,
                    branchCode = RecipientBranchCode,
                    countryCode = RecipientCountryCode.ToString(),
                    declaration = RecipientDeclaration,
                    dateImport = DateImport ?? new DateTime(),
                    dateImportSpecified = DateImport != null,
                    dependentPerson = RecipientDependentPerson,
                    name = RecipientName,
                    residentsOfOffshore = RecipientResidentsOfOffshore,
                    recipientStatus = RecipientStatus.ToString().ConvertToEnum<recipientStatusType>(),
                    specialDealGoods = RecipientSpecialDealGoods,
                    taxes = RecipientTaxeDate != null
                        ? new taxesType
                        {
                            date = RecipientTaxeDate.Value,
                            number = RecipientTaxeNumber
                        }
                        : null,
                    unp = RecipientUnp
                },
                deliveryCondition = new deliveryCondition
                {
                    contract = new contract
                    {
                        date = ContractDate,
                        number = ContractNumber,
                        documents = Documents.Select(x => new document
                        {
                            blankCode = x.BlancCode,
                            date = x.Date,
                            number = x.Number,
                            seria = x.Seria,
                            docType = new docType
                            {
                                code = x.DocTypeCode,
                                value = x.DocTypeValue
                            }
                        }).ToArray()
                    },
                    description = ContractDescription
                },
                senderReceiver = new senderReceiver
                {
                    consignees = Consignees.Select(c => new consignee
                    {
                        address = c.Address,
                        countryCode = c.CountryCode.ToString(),
                        name = c.Name,
                        unp = c.Unp
                    }).ToArray(),
                    consignors = Consignors.Select(c => new consignor
                    {
                        address = c.Address,
                        countryCode = c.CountryCode.ToString(),
                        name = c.Name,
                        unp = c.Unp
                    }).ToArray(),
                },
                roster = new rosterList
                {
                    totalCost = RosterTotalCost,
                    totalCostVat = RosterTotalCostVat,
                    totalExcise = RosterTotalExcise,
                    totalVat = RosterTotalVat,
                    rosterItem = RosterList.Select(r => new rosterItem
                    {
                        code = r.Code,
                        code_oced = r.CodeOced,
                        cost = r.Cost,
                        costVat = r.CostVat,
                        count = r.Count ?? 0,
                        countSpecified = r.Count != null,
                        descriptions =
                            r.Description == null
                                ? null
                                : new[] {r.Description.ToString().ConvertToEnum<descriptionType>()},
                        name = r.Name,
                        number = r.Number.ToString(),
                        price = r.Price ?? 0,
                        priceSpecified = r.Price != null,
                        summaExcise = r.SummaExcise ?? 0,
                        summaExciseSpecified = r.SummaExcise != null,
                        units = r.Units,
                        vat = new vat
                        {
                            rate = r.VatRate,
                            rateType = r.VatRateType.ToString().ConvertToEnum<rateType>(),
                            summaVat = r.SummaVat
                        }

                    }).ToArray()
                }

            };

            return issuance;

        }


    }
}
