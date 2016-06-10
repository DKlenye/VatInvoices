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
        public void CancelApproveTest()
        {
            service.CancelApproveVatInvoice(118);
        }

        [Test]
        public void SignAndSendTest()
        {
            var rezult = service.SignAndSend(131);
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
            var rez = service.CheckStatus();
            rez.ToList().ForEach(x=>Console.WriteLine("{0} {1} {2}",x.InvoiceId, x.NumberString,x.InvoiceStatus.ToString()));
        }

        [Test]
        public void ReceiveIncome()
        {
            var dto = service.ReceiveIncoming();
        }

        [Test]
        public void LoadAccountList()
        {
            var accounts = service.LoadAccountList(201604, "90,18");
            accounts.ToList().ForEach(x=>Console.WriteLine("{0}-{1}",x.FullAccount,x.LabelCostItem));
        }

    }
}
