namespace RedMangoAPI.Database.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class MenuItem : BaseEntity
    {
        public MenuItem()
            : base()
        {
        }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public string ImageName => ImageUrl.Split('/').Last();
    }
}
