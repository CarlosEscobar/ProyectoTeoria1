namespace FacturacionLaMejor.domain.Entities
{
    public class LeagueMatch : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual long idLeague { get; set; }

        public virtual long idMatch { get; set; }
    }
}
