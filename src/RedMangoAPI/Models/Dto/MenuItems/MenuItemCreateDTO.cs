namespace RedMangoAPI.Models.Dto.MenuItems
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class MenuItemCreateDTO : IMapTo<MenuItem>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public IFormFile ImageFile { get; set; }

        [JsonIgnore]
        public string ImageFileName => $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";
    }
}
