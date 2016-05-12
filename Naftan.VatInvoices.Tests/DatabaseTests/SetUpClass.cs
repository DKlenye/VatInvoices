using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.DatabaseTests
{
    [SetUpFixture]
    public class SetUpClass
    {
        [SetUp]
        public void SetUp()
        {
            BaseTest.CreateDataBase();
            BaseTest.Connect();
            BaseTest.CreateTables();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
