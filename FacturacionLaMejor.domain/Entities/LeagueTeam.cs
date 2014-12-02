namespace FacturacionLaMejor.domain.Entities
{
    public class LeagueTeam : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual long idLeague { get; set; }

        public virtual long idTeam { get; set; }
    }
}
