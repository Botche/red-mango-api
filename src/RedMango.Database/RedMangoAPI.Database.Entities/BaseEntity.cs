namespace RedMangoAPI.Database.Entities
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}
