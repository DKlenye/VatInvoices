using System;
using System.Linq;
using Naftan.VatInvoices.Impl;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.VatInvoiceServiceTests
{
    public class ReleaseServiceTest
    {

        private readonly IVatInvoiceService service = new VatInvoiceService();

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
            var rezult = service.SignAndSend(120);
            Console.WriteLine(rezult.First().Message);
        }

        [Test]
        public void Sign2AndSendTest()
        {
            var rezult = service.SignAndSend(727);
            Console.WriteLine(rezult.First().Message);
        }


        [Test]
        public void CheckStatusTest()
        {
            service.CheckStatus();
        }

        [Test]
        public void ReceiveIncome()
        {
            service.ReceiveIncoming();
        }
        

    }
}
