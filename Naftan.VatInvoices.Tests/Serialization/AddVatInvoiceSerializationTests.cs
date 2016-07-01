using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Serialization
{
    public class AddVatInvoiceSerializationTests
    {
        [Test]
        public void serializeTest()
        {
            var dto = new AddVatInvoiceParams
            {
                Account = "90090160",
                AccountingDate = DateTime.Now.Date,
                ApproveUser = "Имя пользователя",
                BuySaleType = (short)BuySaleType.Buy,
                DateTransaction = DateTime.Now,
                
                ContractDate = DateTime.Now.Date,
                ContractDateSpecified = true,
                ContractId = 1,
                ContractDescription = "",
                ContractNumber = "123.123/321",
                DateActualExport = DateTime.Now,
                DateActualExportSpecified = true,
                DateCancelled = DateTime.Now,
                DateImport = DateTime.Now,
                DateImportSpecified = true,
                DateRelease = DateTime.Now,
                DateReleaseSpecified = true,
                InvoiceTypeId = 1,
                IsApprove = true,
                OriginalInvoiceNumber = "123456789-2016-0000000001",
                PrincipalInvoiceDate = DateTime.Now,
                PrincipalInvoiceDateSpecified = true,
                PrincipalInvoiceNumber = "123456789-2016-0000000001",
                ProviderAddress = "Адрес",
                ProviderBigCompany = true,
                ProviderBranchCode = "",
                ProviderCounteragentId = 1,
                ProviderCountryCode = 112,
                ProviderDeclaration = "123123",
                ProviderDependentPerson = true,
                ProviderName = "Наименование поставщика",
                ProviderResidentsOfOffshore = true,
                ProviderSpecialDealGoods = false,
                ProviderStatusId = 1,
                ProviderTaxeDate = DateTime.Now,
                ProviderTaxeDateSpecified = true,
                ProviderTaxeNumber = "",
                ProviderUnp = "123456789",
                RecipientBigCompany = true,
                RecipientAddress = "",
                RecipientBranchCode = "11",
                RecipientCounteragentId = 12,
                RecipientCounteragentIdSpecified = true,
                RecipientCountryCode = 112,
                RecipientCountryCodeSpecified = true,
                RecipientDeclaration = "",
                RecipientDependentPerson = true,
                RecipientName = "Наименование получателя",
                RecipientResidentsOfOffshore = true,
                RecipientSpecialDealGoods = true,
                RecipientStatusId = 1,
                RecipientTaxeDate = DateTime.Now,
                RecipientTaxeDateSpecified = true,
                RecipientTaxeNumber = "",
                RecipientUnp = "123456789",
                ReplicationId = 1,
                ReplicationSourceId = 5,
                SendToRecipient = false,
                VatAccount = "90090160",
                VendorInvoiceDate = DateTime.Now,
                VendorInvoiceDateSpecified = true,
                VendorInvoiceNumber = "12344"
            };


            var list = new AddVatInvoiceDtoList();
            list.Invoices = new[] {dto,dto};

            var  serializer = new XmlSerializer(typeof(AddVatInvoiceDtoList));
            using (var stream = new StringWriter())
            using (
                var writer = XmlWriter.Create(stream,new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(writer, list);
                Console.WriteLine(stream.ToString());
            }

        }
    }
}
