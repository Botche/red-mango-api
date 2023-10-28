using System.ComponentModel.DataAnnotations;

namespace RedMangoAPI.Database.Entities
{
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
