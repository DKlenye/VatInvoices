using System;
using System.Linq;
using EInvVatService;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Impl;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.PortalTests
{
    public class PortalServiceTests
    {
        private readonly IPortalService service = new PortalService(
            VatInvoiceService.PortalUrl,
            new Connector(),
            new VatInvoiceSerializer()
            );

        [Test]
        public void CheckStatusTest()
        {
            var info = service.CheckStatus(new VatInvoiceDto
            {
                NumberString = "300042199-2016-0000000001"
            });

            Assert.AreEqual(
                info.First().Status.ConvertToEnum<InvoiceStatus>(),
                InvoiceStatus.CANCELLED);

        }

        [Test]
        public void LoadIncomeVatInvoicesTest()
        {
            service.LoadIncomeVatInvoice(DateTime.Now);
        }


    }
}
