namespace RedMangoAPI.Models.Dto
{
    using System.ComponentModel.DataAnnotations;

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

        internal string ImageFileName => $"{Guid.NewGuid()}{Path.GetExtension(this.ImageFile.FileName)}";
    }
}
