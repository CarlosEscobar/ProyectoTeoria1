using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.domain.Entities;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class LeagueSeeder : IDataSeeder
    {
        readonly ISession _session;

        public LeagueSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            _session.Save(new League
            {
                Name = "TestLeague",
                Day = "Test",
                Location = "Test"
            });
        }
    }
}
