namespace RedMangoAPI.Database
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Database.SeedsData;

    public class RedMangoDbContext : IdentityDbContext<ApplicationUser>
    {
        public RedMangoDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MenuItem>()
                .HasKey(mi => mi.Id)
                .IsClustered(false);

            builder.Entity<MenuItem>()
                .HasIndex(mi => mi.ItemNumber)
                .IsUnique()
                .IsClustered();

            builder.Entity<MenuItem>()
                .Property(mi => mi.ItemNumber)
                .UseIdentityColumn();

            builder.Entity<MenuItem>().HasData(MenuItemSeed.MenuItems);
        }
    }
}
