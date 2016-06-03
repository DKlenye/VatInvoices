using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices
{
    public class LoadInfo
    {
        public LoadInfo(VatInvoice invoice,string number, string xml, string signXml)
        {
            Invoice = invoice;
            SignXml = signXml;
            Xml = xml;
            Number = number;
        }

        public string Number { get; private set; }
        public string Xml { get; private set; }
        public string SignXml { get; private set; }
        public VatInvoice Invoice { get; private set; }
    }
}
