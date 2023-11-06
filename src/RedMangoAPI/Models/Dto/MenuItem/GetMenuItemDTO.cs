namespace RedMangoAPI.Models.Dto.MenuItem
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetMenuItemDTO : IMapFrom<MenuItem>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
