﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EInvVatService;
using Naftan.VatInvoices.Commands;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Queries;
using Naftan.VatInvoices.Users;
using Naftan.VatInvoices.Validations;

namespace Naftan.VatInvoices.Impl
{
    /// <summary>
    /// Реализаця сервиса для работы c ЭСЧФ
    /// </summary>
    public class VatInvoiceService : IVatInvoiceService
    {
        /// <summary>
        /// Строка подключения к БД ЭСЧФ
        /// </summary>
        public static string ConnectionString =
            "data source=db3; initial catalog=NDSInvoices; integrated security=SSPI;";

        /// <summary>
        ///  url адрес веб сервиса портала МНС
        /// </summary>
        public static string PortalUrl = "https://vat.gov.by:4443/InvoicesWS/services/InvoicesPort";

        private IPortalService _portal;

        private IPortalService portal
        {
            get
            {
                return _portal ?? (_portal = new PortalService(
                    PortalUrl,
                    new Connector(),
                    new VatInvoiceSerializer())
                    );
            }
        }
        
        private IDatabase _db;

        private IValidation<VatInvoice>[] Validations;  


        public VatInvoiceService(IPortalService portal, IDatabase db)
        {
            _portal = portal;
            _db = db;

            Validations = new IValidation<VatInvoice>[]
            {
                new VatZeroValidation(),
                new OriginalVatInvoiceNumberValidation(_db)
            };


        }

        public VatInvoiceService(): this(null,new Database(new SqlConnection(ConnectionString)))
        {}
      
        public IEnumerable<VatInvoiceDto> LoadVatInvoices(int? period = null)
        {

            ValidateVatInvoices();

            IEnumerable<VatInvoiceDto> dto;
            if (period == null)
                dto = _db.Execute(new SelectVatInvoiceDtoAll());
            else
                dto = _db.Execute(new SelectVatInvoiceDtoByPeriod(new DatePeriod(period.Value)));
            _db.Commit();
            return dto;
        }

        public VatInvoice LoadVatInvoice(int InvoiceId)
        {
            var invoice = _db.Execute(new SelectVatInvoiceById(InvoiceId));
            _db.Commit();
            return invoice;
        }

        public VatInvoiceDto SaveVatInvoice(VatInvoice invoice)
        {
            if (invoice.InvoiceId == 0) _db.Execute(new InsertVatInvoice(invoice));
            else _db.Execute(new UpdateVatInvoice(invoice));
            var dto = _db.Execute(new SelectVatInvoiceDtoByIds(invoice.InvoiceId));
            return dto.FirstOrDefault();
        }

        public IEnumerable<Document> LoadDocuments(int invoiceId)
        {
           var documents = _db.Execute(new SelectDocumentsByInvoiceId(invoiceId));
            _db.Commit();
            return documents;
        }

        public IEnumerable<Consignee> LoadConsignees(int invoiceId)
        {
            var consignees = _db.Execute(new SelectConsigneesByInvoiceId(invoiceId));
            _db.Commit();
            return consignees;
        }

        public IEnumerable<Consignor> LoadConsignors(int invoiceId)
        {
            var consignors = _db.Execute(new SelectConsignorsByInvoiceId(invoiceId));
            _db.Commit();
            return consignors;
        }

        public IEnumerable<Roster> LoadRosterList(int invoiceId)
        {
            var rosters = _db.Execute(new SelectRostersByInvoiceId(invoiceId));
            _db.Commit();
            return rosters;
        }

        public IEnumerable<VatInvoiceDto> ApproveVatInvoice(params int[] invoiceId)
        {
            var userName = CurrentUser.Name;

            invoiceId.ToList().ForEach(id =>
            {
                var invoice = _db.Execute(new SelectVatInvoiceById(id));
                invoice.Approve(userName);
                _db.Execute(new UpdateVatInvoice(invoice));
            });

            var dto = _db.Execute(new SelectVatInvoiceDtoByIds(invoiceId));
            _db.Commit();
            return dto;
        }

