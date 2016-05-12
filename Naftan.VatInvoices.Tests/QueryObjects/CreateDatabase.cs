using Naftan.VatInvoices.Extensions;
using Naftan.VatInvoices.QueryObjects;

namespace Naftan.VatInvoices.Tests.QueryObjects
{
    public class CreateDatabase
    {
        public QueryObject Query(string name)
        {
            return
                new QueryObject(
                    "IF EXISTS(SELECT * FROM sys.databases where name = '{name}') DROP DATABASE {name}; CREATE DATABASE {name}"
                        .ApplyTemplate(new {name}));
        }
    }
}
