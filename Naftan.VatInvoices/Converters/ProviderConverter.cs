using System;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Converters
{
    public class ProviderConverter:IConverter<Provider,provider>
    {
        public Provider To(provider obj)
        {

            var provider =  new Provider
            {
                ProviderStatus = obj.providerStatus,
                ProviderDependentPerson = obj.dependentPerson,
                ProviderResidentsOfOffshore = obj.residentsOfOffshore,
                ProviderSpecialDealGoods = obj.specialDealGoods,
                ProviderBigCompany = obj.bigCompany,
                ProviderCountryCode = int.Parse(obj.countryCode),
                ProviderUnp = obj.unp,
                ProviderName = obj.name,
                ProviderAddress = obj.address,
                ProviderBranchCode = obj.branchCode,
                ProviderDeclaration = obj.declaration,
                DateActualExport = obj.dateActualExportSpecified ? obj.dateActualExport : (DateTime?) null,
                DateRelease = obj.dateReleaseSpecified ? obj.dateRelease : (DateTime?) null,
            };

            if (obj.vendor != null)
            {
                provider.VendorInvoiceNumber = obj.vendor.number;
                provider.VendorInvoiceDate = obj.vendor.date;
            }

            if (obj.principal != null)
            {
                provider.PrincipalInvoiceNumber = obj.principal.number;
                provider.PrincipalInvoiceDate = obj.principal.date;
            }

            if (obj.taxes != null)
            {
                provider.ProviderTaxeDate = obj.taxes.date;
                provider.ProviderTaxeNumber = obj.taxes.number;
            }

            return provider;


        }

        public provider From(Provider obj)
        {
            return new provider
            {
                address = obj.ProviderAddress,
                bigCompany = obj.ProviderBigCompany,
                branchCode = obj.ProviderBranchCode,
                countryCode = obj.ProviderCountryCode.ToString(),
                dateActualExport = obj.DateActualExport ?? new DateTime(),
                dateActualExportSpecified = obj.DateActualExport != null,
                dateRelease = obj.DateRelease ?? new DateTime(),
                dateReleaseSpecified = obj.DateRelease != null,
                declaration = obj.ProviderDeclaration,
                dependentPerson = obj.ProviderDependentPerson,
                name = obj.ProviderName,
                principal = obj.PrincipalInvoiceDate != null
                    ? new forInvoiceType
                    {
                        date = obj.PrincipalInvoiceDate.Value,
                        number = obj.PrincipalInvoiceNumber
                    }
                    : null,
                providerStatus = obj.ProviderStatus,
                residentsOfOffshore = obj.ProviderResidentsOfOffshore,
                specialDealGoods = obj.ProviderSpecialDealGoods,
                taxes = obj.ProviderTaxeDate != null
                    ? new taxesType()
                    {
                        date = obj.ProviderTaxeDate.Value,
                        number = obj.ProviderTaxeNumber
                    }
                    : null,
                unp = obj.ProviderUnp,
                vendor = obj.VendorInvoiceDate != null
                    ? new forInvoiceType
                    {
                        date = obj.VendorInvoiceDate.Value,
                        number = obj.VendorInvoiceNumber
                    }
                    : null
            };
        }
    }
}
