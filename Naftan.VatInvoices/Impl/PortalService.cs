using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EInvVatService;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Impl
{
    public class PortalService : IPortalService
    {
        public static string portalUrl = "https://vat.gov.by:4443/InvoicesWS/services/InvoicesPort";

        private bool isLogged;
        private readonly Connector connector;
        private readonly IVatInvoiceSerializer serializer;

        public PortalService()
        {
            connector = new Connector();
            serializer = new VatInvoiceSerializer();
        }

        private void Login()
        {
            if (!isLogged)
            {
                if (connector.Login["", 0] != 0) ThrowException("Ошибка авторизации");
                isLogged = true;
            }
        }

        private void Connect()
        {
            Login();
            if (connector.Connect[portalUrl] != 0) ThrowException("Ошибка подключения");
        }

        private void Disconnect()
        {
            if (connector.Disconnect != 0) ThrowException("Ошибка отключения");
        }

        private string ExceptionMessage(string message)
        {
            return String.Format("{0} {1}", message, connector.LastError);
        }
        private void ThrowException(string message)
        {
            throw new Exception(ExceptionMessage(message));
        }
        
        public IEnumerable<SignUpAndSendInfo> SignUpAndSend(params VatInvoice[] invoice)
        {

            var info = new List<SignUpAndSendInfo>();

            Connect();
            
            invoice.ToList().ForEach(x =>
            {
                SignUpAndSendInfo i;
                var stringXml = serializer.Serialize(x);
                var xml = Convert.ToBase64String(Encoding.Default.GetBytes(stringXml));
                var eDoc = connector.CreateEDoc;
                if (eDoc.Document.SetData[xml, 1] != 0) i = new SignUpAndSendInfo(x,true,ExceptionMessage("Ошибка загрузки информации"));
                else
                {
                    var z = eDoc.Document.GetData[0];

                    Console.Write(eDoc.Document.GetData[0]);
                    if (eDoc.Sign[0] != 0) i = new SignUpAndSendInfo(x,true, ExceptionMessage("Ошибка подписи"));
                    else
                    {
                        if (connector.SendEDoc[eDoc] != 0) i = new SignUpAndSendInfo(x,true, ExceptionMessage("Ошибка отправки"));
                        else
                        {
                            var ticket = connector.Ticket;

                            if (ticket.Accepted != 0) i = new SignUpAndSendInfo(x,true, ticket.Message);
                            else i = new SignUpAndSendInfo(x,false, ticket.Message);
                        }
                    }
                }
                
                info.Add(i);
                
            });
            Disconnect();
            return info;
        }

        public IEnumerable<StatusInfo> CheckStatus(params VatInvoice[] invoices)
        {
            var info = new List<StatusInfo>();
            Connect();
            invoices.ToList().ForEach(i =>
            {
                var status = connector.GetStatus[i.VatNumber.NumberString];
                if(status.Verify !=0) ThrowException("Ошибка верификации статуса: ");
                //if (status.SaveToFile["D:\\status.xml"] != 0) ThrowException("");
                info.Add(new StatusInfo(i, status.Status, status.Message, status.Since));
                
            });
            Disconnect();
            return info;
        }
    }
}
