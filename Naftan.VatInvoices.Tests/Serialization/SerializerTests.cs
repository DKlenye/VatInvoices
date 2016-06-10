using System;
using System.IO;
using System.Text;
using System.Xml;
using Naftan.VatInvoices.Impl;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Serialization
{
    public class SerializerTests:BaseTest
    {

        private IVatInvoiceSerializer serializer;
        
        [SetUp]
        public void SetUp()
        {
            serializer = new VatInvoiceSerializer();
        }

        [Test]
        public void DeserializeTest()
        {
            var document = new XmlDocument();
            document.Load(XmlInvoicePath);
            var invoice = serializer.Deserialize(document.OuterXml);
            Console.Write(invoice.VatNumber.NumberString);
        }


        [Test]
        public void SerializeTest()
        {
            var xml = serializer.Serialize(VatInvoice);
            Console.Write(xml);
        }

        [Test]
        public void DeserializeSerializeShouldBeEqual()
        {
            var document = new XmlDocument();
            document.Load(XmlInvoicePath);

            var stream = new StringWriter();
            var xmlTextWriter = XmlWriter.Create(stream,
                new XmlWriterSettings {OmitXmlDeclaration = true, Indent = true});
            document.Save(xmlTextWriter);
            var xml = stream.ToString();
            
            var invoice = serializer.Deserialize(xml);
            var invoiceString = serializer.Serialize(invoice);

            Console.WriteLine(invoiceString);
            Console.WriteLine(xml);
            Assert.AreEqual(xml,invoiceString);

        }


    }
}
