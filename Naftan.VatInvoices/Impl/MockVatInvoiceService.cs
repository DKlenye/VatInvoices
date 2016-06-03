using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Queries;
using Naftan.VatInvoices.Users;

namespace Naftan.VatInvoices.Impl
{
    public class MockVatInvoiceService:IVatInvoiceService
    {

        private readonly IDatabase _db;

        public MockVatInvoiceService()
        {
            _db = new Database(new SqlConnection(VatInvoiceService.ConnectionString));
        }

        public IEnumerable<VatInvoiceDto> LoadVatInvoices(int? period = null)
        {
            throw new System.NotImplementedException();
        }

        public VatInvoice LoadVatInvoice(int InvoiceId)
        {
            throw new System.NotImplementedException();
        }

        public VatInvoiceDto SaveVatInvoice(VatInvoice invoice)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Document> LoadDocuments(int invoiceId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Consignee> LoadConsignees(int invoiceId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Consignor> LoadConsignors(int invoiceId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Roster> LoadRosterList(int invoiceId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VatInvoiceDto> ApproveVatInvoice(params int[] invoiceId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VatInvoiceDto> CancelApproveVatInvoice(params int[] invoiceId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SendRezult> SignAndSend(params int[] invoiceId)
        {
            var i = 0;

            var rezult =  invoiceId.ToList().Select(x =>
            {
                var isException = i++%2 == 0;
                return new SendRezult(
                    _db.Execute(new SelectVatInvoiceDtoByIds(x)).FirstOrDefault(),
                    isException ? "Сообщение об ошибке" : "",
                    isException
                    );
            });
            _db.Commit();
            return rezult;

        }

        public IEnumerable<VatInvoiceDto> CheckStatus()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VatInvoiceDto> ReceiveIncoming()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserRoles> GetUserRoles()
        {
            throw new System.NotImplementedException();
        }
    }
}
