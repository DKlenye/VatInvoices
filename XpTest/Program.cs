using System;
using System.Linq;
using EInvVatService;
using Naftan.VatInvoices;
using Naftan.VatInvoices.Dto;
using Naftan.VatInvoices.Impl;

namespace XpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IPortalService service = new PortalService(
            VatInvoiceService.PortalUrl,
            new Connector(),
            new VatInvoiceSerializer()
            );
            
            var info = service.CheckStatus(new VatInvoiceDto
            {
                NumberString = "300042199-2016-0000000001"
            });

            Console.WriteLine(info.First().Message);
            
        }
    }
}
