namespace RedMangoAPI.Database.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
