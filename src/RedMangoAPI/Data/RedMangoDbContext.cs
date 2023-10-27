namespace RedMangoAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class RedMangoDbContext : IdentityDbContext
    {
        public RedMangoDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
