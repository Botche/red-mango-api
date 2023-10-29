namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RedMangoAPI.Database;
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.Identity;
    using RedMangoAPI.Utility.Constants;

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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
        {
            try
            {
                var userFromDatabase = this.DbContext.ApplicationUsers
                    .FirstOrDefault(u => string.Compare(u.UserName, model.UserName) == 0);

                if (userFromDatabase != null)
                {
                    this.ApiResponse.ErrorMessages.Add("Username already exists");

                    return BadRequest(this.ApiResponse);
                }

                var newUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.UserName,
                    NormalizedEmail = model.UserName.ToUpper(),
                    Name = model.Name,
                };

                var result = await this.userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    if (!await this.roleManager.RoleExistsAsync(GlobalConstants.ROLE_ADMIN))
                    {
                        await this.roleManager.CreateAsync(new IdentityRole(GlobalConstants.ROLE_ADMIN));
                        await this.roleManager.CreateAsync(new IdentityRole(GlobalConstants.ROLE_CUSTOMER));
                    }

                    await this.userManager.AddToRoleAsync(newUser, GlobalConstants.ROLE_CUSTOMER);

                    return this.Ok(this.ApiResponse);
                }
            }
            catch (Exception ex) { }

            this.ApiResponse.ErrorMessages.Add("Error while registering");

            return BadRequest(this.ApiResponse);
        }
    }
}
