using NUnit.Framework;

namespace Naftan.VatInvoices.Tests.Database
{
    [SetUpFixture]
    public class SetUpClass
    {
        [SetUp]
        public void SetUp()
        {
           
           BaseDatabaseTest.CreateDataBase();
           BaseDatabaseTest.CreateTables();
           // BaseDatabaseTest.CreateProcedures();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
