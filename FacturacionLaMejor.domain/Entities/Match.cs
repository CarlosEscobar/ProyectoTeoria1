namespace FacturacionLaMejor.domain.Entities
{
    public class Match : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual string Team1 { get; set; }

        public virtual string Team2 { get; set; }

        public virtual string Day { get; set; }
    }
}
