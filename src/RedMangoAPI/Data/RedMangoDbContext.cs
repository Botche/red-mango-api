namespace RedMangoAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Constants.Seeds;
    using RedMangoAPI.Models;

    public class RedMangoDbContext : IdentityDbContext<ApplicationUser>
    {
        public RedMangoDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MenuItem>().HasData(MenuItemSeed.MenuItems);
        }
    }
}
