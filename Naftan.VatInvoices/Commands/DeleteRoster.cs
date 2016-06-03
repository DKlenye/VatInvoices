using System.Data;
using Dapper;
using DapperExtensions;
using Naftan.VatInvoices.Domain;

namespace Naftan.VatInvoices.Commands
{
    public class DeleteRoster:ICommand
    {
        public DeleteRoster(Roster roster)
        {
            Roster = roster;
        }

        public Roster Roster { get; private set; }
        
        public void Execute(IDbConnection db, IDbTransaction tx)
        {
            db.Execute(@"
                DELETE FROM RosterDescription WHERE RosterId = @Id
                ", new { Roster.Id }, tx);
            db.Delete(Roster, tx);
        }
    }
}