        public IEnumerable<VatInvoiceDto> CancelApproveVatInvoice(params int[] invoiceId)
        {
            invoiceId.ToList().ForEach(id =>
            {
                var invoice = _db.Execute(new SelectVatInvoiceById(id));
                invoice.CancelApprove();
                _db.Execute(new UpdateVatInvoice(invoice));
            });

            var dto = _db.Execute(new SelectVatInvoiceDtoByIds(invoiceId));
            _db.Commit();
            return dto;
        }

        public IEnumerable<SendRezult> SignAndSend(params int[] id)
        {
            var rezult = new List<SendRezult>();

            //Загружаем полную информацию по ЭСЧФ
            var invoices = new List<VatInvoice>();
            id.ToList().ForEach(i => invoices.Add(_db.Execute(new SelectVatInvoiceById(i))));
            _db.Commit();


            var inprogressOut = new List<VatInvoice>();
            var completedIn = new List<VatInvoice>();
            var error = new List<VatInvoice>();

            invoices.ForEach(i =>
            {
                if (i.IsIncome && i.Status == InvoiceStatus.COMPLETED) completedIn.Add(i);
                else if (
                    !i.IsIncome && 
                    (i.Status == InvoiceStatus.IN_PROGRESS || i.Status == InvoiceStatus.IN_PROGRESS_ERROR))
                    inprogressOut.Add(i);
                else error.Add(i);
            });

            rezult = _db.Execute(
                new SelectVatInvoiceDtoByIds(error.Select(x => x.InvoiceId).ToArray()))
                    .Select(x => new SendRezult(x, "ЭСЧФ нельзя отправить на портал. Неверный статус.", true)).ToList();
            _db.Commit();

            rezult.AddRange(SignAndSendOut(inprogressOut.ToArray()));
            rezult.AddRange(SignAndSendIn(completedIn.ToArray()));

            return rezult;

        }

        private IEnumerable<SendRezult> SignAndSendOut(params VatInvoice[] invoices)
        {
            var rezult = new List<SendRezult>();

            var info = portal.SignAndSendOut(invoices);
            info.ToList().ForEach(x=>
            {
                var invoice = x.Invoice;
                if (!x.IsException)
                {
                    invoice.SetStatus(InvoiceStatus.COMPLETED,"");
                    var xml = new VatInvoiceXml
                    {
                        InvoiceId = invoice.InvoiceId,
                        Xml = x.Xml,
                        SignXml = x.SignXml
                    };
                    _db.Execute(new InsertVatInvoiceXml(xml));
                }
                else
                {
                    invoice.SetStatus(InvoiceStatus.IN_PROGRESS_ERROR, x.Message);
                }

                _db.Execute(new UpdateVatInvoice(invoice));

                rezult.Add(new SendRezult(
                         _db.Execute(new SelectVatInvoiceDtoByIds(invoice.InvoiceId)).Single(),
                        x.Message,
                        x.IsException
                        ));
                
            });
            _db.Commit();
            return rezult;
        }

