using System.Linq;
using Naftan.VatInvoices.Commands;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Queries;
using Naftan.VatInvoices.Users;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Database
{
    public class IntegrationTests : BaseDatabaseTest
    {
        [Test]
        public void InsertVatInvoiceTest()
        {
            var invoice = VatInvoice;
            Db.Execute(new InsertVatInvoice(invoice));
            Db.Commit();
            Assert.AreEqual(invoice.InvoiceId, 1);
        }
        
        [Test]
        public void SelectVatInvoiceTest()
        {
            var invoice = Db.Execute(new SelectVatInvoiceById(1));
            Db.Commit();
        }


        [Test]
        public void SelectVatInvoiceDtoTest()
        {
            var invoice = Db.Execute(new SelectVatInvoiceDtoAll());
            Db.Commit();
        }

        [Test]
        public void SelectVatInvoiceDtoByNumberTest()
        {
            var invoice = Db.Execute(new SelectVatInvoiceDtoByNumber(VatInvoice.VatNumber.NumberString));
            Db.Commit();
            Assert.IsNotNull(invoice);
        }

        [Test]
        public void UpdateVatInvoiceTest()
        {
            var invoice = Db.Execute(new SelectVatInvoiceById(1));
            invoice.Approve(CurrentUser.Name);
            invoice.SetStatus(InvoiceStatus.IN_PROGRESS_ERROR,"Сообщение об ошибке");

            invoice.RosterList = invoice.RosterList.ToList().Where(x => x.Id == 1).ToList();
            
            Db.Execute(new UpdateVatInvoice(invoice));
            Db.Commit();
            
            var updates = Db.Execute(new SelectVatInvoiceById(1));
            Db.Commit();
        }
        
    }
}

    
