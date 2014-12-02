using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.domain.Entities;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class LeagueMatchSeeder : IDataSeeder
    {
        readonly ISession _session;

        public LeagueMatchSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var leagueMatch = new LeagueMatch()
            {
                idLeague = 1,
                idMatch = 1
            };
            _session.Save(leagueMatch);

        }
    }
}
