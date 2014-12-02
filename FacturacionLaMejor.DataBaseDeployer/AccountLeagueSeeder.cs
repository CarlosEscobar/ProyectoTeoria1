using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.domain.Entities;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class AccountLeagueSeeder : IDataSeeder
    {
        readonly ISession _session;

        public AccountLeagueSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var accountLeague = new AccountLeague
            {
                idAccount = 1,
                idLeague = 1
            };
            _session.Save(accountLeague);

        }
    }
}
