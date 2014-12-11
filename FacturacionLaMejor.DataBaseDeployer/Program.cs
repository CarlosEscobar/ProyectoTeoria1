using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using AcklenAvenue.Data.NHibernate;
using DomainDrivenDatabaseDeployer;
using FacturacionLaMejor.data;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Npgsql;

namespace FacturacionLaMejor.DataBaseDeployer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string connectionString = ConnectionStrings.Get();

            /*  MsSqlConfiguration databaseConfiguration =
                  MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(x => x.Is(connectionString));--

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
            */

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=clave;Database=PRUEBADIAGRAMA;");
            conn.Open();
  
            // Specify command StoredProcedure
            NpgsqlCommand command = new NpgsqlCommand("INIT_D(88,'ILNENE')", conn);
            command.CommandType = CommandType.StoredProcedure;

            // Execute procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            conn.Close();

            Console.WriteLine("");
            Console.WriteLine("INIT D processed.");
            Thread.Sleep(2000);
        }
    }
}
