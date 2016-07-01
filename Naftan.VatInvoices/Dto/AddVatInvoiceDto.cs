using System;
using System.Xml.Serialization;

namespace Naftan.VatInvoices.Dto
{

    [Serializable,XmlRoot(ElementName = "Invoice",Namespace = "")]
    public class AddVatInvoiceParams
    {
        [XmlAttribute] public int ReplicationSourceId{get;set;}

        [XmlAttribute] public int ReplicationId{get;set;}
        [XmlAttribute] public bool IsApprove{get;set;}
        [XmlAttribute] public string ApproveUser{get;set;}
        [XmlAttribute] public short BuySaleType{get;set;}
        [XmlAttribute] public short InvoiceTypeId{get;set;}
        [XmlAttribute(DataType = "date")] public DateTime DateTransaction{get;set;}
        [XmlAttribute] public string VatAccount{get;set;}
        [XmlAttribute] public string Account{get;set;}
        [XmlAttribute(DataType = "date")] public DateTime AccountingDate{get;set;}
        [XmlAttribute] public string OriginalInvoiceNumber{get;set;}
        [XmlAttribute] public bool SendToRecipient{get;set;}
        [XmlAttribute(DataType = "date")] public DateTime DateCancelled{get;set;}
        [XmlIgnoreAttribute] public bool DateCancelledSpecified;

        [XmlAttribute] public int ProviderCounteragentId{get;set;}
        [XmlAttribute] public short ProviderStatusId{get;set;}
        [XmlAttribute] public bool ProviderDependentPerson{get;set;}
        [XmlAttribute] public bool ProviderResidentsOfOffshore{get;set;}
        [XmlAttribute] public bool ProviderSpecialDealGoods{get;set;}
        [XmlAttribute] public bool ProviderBigCompany{get;set;}
        [XmlAttribute] public int ProviderCountryCode{get;set;}
        [XmlAttribute] public string ProviderUnp{get;set;}
        [XmlAttribute] public string ProviderBranchCode{get;set;}
        [XmlAttribute] public string ProviderName{get;set;}
        [XmlAttribute] public string ProviderAddress{get;set;}
        [XmlAttribute] public string PrincipalInvoiceNumber{get;set;}

        [XmlAttribute(DataType = "date")] public DateTime PrincipalInvoiceDate{get;set;}
        [XmlIgnoreAttribute] public bool PrincipalInvoiceDateSpecified;

        [XmlAttribute] public string VendorInvoiceNumber{get;set;}

        [XmlAttribute(DataType = "date")] public DateTime VendorInvoiceDate{get;set;}
        [XmlIgnoreAttribute] public bool VendorInvoiceDateSpecified;

        [XmlAttribute] public string ProviderDeclaration{get;set;}

        [XmlAttribute(DataType = "date")] public DateTime DateRelease{get;set;}
        [XmlIgnoreAttribute] public bool DateReleaseSpecified;

        [XmlAttribute(DataType = "date")] public DateTime DateActualExport{get;set;}
        [XmlIgnoreAttribute] public bool DateActualExportSpecified;

        [XmlAttribute] public string ProviderTaxeNumber{get;set;}

        [XmlAttribute(DataType = "date")] public DateTime ProviderTaxeDate{get;set;}
        [XmlIgnoreAttribute] public bool ProviderTaxeDateSpecified;

        [XmlAttribute] public int RecipientCounteragentId{get;set;}
        [XmlIgnoreAttribute] public bool RecipientCounteragentIdSpecified;

        [XmlAttribute] public short RecipientStatusId{get;set;}
        [XmlAttribute] public bool RecipientDependentPerson{get;set;}
        [XmlAttribute] public bool RecipientResidentsOfOffshore{get;set;}
        [XmlAttribute] public bool RecipientSpecialDealGoods{get;set;}
        [XmlAttribute] public bool RecipientBigCompany{get;set;}
        [XmlAttribute] public int RecipientCountryCode{get;set;}
        [XmlIgnoreAttribute] public bool RecipientCountryCodeSpecified;

        [XmlAttribute] public string RecipientUnp{get;set;}
        [XmlAttribute] public string RecipientBranchCode{get;set;}
        [XmlAttribute] public string RecipientName{get;set;}
        [XmlAttribute] public string RecipientAddress{get;set;}
        [XmlAttribute] public string RecipientDeclaration{get;set;}
        [XmlAttribute] public string RecipientTaxeNumber{get;set;}
        [XmlAttribute(DataType = "date")] public DateTime RecipientTaxeDate{get;set;}
        [XmlIgnoreAttribute] public bool RecipientTaxeDateSpecified;

        [XmlAttribute(DataType = "date")] public DateTime DateImport{get;set;}
        [XmlIgnoreAttribute] public bool DateImportSpecified;

        [XmlAttribute] public int ContractId{get;set;}
        [XmlAttribute] public string ContractNumber{get;set;}
        [XmlAttribute(DataType = "date")] public DateTime ContractDate{get;set;}
        [XmlIgnoreAttribute] public bool ContractDateSpecified;
        [XmlAttribute] public string ContractDescription{get;set;}

    }
}
