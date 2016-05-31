using System;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Mnsati;

namespace Naftan.VatInvoices.Converters
{
    public class RecipientConverter : IConverter<Recipient, recipient>
    {
        public Recipient To(recipient obj)
        {
            var recipient = new Recipient
            {
                RecipientStatus = obj.recipientStatus,
                RecipientDependentPerson = obj.dependentPerson,
                RecipientResidentsOfOffshore = obj.residentsOfOffshore,
                RecipientSpecialDealGoods = obj.specialDealGoods,
                RecipientBigCompany = obj.bigCompany,
                RecipientCountryCode = int.Parse(obj.countryCode),
                RecipientUnp = obj.unp,
                RecipientName = obj.name,
                RecipientAddress = obj.address,
                RecipientBranchCode = obj.branchCode,
                RecipientDeclaration = obj.declaration,
                DateImport = obj.dateImportSpecified ? obj.dateImport : (DateTime?)null,
            };

            if (obj.taxes != null)
            {
                recipient.RecipientTaxeDate = obj.taxes.date;
                recipient.RecipientTaxeNumber = obj.taxes.number;
            }

            return recipient;
        }

        public recipient From(Recipient obj)
        {
            return new recipient
            {
                address = obj.RecipientAddress,
                bigCompany = obj.RecipientBigCompany,
                branchCode = obj.RecipientBranchCode,
                countryCode = obj.RecipientCountryCode.ToString(),
                declaration = obj.RecipientDeclaration,
                dateImport = obj.DateImport ?? new DateTime(),
                dateImportSpecified = obj.DateImport != null,
                dependentPerson = obj.RecipientDependentPerson,
                name = obj.RecipientName,
                residentsOfOffshore = obj.RecipientResidentsOfOffshore,
                recipientStatus = obj.RecipientStatus,
                specialDealGoods = obj.RecipientSpecialDealGoods,
                taxes = obj.RecipientTaxeDate != null
                    ? new taxesType
                    {
                        date = obj.RecipientTaxeDate.Value,
                        number = obj.RecipientTaxeNumber
                    }
                    : null,
                unp = obj.RecipientUnp
            };
        }
    }
}
