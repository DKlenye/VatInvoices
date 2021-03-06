﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Naftan.VatInvoices.Commands.DDL.CreateProcedure;
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


        public static void CreateProcedures()
        {
            var type = typeof(spu_AddVatInvoice);
            var queries = type.Assembly.GetTypes().Where(x => x.Namespace == type.Namespace);

            queries.ToList()
                .ForEach(x => Db.Execute((ICommand)Activator.CreateInstance(x)));

            Db.Commit();
        }
            
    }
}
