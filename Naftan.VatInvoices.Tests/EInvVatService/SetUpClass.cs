using EInvVatService;
using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.EInvVatService
{
    [SetUpFixture]
    public class SetUpClass
    {
        [SetUp]
        public void SetUp()
        {
            ActiveXTest.connector = new Connector();
            ActiveXTest.loginRezult = ActiveXTest.connector.Login["", 0];       
        }

        [TearDown]
        public void TearDown()
        {
            var logout = ActiveXTest.connector.Logout;
        }
    }
}
