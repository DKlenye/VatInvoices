using System.Xml;
using Naftan.VatInvoices.Impl;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.SerializationTests
{
    public class SaveXmlTest
    {
        [Test]
        public void GetXmlTest()
        {

            var serializer = new VatInvoiceSerializer();

            var doc = new XmlDocument();
            doc.Load(@"D:\GitHub\Tests\VatInvoices\Naftan.VatInvoices.Tests\InInvoices\invoice-100023423-2016-0000000001.xml");
            var z = serializer.Deserialize(doc.OuterXml);



        }
    }
}
