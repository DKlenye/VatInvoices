using System;
using System.Data.SqlClient;
using System.Linq;
using EInvVatService;
using Naftan.VatInvoices;
using Naftan.VatInvoices.Impl;
using Naftan.VatInvoices.Users;

namespace XpTest
{
    class Program
    {
        static void Main(string[] args)
        {

            IPortalService service = new PortalService(
            Settings.PortalUrl,
            new Connector(),
            new VatInvoiceSerializer()
            );

            IVatInvoiceService invoiceService = new VatInvoiceService(
                
                service,
                new Database(new SqlConnection(Settings.ConnectionString)));
            
            var dto = invoiceService.LoadVatInvoices();

            dto.ToList().ForEach(x=>Console.WriteLine(x.NumberString));
            Console.WriteLine(dto.Count());

            //invoiceService.GetUserRoles().ToList().ForEach(x=>Console.WriteLine(x.ToString()));
            
           /* var info = service.CheckStatus(new VatInvoiceDto
            {
                NumberString = "300042199-2016-0000000001"
            });
            */
            //Console.WriteLine(info.First().Message);


            CurrentUser.Roles.ToList().ForEach(x=>Console.WriteLine(x.ToString()));

            
            Console.ReadKey();
        }
    }
}
