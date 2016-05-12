using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Mnsati.Original;
using Naftan.VatInvoices.QueryObjects;

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

        public IEnumerable<VatInvoiceDto> LoadVatInvoicesList(int? period = null)
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

        public VatInvoiceDto ApproveVatInvoice(int invoiceId)
        {
            throw new System.NotImplementedException();
        }
        
        public void SignUpAndSend(params int[] id)
        {
            throw new System.NotImplementedException();
        }
        
        public void SaveXml(string str)
        {
            var reader = XmlReader.Create(str);
            var serializer = new XmlSerializer(typeof (issuance));
            var o = (issuance) serializer.Deserialize(reader);
        }




    }
}
