using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Queries
{
    public class SelectConsigneesByInvoiceId:AbstractSelectByInvoiceId<Consignee>
    {
        public SelectConsigneesByInvoiceId(int invoiceId) : base(invoiceId)
        {
        }
    }
}
