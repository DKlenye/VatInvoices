namespace Naftan.VatInvoices
{
    public class LoadInfo
    {
        public LoadInfo(string number, string xml, string signXml)
        {
            SignXml = signXml;
            Xml = xml;
            Number = number;
        }

        public string Number { get; private set; }
        public string Xml { get; private set; }
        public string SignXml { get; private set; }
    }
}
