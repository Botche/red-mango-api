namespace RedMangoAPI.Database.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    public class MenuItem : BaseEntity
    {
        public MenuItem()
            : base()
        {
        }

        public int ItemNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [JsonIgnore]
        public string ImageName => ImageUrl.Split('/').Last();
    }
}
