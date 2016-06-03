using System;
using System.IO;
using System.Linq;
using EInvVatService;
using Naftan.VatInvoices.Impl;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.EInvVatService
{
    public class ActiveXTest:BaseTest
    {
        public static Connector connector;
        public static int loginRezult;
        private readonly string portalUrl = VatInvoiceService.PortalUrl;

        private bool IsLogin
        {
            get { return loginRezult == 0; }
        }

        private void ThrowException(string exceptionType)
        {
            Console.Write(connector.LastError);
            throw new Exception(exceptionType);
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
            if (eDoc.Document.LoadFromFile[XmlInvoicePath] != 0) ThrowException("Ошибка чтения файла");
            Console.Write(eDoc.Document.GetData[0]);
        }

        [Test]
        public void SignTest()
        {
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoicePath] != 0) ThrowException("Ошибка чтения файла");
            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            Console.Write(eDoc.Document.GetData[0]);
            Console.Write(eDoc.GetData[0]);
        }

        [Test]
        public void SaveToFileTest()
        {
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoicePath] != 0) ThrowException("Ошибка чтения файла");
            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            var path = EInvoicePath + "\\edoc.xml";
            Directory.GetFiles(EInvoicePath).ToList().ForEach(File.Delete);
            if (eDoc.SaveToFile[path] != 0) ThrowException("Ошибка сохранения подписанного документа");
        }

        [Test]
        public void SendTest()
        {
            if (connector.Connect[portalUrl] != 0) ThrowException("Ошибка подключения");
            var eDoc = connector.CreateEDoc;
            if (eDoc.Document.LoadFromFile[XmlInvoicePath] != 0) ThrowException("Ошибка чтения файла");
            if (eDoc.Sign[0] != 0) ThrowException("Ошибка подписи");
            if (connector.SendEDoc[eDoc] != 0) ThrowException("Ошибка отправки");
        }

        [Test]
        public void GetListTest()
        {
            var date = new DateTime(2016, 04, 02);

            if (connector.Connect[portalUrl] != 0) ThrowException("Ошибка подключения");
            var list = connector.GetList[date.ToString("s")];
            if (list == null) ThrowException("Ошибка получения списка ЭСЧФ");
            var listCount = list.Count;
            Console.Write("{0}, {1}",list.ToDate,listCount);
        }

        
    }
}
