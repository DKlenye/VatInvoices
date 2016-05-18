using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati.Original;

namespace Naftan.VatInvoices.Impl
{
    public class VatInvoiceSerializer:IVatInvoiceSerializer
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

        private InvoiceType invoiceType
        {
            get
            {
                return SelectNode("documentType").InnerText.ConvertToEnum<InvoiceType>();
            }
        }


        public string Serialize(VatInvoice invoice)
        {
            string str="";

            if (invoice.InvoiceType == InvoiceType.ORIGINAL)
            {
                var serializer = new XmlSerializer(typeof(issuance));
                var stringwriter = new StringWriter();

                serializer.Serialize(stringwriter, invoice.ToIssuanceOriginal());
                str = stringwriter.ToString();

            }

            return str;
        }

        public VatInvoice Deserialize(string xml)
        {
            var invoice = new VatInvoice();
            document.LoadXml(xml);
            
            if (invoiceType == InvoiceType.ORIGINAL)
            {
                var serializer = new XmlSerializer(typeof(issuance));
                var o = (issuance)serializer.Deserialize(new StringReader(document.OuterXml));

                invoice = VatInvoice.FromIssuance(o);
            }

            return invoice;
        }
    }
}
