using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Queries;
using Naftan.VatInvoices.QueryObjects;
using Naftan.VatInvoices.Users;

namespace Naftan.VatInvoices.Impl
{
    /// <summary>
    /// Реализаця сервиса для работы c ЭСЧФ
    /// </summary>
    public class VatInvoiceService:IVatInvoiceService
    {
        /// <summary>
        /// Строка подключения к БД ЭСЧФ
        /// </summary>
        public static string ConnectionString = "data source=db3; initial catalog=NDSInvoices; integrated security=SSPI;";

        /// <summary>
        ///  url адрес веб сервиса портала МНС
        /// </summary>
        public static string PortalUrl = "https://vat.gov.by:4443/InvoicesWS/services/InvoicesPort";

        private IPortalService portal;

        public VatInvoiceService(IPortalService portal)
        {
            this.portal = portal;
        }

        public VatInvoiceService()
        {
            portal = new PortalService();
        }

        public IEnumerable<VatInvoiceDto> LoadVatInvoices(int? period = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<VatInvoiceDto>(new SelectVatInvoiceDto().All());
            }
        }

        public IEnumerable<Document> LoadDocuments(int invoiceId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<Document>(new SelectDocument().ByInvoiceId(invoiceId));
            }
        }

        public IEnumerable<Consignee> LoadConsignees(int invoiceId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<Consignee>(new SelectConsignee().ByInvoiceId(invoiceId));
            }
        }

        public IEnumerable<Consignor> LoadConsignors(int invoiceId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<Consignor>(new SelectConsignor().ByInvoiceId(invoiceId));
            }
        }

        public IEnumerable<Roster> LoadRosterList(int invoiceId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                return connection.Query<Roster>(new SelectRoster().ByInvoiceId(invoiceId));
            }
        }

        public IEnumerable<VatInvoiceDto> ApproveVatInvoice(params int[] invoiceId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var userName = CurrentUser.Name;
                var invoices = connection.Query<VatInvoice>(new SelectVatInvoice().ById(invoiceId));

                invoices.ToList().ForEach(x =>
                {
                    x.Approve(userName);
                    connection.Execute(new UpdateVatInvoice().Query(x));
                });
                
                return connection.Query<VatInvoiceDto>(new SelectVatInvoiceDto().ById(invoiceId));
            }
        }

        public IEnumerable<SignUpAndSendRezult> SignUpAndSend (params int[] id)
        {

            var rezult = new List<SignUpAndSendRezult>();

            //Загружаем полную информацию по ЭСЧФ
            var invoices = new List<VatInvoice>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                id.ToList().ForEach(i => invoices.Add(new SelectVatInvoiceQuery(connection,i).Query()));
            }

            var info = portal.SignUpAndSend(invoices.ToArray());

            using (var connection = new SqlConnection(ConnectionString))
            {
                info.ToList().ForEach(i =>
                {
                    var invoice = i.Invoice;
                    if (!i.IsException)
                    {
                        invoice.SetStatus(InvoiceStatus.COMPLETED);
                        connection.Execute(new UpdateVatInvoice().Query(invoice));
                    }

                    rezult.Add(new SignUpAndSendRezult(
                        connection.Query<VatInvoiceDto>(new SelectVatInvoiceDto().ById(invoice.InvoiceId)).Single(),
                        i.Message,
                        i.IsException
                        ));
                });
            }

            return rezult;
            
        }

        public IEnumerable<VatInvoiceDto> CheckStatus()
        {

            IEnumerable<VatInvoice> invoices;
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                invoices = connection.Query<VatInvoice>(new SelectVatInvoice().ForCheck());
            }

            var checkInfo = portal.CheckStatus(invoices.ToArray());
            var statusChanged = new List<VatInvoice>();
            checkInfo.ToList().ForEach(i =>
            {
                var invoice = i.Invoice;
                var status = i.Status.ToString().ConvertToEnum<InvoiceStatus>();

                if (invoice.Status != status)
                {
                    invoice.SetStatus(status);
                    statusChanged.Add(invoice);
                }
            });

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                statusChanged.ForEach(s=>connection.Execute(new UpdateVatInvoice().Query(s)));
                return connection.Query<VatInvoiceDto>(
                        new SelectVatInvoiceDto().ById(statusChanged.Select(x => x.InvoiceId).ToArray()));
            }

        }

    }
}
