namespace Naftan.VatInvoices.Domain
{
    public class ReplicationSource
    {
        public int ReplicationSourceId { get; set; }
        public string Name { get; set; }
        public string XmlName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Description { get; set; }
    }
}