        private IEnumerable<SendRezult> SignAndSendIn(params VatInvoice[] invoices)
        {
            var rezult = new List<SendRezult>();
            var lookup = invoices.ToDictionary(x => x.InvoiceId, x => x);
            var invoiceXml = new Dictionary<int,VatInvoiceXml>();

            invoices.ToList().ForEach(x=>
            {
                var xml = _db.Execute(new SelectVatInvoiceXmlByInvoiceId(x.InvoiceId)).FirstOrDefault();
                invoiceXml.Add(x.InvoiceId,xml);
            });
            _db.Commit();

            rezult.AddRange(invoiceXml.Values.Where(x=>x==null).Select(x => new SendRezult(
                _db.Execute(new SelectVatInvoiceDtoByIds(x.InvoiceId)).Single(),
                "Не найден xml, подписанный отправителем",
                true
                )));


            var info = portal.SignAndSendIn(invoiceXml.Values.Where(x=>x!=null).ToArray());
            
            info.ToList().ForEach(i =>
            {
                var invoice = lookup[i.InvoiceXml.InvoiceId];

                if (!i.IsException)
                {
                    invoice.SetStatus(InvoiceStatus.COMPLETED_SIGNED,"");
                    _db.Execute(new UpdateVatInvoiceXml(i.InvoiceXml));
                }
                else
                {
                    invoice.SetStatus(InvoiceStatus.COMPLETED, i.Message);
                }

                _db.Execute(new UpdateVatInvoice(invoice));

                rezult.Add(new SendRezult(
                        _db.Execute(new SelectVatInvoiceDtoByIds(invoice.InvoiceId)).Single(),
                       i.Message,
                       i.IsException
                       ));
            });
            
            _db.Commit();
            return rezult;
        }

        public IEnumerable<VatInvoiceDto> CheckStatus()
        {
            var invoices = _db.Execute(new SelectVatInvoiceDtoForCheckStatus());
            _db.Commit();

            var checkInfo = portal.CheckStatus(invoices.ToArray());
            var statusChanged = new List<VatInvoiceDto>();

            checkInfo.ToList().ForEach(i =>
            {
                var dto = i.Invoice;
                if (!String.IsNullOrEmpty(i.Status) && i.Status != "NOT_FOUND")
                {
                    var status = i.Status.ConvertToEnum<InvoiceStatus>();

                    if (dto.InvoiceStatus != status)
                    {
                        var invoice = _db.Execute(new SelectVatInvoiceById(dto.InvoiceId));
                        invoice.SetStatus(status, "");
                        _db.Execute(new UpdateVatInvoice(invoice));
                        statusChanged.Add(dto);
                    }
                }
            });

            var changes = _db.Execute(new SelectVatInvoiceDtoByIds(statusChanged.Select(x => x.InvoiceId).ToArray()));
            _db.Commit();
            return changes;
        }

        public IEnumerable<VatInvoiceDto> ReceiveIncoming()
        {
            var date = _db.Execute(new SelectMaxIncomeDate());
            _db.Commit();
            var info = portal.LoadIncomeVatInvoice(date);
            var newInvoices = new List<VatInvoice>();

            info.ToList().ForEach(i =>
            {
                if(!_db.Execute(new SelectVatInvoiceDtoByNumber(i.Number)).Any())
                {

                    var invoice = i.Invoice;
                    invoice.IsIncome = true;
                    invoice.BuySaleType = BuySaleType.Buy;
                    invoice.AccountingDate = invoice.DateIssuance ?? invoice.DateTransaction;
                    invoice.SetStatus(InvoiceStatus.COMPLETED);
                    
                    _db.Execute(new InsertVatInvoice(invoice));
                    _db.Execute(new InsertVatInvoiceXml(
                        new VatInvoiceXml
                    {
                        InvoiceId = i.Invoice.InvoiceId,
                        Xml = i.Xml,
                        SignXml = i.SignXml
                    }));
                    newInvoices.Add(i.Invoice);
                }
            });

            var dto = _db.Execute(new SelectVatInvoiceDtoByIds(newInvoices.Select(x => x.InvoiceId).ToArray()));
            _db.Commit();
            return dto;
            
        }

        public IEnumerable<UserRoles> GetUserRoles()
        {
            return CurrentUser.Roles;
        }

        private void ValidateVatInvoices()
        {
            _db.Execute(new SelectVatInvoiceDtoForValidate())
                .ToList().ForEach(x =>
                {
                    var invoice = _db.Execute(new SelectVatInvoiceById(x.InvoiceId));
                    invoice.Validate(Validations);
                    _db.Execute(new UpdateVatInvoice(invoice));
                });

            _db.Commit();
        }

    }
}
