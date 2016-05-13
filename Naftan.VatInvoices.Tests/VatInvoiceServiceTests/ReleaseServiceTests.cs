using Naftan.VatInvoices.Impl;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.VatInvoiceServiceTests
{
    public class ReleaseServiceTests
    {

        private IVatInvoiceService service;

        [SetUp]
        public void SetUp()
        {
            service = new VatInvoiceService();
        }

        [Test]
        public void SelectVatINvoiceDtoTest()
        {
            var dto = service.LoadVatInvoices();
        }

        [Test]
        public void SelectDocumentsTest()
        {
            var dto = service.LoadDocuments(1);
        }

        [Test]
        public void SelectConsigneesTest()
        {
            var dto = service.LoadConsignees(1);
        }

        [Test]
        public void SelectConsignorsTest()
        {
            var dto = service.LoadConsignors(1);
        }


    }
}
