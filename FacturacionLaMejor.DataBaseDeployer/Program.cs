using System;
using System.Collections.Generic;
using System.Threading;
using AcklenAvenue.Data.NHibernate;
using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.data;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = ConnectionStrings.Get();

            /*  MsSqlConfiguration databaseConfiguration =
                  MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(x => x.Is(connectionString));*/

            PostgreSQLConfiguration databaseConfiguration =
               PostgreSQLConfiguration.Standard.ShowSql().ConnectionString(x => x.Is(connectionString));


            DomainDrivenDatabaseDeployer.DatabaseDeployer dd = null;
            ISessionFactory sessionFactory = new SessionFactoryBuilder(new MappingScheme(), databaseConfiguration)
                .Build(cfg =>
                {
                    dd = new DomainDrivenDatabaseDeployer.DatabaseDeployer(cfg);
                });

            Console.WriteLine("");
            Console.WriteLine("Database dropped.");
            dd.Drop();
            Thread.Sleep(1000);

            dd.Create();
            Console.WriteLine("");
            Console.WriteLine("Database created.");

            ISession session = sessionFactory.OpenSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                dd.Seed(new List<IDataSeeder>
                            {
                                new AccountSeeder(session),
                                new LeagueSeeder(session),
                                new AccountLeagueSeeder(session),
                                new TeamSeeder(session),
                                new MatchSeeder(session),
                                new LeagueTeamSeeder(session),
                                new LeagueMatchSeeder(session)
                            });
                tx.Commit();
            }
            session.Close();
            sessionFactory.Close();
            Console.WriteLine("");
            Console.WriteLine("Seed data added.");
            Thread.Sleep(2000);
        }
    }
}
