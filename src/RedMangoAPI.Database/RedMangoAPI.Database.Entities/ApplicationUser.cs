namespace RedMangoAPI.Database.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ShoppingCarts = new HashSet<ShoppingCart>();
            this.OrderHeaders = new HashSet<OrderHeader>();
        }

        public string Name { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
