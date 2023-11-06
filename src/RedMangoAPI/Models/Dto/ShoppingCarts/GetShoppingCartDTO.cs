namespace RedMangoAPI.Models.Dto.ShoppingCarts
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.CartItems;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetShoppingCartDTO : IMapFrom<ShoppingCart>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public double CartTotal { get; set; }

        public ICollection<GetCartItemDTO> CartItems { get; set; }
    }
}
