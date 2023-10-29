namespace RedMangoAPI.Models.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class MenuItemUpdateDTO : IMapTo<MenuItem>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public IFormFile NewImageFile { get; set; }

        [JsonIgnore]
        public string NewImageFileName => $"{Guid.NewGuid()}{Path.GetExtension(this.NewImageFile.FileName)}";
    }
}
