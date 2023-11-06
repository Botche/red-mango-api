namespace RedMangoAPI.Models.Dto.OrderDetails
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetOrderDetailsDTO : IMapFrom<OrderDetails>
    {
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
    }
}
