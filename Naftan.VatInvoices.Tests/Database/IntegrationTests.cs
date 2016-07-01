using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Naftan.VatInvoices.Commands;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
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
            Assert.AreNotEqual(invoice.InvoiceId,0);
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

        [Test]
        public void AddVatInvoiceTest()
        {
            
            var xml = new XmlDocument();
            xml.Load(@"D:\GitHub\VatInvoices\Naftan.VatInvoices.Tests\Invoices\Add\InvoiceList.xml");

            var serializer = new XmlSerializer(typeof(AddVatInvoiceParams));
            
            foreach (XmlNode invoice in xml.SelectNodes(@"//Invoice"))
            {
                var documents = invoice.SelectSingleNode("//*[local-name()='Documents']");
                var consignees = invoice.SelectSingleNode("//*[local-name()='Consignees']");
                var consignors = invoice.SelectSingleNode("//*[local-name()='Consignors']");
                var rosterList = invoice.SelectSingleNode("//*[local-name()='RosterList']");

                invoice.RemoveChild(documents);
                invoice.RemoveChild(consignees);
                invoice.RemoveChild(consignors);
                invoice.RemoveChild(rosterList);

                var param = (AddVatInvoiceParams)serializer.Deserialize(new StringReader(invoice.OuterXml));

                Db.Execute(new AddVatInvoice(param, consignors, consignees, documents, rosterList));
                Db.Commit();
            }
           
            

        }
        
        
    }
}

    
