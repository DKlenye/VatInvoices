using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Naftan.VatInvoices.Commands.DDL.CreateTable;
using Naftan.VatInvoices.Extensions;

namespace Naftan.VatInvoices.Tests.Database
{
    public abstract class BaseDatabaseTest:BaseTest
    {
        
        private const string DatabaseName = "VatInvoicesTest";
        private const string TestSqlString = "data source=.; initial catalog={database}; integrated security=SSPI;";
        protected const string LogTableName = "ChangeLog";
        protected static IDbConnection Connection = new SqlConnection(TestSqlString.ApplyTemplate(new{database=DatabaseName}));
        protected static IDatabase Db = new Impl.Database(Connection);
        
        public static void CreateDataBase()
        {
            Connection.Open();
            Connection.Execute(
                 @"USE [master];
                    IF EXISTS(SELECT * FROM sys.databases where name = '{name}') DROP DATABASE {name} 
                    CREATE DATABASE {name}
                    "
                        .ApplyTemplate(new {name=DatabaseName}));
            Connection.Close();
        }

        public static void CreateTables()
        {

            var type = typeof (CreateVatInvoice);
            var queries = type.Assembly.GetTypes().Where(x => x.Namespace == type.Namespace);

            queries.ToList()
                .ForEach(x=> Db.Execute((ICommand) Activator.CreateInstance(x)));
            
            Db.Commit();
        }

        /*

        
        public static void CreateTables()
        {
            var qo = new CreateTable();
            Connection.Execute(qo.BuySaleType());
            Connection.Execute(qo.InvoiceStatus());
            Connection.Execute(qo.InvoiceType());
            Connection.Execute(qo.ProviderStatus());
            Connection.Execute(qo.RecipientStatus());
            Connection.Execute(qo.ReplicationSource());
            Connection.Execute(qo.VatInvoice());
            Connection.Execute(qo.Consignees());
            Connection.Execute(qo.Consignors());
            Connection.Execute(qo.Documents());
            Connection.Execute(qo.RosterList());
        }

        public static void CreateProcedures()
        {
            var qo = new CreateProcedure();
            Connection.Execute(qo.GenerateVatInvoiceNumber());
            Connection.Execute(qo.AddVatInvoice());
        }
        */
    }
}
