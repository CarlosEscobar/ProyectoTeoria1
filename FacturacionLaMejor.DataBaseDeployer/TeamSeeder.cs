using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.domain.Entities;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class TeamSeeder : IDataSeeder
    {
        readonly ISession _session;

        public TeamSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            _session.Save(new Team
            {
                Name = "TestTeam1",
                NumberOfPlayers = 0,
                Coach = "Test"
            });

            _session.Save(new Team
            {
                Name = "TestTeam2",
                NumberOfPlayers = 0,
                Coach = "Test"
            });
        }
    }
}
