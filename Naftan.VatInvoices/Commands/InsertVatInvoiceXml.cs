using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class InsertVatInvoiceXml : AbstractInsertCommand<VatInvoiceXml>
    {
        public InsertVatInvoiceXml(VatInvoiceXml entity) : base(entity)
        {
        }
    }
}
