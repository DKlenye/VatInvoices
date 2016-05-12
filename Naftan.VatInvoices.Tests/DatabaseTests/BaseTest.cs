using System.Data;
using System.Data.SqlClient;
using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.Tests.QueryObjects;

namespace Naftan.VatInvoices.Tests.DatabaseTests
{
    public abstract class BaseTest
    {
        private const string DatabaseName = "VatInvoicesTest";
        private const string TestSqlString = "data source=.; initial catalog={database}; integrated security=SSPI;";
        protected const string LogTableName = "ChangeLog";
        protected static IDbConnection Connection;


        public static string GetConnectionString(string database = null)
        {
            return TestSqlString.ApplyTemplate(
                new { database = string.IsNullOrEmpty(database) ? DatabaseName : database }
            );
        }

        public static void CreateDataBase()
        {
            var connection = new SqlConnection(GetConnectionString("master"));
            connection.Open();
            connection.Execute(new CreateDatabase().Query(DatabaseName));
            connection.Close();
        }

        public static void Connect()
        {
            var connection = new SqlConnection(GetConnectionString());
            connection.Open();
            Connection =  connection;
        }
        
        public static void CreateTables()
        {
            var qo = new CreateTable();
            Connection.Execute(qo.BuySaleType());
            Connection.Execute(qo.InvoiceStatus());
            Connection.Execute(qo.InvoiceType());
            Connection.Execute(qo.ProviderStatus());
            Connection.Execute(qo.RecipientStatus());
            Connection.Execute(qo.ReplicationSource());
            Connection.Execute(qo.Replication());
            Connection.Execute(qo.VatInvoice());
            Connection.Execute(qo.Consignees());
            Connection.Execute(qo.Consignors());
            Connection.Execute(qo.Documents());
            Connection.Execute(qo.RosterList());
        }

    }
}
