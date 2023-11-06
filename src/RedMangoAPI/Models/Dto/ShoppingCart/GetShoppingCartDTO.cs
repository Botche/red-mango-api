namespace RedMangoAPI.Models.Dto.ShoppingCart
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.CartItem;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetShoppingCartDTO : IMapFrom<ShoppingCart>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double CartTotal { get; set; }

        public ICollection<GetCartItemDTO> CartItems { get; set; }
    }
}
