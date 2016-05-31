using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class UpdateVatInvoiceXml:AbstractUpdateCommand<VatInvoiceXml>
    {
        public UpdateVatInvoiceXml(VatInvoiceXml entity) : base(entity)
        {
        }
    }
}
