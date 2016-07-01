using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Schema;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Impl;
using Naftan.VatInvoices.Mnsati;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.VatInvoiceServiceTests
{
    public class ReleaseServiceTest
    {

        private readonly IVatInvoiceService service = new VatInvoiceService();

        [Test]
        public void LoadVatInvoicesDtoTest()
        {
           var i =  service.LoadVatInvoices(201605);
        }

        [Test]
        public void LoadDocumentsTest()
        {
            var i = service.LoadDocuments(120);
        }

        [Test]
        public void LoadConsigneesTest()
        {
            var i = service.LoadConsignees(120);
        }
        [Test]
        public void LoadConsignorsTest()
        {
            var i = service.LoadConsignors(120);
        }
        [Test]
        public void LoadRostersTest()
        {
            var i = service.LoadRosterList(120);
        }

        [Test]
        public void CancelApproveTest()
        {
            service.CancelApproveVatInvoice(118);
        }

        [Test]
        public void SignAndSendTest()
        {
            var rezult = service.SignAndSend(1248);
            Console.WriteLine(rezult.First().Message);
        }

        [Test]
        public void Sign2AndSendTest()
        {
            var rezult = service.SignAndSend(727);
            Console.WriteLine(rezult.First().Message);
        }


        [Test]
        public void CheckStatusTest()
        {
            var rez = service.CheckStatus();
            rez.ToList().ForEach(x=>Console.WriteLine("{0} {1} {2}",x.InvoiceId, x.NumberString,x.InvoiceStatus.ToString()));
        }

        [Test]
        public void ReceiveIncome()
        {
            var dto = service.ReceiveIncoming();
        }

        [Test]
        public void LoadAccountList()
        {
            var accounts = service.LoadAccountList(201604, "90,18");
            accounts.ToList().ForEach(x=>Console.WriteLine("{0}-{1}",x.FullAccount,x.LabelCostItem));
        }

        [Test]
        public void XsdValidate()
        {
            
            var xsdMap = new Dictionary<invoiceDocType, string>
            {
                {invoiceDocType.ORIGINAL, "Naftan.VatInvoices.Mnsati.xsd.MNSATI_original.xsd"},
                {invoiceDocType.FIXED, "Naftan.VatInvoices.Mnsati.xsd.MNSATI_fixed.xsd"},
                {invoiceDocType.ADDITIONAL, "Naftan.VatInvoices.Mnsati.xsd.MNSATI_additional.xsd"},
                {invoiceDocType.ADD_NO_REFERENCE, "Naftan.VatInvoices.Mnsati.xsd.MNSATI_add_no_reference.xsd"}
            };


            var invoiceId = 1253;
            var invoice = service.LoadVatInvoice(invoiceId);

            var serializer = new VatInvoiceSerializer();
            var invoiceXml = serializer.Serialize(invoice);
            var xml = XDocument.Parse(invoiceXml);

            var assembly = Assembly.Load("Naftan.VatInvoices");
            var xsdName = xsdMap[invoice.InvoiceType];

            using (var stream = assembly.GetManifestResourceStream(xsdName))
            {
                var schema = XmlSchema.Read(stream, null);
                var schemas = new XmlSchemaSet();
                schemas.Add(schema);

                bool errors = false;
                xml.Validate(schemas, (o, e) =>
                {
                    Console.WriteLine("{0}", e.Message);
                    errors = true;
                });
                Console.WriteLine("xml {0}", errors ? "did not validate" : "validated");
            }

        }

    }
}
