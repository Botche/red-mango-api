namespace RedMangoAPI.Models.Dto.CartItem
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.MenuItem;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetCartItemDTO : IMapFrom<CartItem>
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public virtual GetMenuItemDTO MenuItem { get; set; }
        public int Quantity { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
