using System;
using System.Xml.Serialization;

namespace Naftan.VatInvoices.Dto
{
    [Serializable, XmlRoot(ElementName = "InvoiceList")]
    public class AddVatInvoiceDtoList
    {
        [XmlElement("Invoice")] public AddVatInvoiceParams[] Invoices;
    }
}
