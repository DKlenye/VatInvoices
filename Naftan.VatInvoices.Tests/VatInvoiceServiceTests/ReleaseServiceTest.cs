using System;
using System.Linq;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.VatInvoiceServiceTests
{
    public class ReleaseServiceTest
    {

        private IVatInvoiceService service = new Impl.VatInvoiceService();

        [Test]
        public void LoadVatInvoicesDtoTest()
        {
           var i =  service.LoadVatInvoices(201605);
        }

        [Test]
        public void LoadDocumentsTest()
        {
            var i = service.LoadDocuments(120);
        }

        [Test]
        public void LoadConsigneesTest()
        {
            var i = service.LoadConsignees(120);
        }
        [Test]
        public void LoadConsignorsTest()
        {
            var i = service.LoadConsignors(120);
        }
        [Test]
        public void LoadRostersTest()
        {
            var i = service.LoadRosterList(120);
        }

        [Test]
        public void SignAndSendTest()
        {
            var rezult = service.SignAndSend(133);
            Console.WriteLine(rezult.First().Message);
        }

       


    }
}
