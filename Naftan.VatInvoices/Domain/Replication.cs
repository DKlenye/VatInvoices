using System;

namespace Naftan.VatInvoices.Domain
{
    public class Replication
    {
        public int ReplicationSourceId { get; set; }
        public BuySaleType BuySaleType { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public ProviderStatus ProviderStatus { get; set; }
        public RecipientStatus RecipientStatus { get; set; }
        public bool? IsApprove { get; set; }
        public string VatAccount { get; set; }
        public string Account { get; set; }
        public DateTime DateTransaction { get; set; }
        public string OriginalInvoiceNumber { get; set; }
        public bool? SendToRecipient { get; set; }
        public DateTime? DateCancelled { get; set; }
        public int? ProviderCounteragentId { get; set; }
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
        public int? RecipientCounteragentId { get; set; }
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
        public int? ContractId { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractDescription { get; set; }
        public int DocumentId { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeValue { get; set; }
        public string DocumentBlancCode { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentSeria { get; set; }
        public DateTime? DocumentDate { get; set; }
        public int? ConsignorCounteragentId { get; set; }
        public int? ConsignorCountryCode { get; set; }
        public string ConsignorUnp { get; set; }
        public string ConsignorName { get; set; }
        public string ConsignorAddress { get; set; }
        public int? ConsigneeCounteragentId { get; set; }
        public int? ConsigneeCountryCode { get; set; }
        public string ConsigneeUnp { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public int RosterNumber { get; set; }
        public string RosterName { get; set; }
        public string RosterCode { get; set; }
        public string RosterCodeOced { get; set; }
        public string RosterUnits { get; set; }
        public decimal? RosterCount { get; set; }
        public decimal? RosterPrice { get; set; }
        public decimal RosterCost { get; set; }
        public decimal? RosterSummaExcise { get; set; }
        public decimal? RosterVatRate { get; set; }
        public byte RosterVatRateTypeId { get; set; }
        public decimal RosterSummaVat { get; set; }
        public decimal? RosterCostVat { get; set; }
        public string RosterDescription { get; set; }
    }
}
