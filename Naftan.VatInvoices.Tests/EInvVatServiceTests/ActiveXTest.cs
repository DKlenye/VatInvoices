using System;
using System.IO;
using System.Linq;
using System.Text;
using EInvVatService;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.EInvVatServiceTests
{
    public class ActiveXTest
    {
        public static Connector connector;
        public static int loginRezult;
        private const string portalUrl = "https://vat.gov.by:4443/InvoicesWS/services/InvoicesPort";
        private const string invoicePath = @"D:\GitHub\VatInvoices\Naftan.VatInvoices.Tests\Invoices\";

        private bool IsLogin
        {
            get { return loginRezult == 0; }
        }

        private void ThrowException(string exceptionType)
        {
            Console.Write(connector.LastError);
            throw new Exception(exceptionType);
        }

        private string XmlInvoice
        {
            get
            {
                var files = Directory.GetFiles(invoicePath);
                return files.First();
            }
        }

        [Test]
        public void LoginTest()
        {
            if (!IsLogin) ThrowException("Ошибка авторизации");
        }


        [Test]
        public void ConnectionTest()
        {
            if (connector.Connect[portalUrl] != 0) ThrowException("Ошибка подключения");
            if (connector.Disconnect != 0) ThrowException("Ошибка отключения");
        }

        [Test]
        public void CreateEdocTest()
        {
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoice] != 0) ThrowException("Ошибка чтения файла");
            Console.Write(eDoc.Document.GetData[0]);
        }

        [Test]
        public void SignTest()
        {
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoice] != 0) ThrowException("Ошибка чтения файла");
            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            Console.Write(eDoc.GetData[0]);
        }

        [Test]
        public void SaveToFileTest()
        {
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoice] != 0) ThrowException("Ошибка чтения файла");
            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            if (eDoc.SaveToFile[invoicePath + "edoc.xml"] != 0) ThrowException("Ошибка сохранения подписанного документа");
        }

        [Test]
        public void SendTest()
        {
            if (connector.Connect[portalUrl] != 0) ThrowException("Ошибка подключения");
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoice] != 0) ThrowException("Ошибка чтения файла");

            var z = eDoc.Document.GetData[0];
            var s = eDoc.Document.GetData[1];

            var z64 = Convert.ToBase64String(Encoding.Default.GetBytes(z));


            var zz = eDoc.Document.SetData[z64, 1];


            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            if (connector.SendEDoc[eDoc] != 0) ThrowException("Ошибка отправки");
        }

        [Test]
        public void TicketTest()
        {
            if (connector.Connect[portalUrl] != 0) ThrowException("Ошибка подключения");
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoice] != 0) ThrowException("Ошибка чтения файла");
            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            if (connector.SendEDoc[eDoc] != 0) ThrowException("Ошибка отправки");

            var ticket = connector.Ticket;

            if (ticket.Accepted != 0)
            {
                Console.Write("Ошибка сервиса: "+ticket.Message);
            }

        }
        
    }
}
