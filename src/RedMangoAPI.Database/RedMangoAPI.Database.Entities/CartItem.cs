namespace RedMangoAPI.Database.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
