namespace RedMangoAPI.Models.Dto.OrderDetails
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetOrderDetailsDTO : IMapFrom<OrderDetails>
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
