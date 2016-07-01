using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati;
using Naftan.VatInvoices.Mnsati.Original;

namespace Naftan.VatInvoices.Impl
{
    public class VatInvoiceSerializer : IVatInvoiceSerializer
    {
        private const string nameSpace = "http://www.w3schools.com";
        private const string ns = "ns";

        private readonly XmlDocument document;
        private readonly XmlNamespaceManager manager;

        public VatInvoiceSerializer()
        {
            document = new XmlDocument();
            manager = new XmlNamespaceManager(document.NameTable);
            manager.AddNamespace(ns, nameSpace);
        }

        private XmlNode SelectNode(string name)
        {
            return document.SelectSingleNode(string.Format("//{0}:{1}", ns, name), manager);
        }

        private invoiceDocType invoiceType
        {
            get
            {
                return SelectNode("documentType").InnerText.ConvertToEnum<invoiceDocType>();
            }
        }


        public string Serialize(VatInvoice invoice)
        {
            XmlSerializer serializer;
            object issuance;
            switch (invoice.InvoiceType)
            {
                case invoiceDocType.ORIGINAL:
                {
                    serializer = new XmlSerializer(typeof (issuance));
                    issuance = invoice.ConvertTo<issuance>();
                    break;

                }
                case invoiceDocType.ADDITIONAL:
                {
                    serializer = new XmlSerializer(typeof (Mnsati.Additional.issuance));
                    issuance = invoice.ConvertTo<Mnsati.Additional.issuance>();
                    break;
                }
                case invoiceDocType.ADD_NO_REFERENCE:
                {
                    serializer = new XmlSerializer(typeof (Mnsati.AddNoReference.issuance));
                    issuance = invoice.ConvertTo<Mnsati.AddNoReference.issuance>();
                    break;
                }
                case invoiceDocType.FIXED:
                {
                    serializer = new XmlSerializer(typeof (Mnsati.Fixed.issuance));
                    issuance = invoice.ConvertTo<Mnsati.Fixed.issuance>();
                    break;
                }
                default:
                {
                   serializer = new XmlSerializer(typeof (issuance));
                    issuance = invoice.ConvertTo<issuance>();
                    break;
                }
            }
            


            using (var stream = new StringWriter())
            using (
                var writer = XmlWriter.Create(stream, new XmlWriterSettings {OmitXmlDeclaration = true, Indent = true}))
            {
                serializer.Serialize(writer, issuance);
                return stream.ToString();
            }
        }

        public VatInvoice Deserialize(string xml)
        {

            byte[] encodedString = Encoding.UTF8.GetBytes(xml);

            // Put the byte array into a stream and rewind it to the beginning
            var ms = new MemoryStream(encodedString);
            ms.Flush();
            ms.Position = 0;

            var invoice = new VatInvoice();
            document.Load(ms);
            XmlSerializer serializer;

            switch (invoiceType)
            {
                case invoiceDocType.ORIGINAL:
                    {
                        serializer = new XmlSerializer(typeof(issuance));
                        var issuance = (issuance)serializer.Deserialize(new StringReader(document.OuterXml));
                        invoice = issuance.ConvertTo<VatInvoice>();
                        break;
                    }
                case invoiceDocType.ADDITIONAL:
                    {
                        serializer = new XmlSerializer(typeof(Mnsati.Additional.issuance));
                        var issuance = (Mnsati.Additional.issuance)serializer.Deserialize(new StringReader(document.OuterXml));
                        invoice = issuance.ConvertTo<VatInvoice>();
                        break;
                    }
                case invoiceDocType.ADD_NO_REFERENCE:
                    {
                        serializer = new XmlSerializer(typeof(Mnsati.AddNoReference.issuance));
                        var issuance = (Mnsati.AddNoReference.issuance)serializer.Deserialize(new StringReader(document.OuterXml));
                        invoice = issuance.ConvertTo<VatInvoice>();
                        break;
                    }
                case invoiceDocType.FIXED:
                    {
                        serializer = new XmlSerializer(typeof(Mnsati.Fixed.issuance));
                        var issuance = (Mnsati.Fixed.issuance)serializer.Deserialize(new StringReader(document.OuterXml));
                        invoice = issuance.ConvertTo<VatInvoice>();
                        break;
                    }

            }

            return invoice;
        }
    }
}
