using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati;
using Naftan.VatInvoices.Mnsati.Original;

namespace Naftan.VatInvoices.Tests
{
    public abstract class BaseTest
    {

        protected Consignee Consignee
        {
            get
            {
                return new Consignee
                {
                    Address = "ConsigneeAddress",
                    Name = "ConsigneeName",
                    Unp = "123456789",
                    CountryCode = 112
                };
            }
        }

        protected Consignor Consignor
        {
            get
            {
                return new Consignor
                {
                    Address = "ConsignorAddress",
                    Name = "ConsignorName",
                    Unp = "987654321",
                    CountryCode = 211
                };
            }
        }

        protected consignee consignee
        {
            get
            {
                return new consignee
                {
                    address = "ConsigneeAddress",
                    name = "ConsigneeName",
                    unp = "123456789",
                    countryCode = "112"
                };
            }
        }

        protected consignor consignor
        {
            get
            {
                return new consignor
                {
                    address = "ConsignorAddress",
                    name = "ConsignorName",
                    unp = "987654321",
                    countryCode = "211"
                };
            }
        }

        protected document document
        {
            get
            {
                return new document
                {
                    docType = new docType {code = "603"},
                    date = DateTime.Now.Date,
                    number = "123456",
                    seria = "АА",
                    blankCode = "654321"
                };
            }
        }

        protected provider provider
        {
            get
            {
                return new provider
                {
                    address = "ProviderAddress",
                    bigCompany = true,
                    dependentPerson = true,
                    residentsOfOffshore = false,
                    specialDealGoods = true,
                    unp = "123456789",
                    name = "ProviderName",
                    countryCode = "112",
                    branchCode = "12",
                    dateActualExportSpecified = true,
                    dateActualExport = DateTime.Now.Date,
                    dateReleaseSpecified = true,
                    dateRelease = DateTime.Now.AddDays(1).Date,
                    providerStatus = providerStatusType.SELLER,
                    declaration = "987654",
                    principal = new forInvoiceType {date = DateTime.Now.AddDays(2).Date, number = "665544"},
                    taxes = new taxesType {date = DateTime.Now.AddDays(3).Date, number = "77885544"},
                    vendor = new forInvoiceType {date = DateTime.Now.AddDays(4), number = "321654"}
                };
            }
        }

        protected recipient recipient
        {
            get
            {
                return new recipient
                {
                    address = "RecipientAddress",
                    bigCompany = false,
                    dependentPerson = true,
                    residentsOfOffshore = true,
                    specialDealGoods = false,
                    unp = "987564321",
                    name = "RecipientName",
                    countryCode = "211",
                    branchCode = "21",
                    declaration = "3578945",
                    taxes = new taxesType {date = DateTime.Now.AddDays(5).Date, number = "3355478"},
                    dateImport = DateTime.Now.AddDays(6).Date,
                    dateImportSpecified = true,
                    recipientStatus = recipientStatusType.CUSTOMER
                };
            }
        }

        protected rosterItem roster
        {
            get
            {
                return new rosterItem
                {
                    number = "0",
                    name = "RosterName",
                    code = "1123",
                    count = 5,
                    code_oced = "1232",
                    cost = 9993332.23m,
                    costVat = 22345m,
                    countSpecified = true,
                    price = 2212345.88m,
                    priceSpecified = true,
                    summaExciseSpecified = true,
                    summaExcise = 332345.567m,
                    units = "24",
                    vat = new vat
                    {
                        rate = 20,
                        rateType = rateType.DECIMAL,
                        summaVat = 223345.345m
                    },
                    descriptions = new []
                    {
                        descriptionType.DEDUCTION_IN_FULL,
                        descriptionType.OUTSIDE_RB,
                    }
                };
            }
        }

        public contract contract
        {
            get
            {
                return new contract
                {
                    date = DateTime.Now.AddDays(8).Date,
                    number = "222/34.45",
                    documents = new[]
                    {
                        document
                    }
                };
            }
        }

        public issuance original
        {
            get
            {
                return new issuance
                {
                    general = new general
                    {
                        dateIssuance = DateTime.Now.AddDays(7).Date,
                        dateIssuanceSpecified = true,
                        dateTransaction = DateTime.Now.AddDays(8).Date,
                        documentType = invoiceDocType.ORIGINAL,
                        number = "123456789-2016-1234567890"
                    },
                    provider = provider,
                    recipient = recipient,
                    deliveryCondition = new deliveryCondition
                    {
                        contract = contract,
                        description = "DeliveryDescription"
                    },
                    sender = "123456789",
                    senderReceiver = new senderReceiver
                    {
                        consignees = new[] {consignee, consignee},
                        consignors = new[] {consignor, consignor}
                    },
                    roster = new rosterList
                    {
                        totalCost = 123.44m,
                        totalVat = 222,
                        totalCostVat = 1234,
                        totalExcise = 2221,
                        rosterItem = new[]
                        {
                            roster,
                            roster
                        }
                    }
                };
            }
        }

        public VatInvoice VatInvoice
        {
            get
            {

                var roster1 = roster.ConvertTo<Roster>();
                var roster2 = roster.ConvertTo<Roster>();
                roster2.Number = 1;

                return new VatInvoice
                {
                    IsIncome = false,
                    Account = "90090100",
                    VatAccount = "1815123",
                    AccountingDate = DateTime.Now.Date, 
                    Provider = provider.ConvertTo<Provider>(),
                    Recipient = recipient.ConvertTo<Recipient>(),
                    VatNumber = new VatInvoiceNumber("123456789", 2016, 1),
                    Consignees = new[] {Consignee, Consignee},
                    Consignors = new[] {Consignor, Consignor},
                    InvoiceType = invoiceDocType.ORIGINAL,
                    ContractDate = DateTime.Now.Date,
                    ContractNumber = "123123",
                    ContractDescription = "TestDescription",
                    Documents = new[] {document.ConvertTo<Document>()},
                    Sender = "123456789",
                    RosterList = new[] {roster1, roster2},
                    DateTransaction = DateTime.Now.Date,
                    RosterTotalCost = 123,
                    RosterTotalExcise = 234,
                    RosterTotalCostVat = 345,
                    RosterTotalVat = 567
                };
            }
        }

        
        protected string getPath(string localPath)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var path = Uri.UnescapeDataString(new UriBuilder(codeBase).Path);
            var directory = new DirectoryInfo(Path.GetDirectoryName(path));

            return directory.Parent.Parent.FullName + localPath;
        }

        protected string XmlInvoicePath
        {
            get
            {
                return Directory.GetFiles(getPath("\\Invoices\\In")).First();
            }
        }

        protected string EInvoicePath
        {
            get
            {
                return getPath("\\Invoices\\Sign");
            }
        }
    }
}
