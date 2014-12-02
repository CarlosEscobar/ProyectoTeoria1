namespace FacturacionLaMejor.domain.Entities
{
    public class AccountLeague : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual long idAccount { get; set; }

        public virtual long idLeague { get; set; }
    }
}
