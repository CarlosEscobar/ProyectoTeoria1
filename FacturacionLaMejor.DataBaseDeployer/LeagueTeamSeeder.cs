using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.domain.Entities;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class LeagueTeamSeeder : IDataSeeder
    {
        readonly ISession _session;

        public LeagueTeamSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            var leagueTeam1 = new LeagueTeam
            {
                idLeague = 1,
                idTeam = 1
            };
            _session.Save(leagueTeam1);

            var leagueTeam2 = new LeagueTeam
            {
                idLeague = 1,
                idTeam = 2
            };
            _session.Save(leagueTeam2);

        }
    }
}
