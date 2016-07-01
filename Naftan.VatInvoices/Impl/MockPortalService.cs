using System;
using System.Collections.Generic;
using System.Linq;
using Naftan.VatInvoices.Domain;
using Naftan.VatInvoices.Dto;

namespace Naftan.VatInvoices.Impl
{
    public class MockPortalService:IPortalService
    {
        public IEnumerable<SendOutInfo> SignAndSendOut(params VatInvoice[] invoice)
        {
           var i = 0;
           return invoice.ToList().Select(x =>
            {
                i++;
                return new SendOutInfo(
                    x,
                    i%2 == 0,
                    i%2 == 0?"Сообщение об ошибке":"",
                    xml: "",
                    signXml: ""
                    );
            });

        }

        public IEnumerable<SendInInfo> SignAndSendIn(params VatInvoiceXml[] invoice)
        {
            var i = 0;
            return invoice.ToList().Select(x =>
            {
                i++;
                return new SendInInfo(
                    x,
                    i % 2 == 0,
                    i % 2 == 0 ? "Сообщение об ошибке" : ""
                    );
            });
        }

        public IEnumerable<StatusInfo> CheckStatus(params VatInvoiceDto[] invoice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoadInfo> LoadIncomeVatInvoice(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
