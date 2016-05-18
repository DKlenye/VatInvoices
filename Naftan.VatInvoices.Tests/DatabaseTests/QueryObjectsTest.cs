using System;
using System.Xml;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Impl;
using Naftan.VatInvoices.Queries;
using Naftan.VatInvoices.QueryObjects;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.DatabaseTests
{
    public class QueryObjectsTest:BaseTest
    {
        [Test]
        public void SelectVatInvoiceTest()
        {
            Connection.Query<VatInvoiceDto>(new SelectVatInvoiceDto().All());
        }

        [Test]
        public void SelectRosterTest()
        {
            Connection.Query<Roster>(new SelectRoster().All());
        }

        [Test]
        public void SelectConsigneeTest()
        {
            Connection.Query<Consignee>(new SelectConsignee().All());
        }

        [Test]
        public void SelectConsignorTest()
        {
            Connection.Query<Consignor>(new SelectConsignor().All());
        }

        [Test]
        public void InsertVatInvoiceTest()
        {
            var doc = new XmlDocument();
            doc.Load(
                @"D:\GitHub\VatInvoices\Naftan.VatInvoices.Tests\InInvoices\invoice-100023423-2016-0000000001.xml");

            var s = new VatInvoiceSerializer();

            var invoice = s.Deserialize(doc.OuterXml);
            new InsertVatInvoiceQuery(Connection, invoice).Query();

            var _invoice = new SelectVatInvoiceQuery(Connection, 1).Query();
            var str = s.Serialize(_invoice);
            
            Console.Write(str);

            
        }

    }
}
