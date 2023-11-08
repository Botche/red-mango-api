namespace RedMangoAPI.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using AutoMapper;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var userFromDb = this.DbContext.ApplicationUsers
                .FirstOrDefault(u => string.Compare(u.UserName, model.UserName) == 0);

            var isValid = await this.userManager.CheckPasswordAsync(userFromDb, model.Password);
            if (!isValid)
            {
                this.ApiResponse.Result = new LoginResponseDTO();
                this.ApiResponse.ErrorMessages.Add("Username or password is incorrect");

                return BadRequest(this.ApiResponse);
            }

            var userRoles = await this.userManager.GetRolesAsync(userFromDb);
            var loginResponse = new LoginResponseDTO
            {
                Email = userFromDb.Email,
                Token = this.GenerateToken(userFromDb, userRoles.FirstOrDefault()),
            };

            this.ApiResponse.Result = loginResponse;

            return this.Ok(this.ApiResponse);
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
                    if (!await this.roleManager.RoleExistsAsync(GlobalConstants.RoleAdmin))
                    {
                        await this.roleManager.CreateAsync(new IdentityRole(GlobalConstants.RoleAdmin));
                        await this.roleManager.CreateAsync(new IdentityRole(GlobalConstants.RoleCustomer));
                    }

                    await this.userManager.AddToRoleAsync(newUser, GlobalConstants.RoleCustomer);

                    return this.Ok(this.ApiResponse);
                }
            }
            catch (Exception ex) { }

            this.ApiResponse.ErrorMessages.Add("Error while registering");

            return BadRequest(this.ApiResponse);
        }

        private string GenerateToken(ApplicationUser user, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(CustomClaimTypes.FullName, user.Name),
                    new Claim(CustomClaimTypes.Id, user.Id.ToString()),
                    new Claim(CustomClaimTypes.Email, user.Email.ToString()),
                    new Claim(CustomClaimTypes.Role, role),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
