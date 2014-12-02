namespace FacturacionLaMejor.domain.Entities
{
    public class League : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual string Name { get; set; }

        public virtual string Day { get; set; }

        public virtual string Location { get; set; }
    }
}