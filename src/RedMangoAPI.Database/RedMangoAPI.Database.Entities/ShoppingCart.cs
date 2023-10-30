namespace RedMangoAPI.Database.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart : BaseEntity
    {
        public ShoppingCart()
        {
            this.CartItems = new HashSet<CartItem>();
        }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string StripePaymentIntentId { get; set; }
        public string ClientSecret { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        [NotMapped]
        public double CartTotal { get; set; }
    }
}
