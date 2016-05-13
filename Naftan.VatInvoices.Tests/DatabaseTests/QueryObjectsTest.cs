using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati.Original;
using Naftan.VatInvoices.QueryObjects;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.DatabaseTests
{
    public class QueryObjectsTest:BaseTest
    {
        [Test]
        public void SelectVatInvoiceTest()
        {
            Connection.Query<VatInvoiceDto>(new SelectVatInvoiceDto().All());
        }

        [Test]
        public void SelectRosterTest()
        {
            Connection.Query<Roster>(new SelectRoster().All());
        }

        [Test]
        public void SelectConsigneeTest()
        {
            Connection.Query<Consignee>(new SelectConsignee().All());
        }

        [Test]
        public void SelectConsignorTest()
        {
            Connection.Query<Consignor>(new SelectConsignor().All());
        }

        [Test]
        public void InsertVatInvoiceTest()
        {
            var doc = new XmlDocument();
            doc.Load(
                @"D:\GitHub\VatInvoices\Naftan.VatInvoices.Tests\InInvoices\invoice-100023423-2016-0000000001.xml");
            var manager = new XmlNamespaceManager(doc.NameTable);
            manager.AddNamespace("ns", "http://www.w3schools.com");
            var z = doc.SelectSingleNode("//ns:documentType", manager);

            if (z.InnerText == "ORIGINAL")
            {
                var serializer = new XmlSerializer(typeof (issuance));
                string xmlString = doc.OuterXml;
                byte[] buffer = Encoding.UTF8.GetBytes(xmlString);
                var ms = new MemoryStream(buffer);
                XmlReader reader = new XmlTextReader(ms);
                var o = (issuance) serializer.Deserialize(reader);

                var invoice = VatInvoice.FromIssuance(o);
                Connection.Execute(new InsertVatInvoice().Query(invoice));

            }
        }

    }
}
