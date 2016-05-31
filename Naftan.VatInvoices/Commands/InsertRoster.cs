using System.Data;
using System.Linq;
using Dapper;
using DapperExtensions;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class InsertRoster:ICommand
    {
        public InsertRoster(Roster roster)
        {
            Roster = roster;
        }

        public Roster Roster { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Insert(Roster, tx);
            Roster.Description.ToList().ForEach(d => db.Execute(@"
                INSERT INTO RosterDescription
                VALUES
                (
	               @Id,
	               @DescriptionTypeId
                )", new {Roster.Id, DescriptionTypeId = d}, tx));
        }
    }
}
