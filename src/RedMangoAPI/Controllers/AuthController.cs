namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RedMangoAPI.Database;
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.Identity;

    public class AuthController : BaseApiController
    {
        private readonly string secretKey;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthController(RedMangoDbContext dbContext, 
            IMapper mapper, 
            IConfiguration configuration, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager
        ) : base(dbContext, mapper)
        {
            this.secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
    }
}
