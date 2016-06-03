using System.Data;
using System.Linq;
using Dapper;
using DapperExtensions;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class UpdateRoster:ICommand
    {

        public UpdateRoster(Roster roster)
        {
            Roster = roster;
        }

        public Roster Roster { get; private set; }

        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Update(Roster, tx);

            db.Execute(@"
                DELETE FROM RosterDescription WHERE RosterId = @Id
                ", new { Roster.Id }, tx);

            if (Roster.Description != null)
            {
                Roster.Description.ToList().ForEach(d => db.Execute(@"
                INSERT INTO RosterDescription
                VALUES
                (
	               @Id,
	               @DescriptionTypeId
                )", new { Roster.Id, DescriptionTypeId = d }, tx));
            }
        }
    }
}
