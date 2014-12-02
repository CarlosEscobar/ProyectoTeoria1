using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.domain.Entities;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class MatchSeeder : IDataSeeder
    {
        readonly ISession _session;

        public MatchSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            _session.Save(new Match
            {
                Team1 = "Team1",
                Team2 = "Team2",
                Day = "Test"

                /*
                Team1 = _session.QueryOver<Team>().Where(x => x.Name == "TestTeam1").SingleOrDefault<Team>(),
                Team2 = _session.QueryOver<Team>().Where(x => x.Name == "TestTeam2").SingleOrDefault<Team>(),
                Day = "Test"
                 */
            });
        }
    }
}
