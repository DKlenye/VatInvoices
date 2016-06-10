using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EInvVatService;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Impl
{
    public class PortalService : IPortalService
    {
        private readonly string portalUrl;
        private readonly Connector connector;
        private readonly IVatInvoiceSerializer serializer;
        private bool isLogged;

        public PortalService(string portalUrl, Connector connector, IVatInvoiceSerializer serializer)
        {
            this.connector = connector;
            this.serializer = serializer;
            this.portalUrl = portalUrl;
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

        public IEnumerable<SendOutInfo> SignAndSendOut(params VatInvoice[] invoices)
        {
            var info = new List<SendOutInfo>();
            Connect();
            invoices.ToList().ForEach(x =>
            {
                SendOutInfo i;
                var stringXml = serializer.Serialize(x);
                var xml = Convert.ToBase64String(Encoding.UTF8.GetBytes(stringXml));
                var eDoc = connector.CreateEDoc;
                if (eDoc.Document.SetData[xml, 1] != 0)
                    i = new SendOutInfo(x, true, ExceptionMessage("Ошибка загрузки информации"));
                else
                {
                    if (eDoc.Sign[0] != 0) 
                        i = new SendOutInfo(x, true, ExceptionMessage("Ошибка подписи"));
                    else
                    {
                        if (connector.SendEDoc[eDoc] != 0)
                            i = new SendOutInfo(x, true, ExceptionMessage("Ошибка отправки"));
                        else
                        {
                            var ticket = connector.Ticket;

                            if (ticket.Accepted != 0)
                            {
                                i = new SendOutInfo(x, true, ticket.Message);
                            }
                            else
                            {

                                //Если документ принят порталом, то мы всё равно пытаемся получить его статус, так как портал может принять документ,
                                //но по результатам форматно-логического контроля не добавить его

                                var status = connector.GetStatus[x.VatNumber.NumberString];

                                if (status == null)
                                    i = new SendOutInfo(x, true, "ЭСЧФ не прошёл проверку на портале статус не принят");
                                else
                                {
                                    if (status.Verify != 0)
                                        i = new SendOutInfo(x, true, ExceptionMessage("Ошибка получения статуса"));
                                    else
                                    {
                                        if (status.Status == "NOT_FOUND")
                                            i = new SendOutInfo(x, true, "ЭСЧФ не прошёл проверку на портале");
                                        else
                                        {
                                            i = new SendOutInfo(
                                                x,
                                                false,
                                                ticket.Message,
                                                Encoding.UTF8.GetString(
                                                    Convert.FromBase64String(eDoc.Document.GetData[1])),
                                                Encoding.UTF8.GetString(Convert.FromBase64String(eDoc.GetData[1]))
                                                );
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                info.Add(i);
            });
            Disconnect();
            return info;
        }
        
        public IEnumerable<SendInInfo> SignAndSendIn(params VatInvoiceXml[] invoices)
        {
            var info = new List<SendInInfo>();
            Connect();
                invoices.ToList().ForEach(x =>
                {
                    SendInInfo i;
                    var eDoc = connector.CreateEDoc;
                    if (eDoc.SetData[Convert.ToBase64String(Encoding.UTF8.GetBytes(x.SignXml)), 1] != 0)
                        i = new SendInInfo(x, true, ExceptionMessage("Ошибка загрузки информации "));
                    else
                    {
                        
                        var signCount = eDoc.GetSignCount;
                        if (signCount == 0)
                            i = new SendInInfo(x, true, ExceptionMessage("Документ не содержит ЭЦП "));
                        else {
                           // if (eDoc.VerifySign[1, 0] != 0)
                           //     i = new SendInInfo(x, true, ExceptionMessage("Ошибка проверки подписи "));
                           // else
                            {
                                if (eDoc.Sign[0] != 0) 
                                    i = new SendInInfo(x, true, ExceptionMessage("Ошибка подписи"));
                                else
                                {
                                    if (connector.SendEDoc[eDoc] != 0)
                                        i = new SendInInfo(x, true, ExceptionMessage("Ошибка отправки"));
                                    else
                                    {
                                        var ticket = connector.Ticket;

                                        if (ticket.Accepted != 0)
                                        {
                                            i = new SendInInfo(x, true, ticket.Message);
                                        }
                                        else
                                        {
                                            x.Sign2Xml =
                                                Encoding.UTF8.GetString(Convert.FromBase64String(eDoc.GetData[1]));

                                            i = new SendInInfo(
                                                x,
                                                false,
                                                ticket.Message
                                                );
                                        }
                                    }
                                }
                            }
                        }
                    }

                    info.Add(i);

                });
            Disconnect();
            return info;
        }

        public IEnumerable<StatusInfo> CheckStatus(params VatInvoiceDto[] invoices)
        {
            var info = new List<StatusInfo>();
            Connect();
            invoices.ToList().ForEach(i =>
            {
                var status = connector.GetStatus[i.NumberString];
                if (status != null)
                {
                    if (status.Verify != 0) ThrowException("Ошибка верификации статуса: ");
                    info.Add(new StatusInfo(i, status.Status, status.Message, status.Since));
                }

            });
            Disconnect();
            return info;
        }

        public IEnumerable<LoadInfo> LoadIncomeVatInvoice(DateTime date)
        {
            var info = new List<LoadInfo>();

            var removeXmlDeclarationRegex = new Regex(@"<\?xml.*\?>");

            Connect();
            var list = connector.GetList[date.ToString("s")];
            if (list != null)
            {
                var listCount = list.Count;

                for (var i = 0; i < listCount; i++)
                {
                    var number = list.GetItemAttribute[i, @"document/number"];
                    var eDoc = connector.GetEDoc[number];
                    if (eDoc != null)
                    {
                        var verifySign = eDoc.VerifySign[0, 0];
                        if (verifySign == 0)
                        {
                            var signXml = Encoding.UTF8.GetString(Convert.FromBase64String(eDoc.GetData[1]));
                            var xml = Encoding.UTF8.GetString(Convert.FromBase64String(eDoc.Document.GetData[1]));

                            xml = removeXmlDeclarationRegex.Replace(xml, "");

                            var invoice = serializer.Deserialize(xml);

                            info.Add(new LoadInfo(invoice, number, xml, signXml));
                        }
                    }
                }
            }
            else
            {
                ThrowException("Ошибка получения списка ЭСЧФ ");
            }
            Disconnect();

            return info;
        }
        
      

    }
}
