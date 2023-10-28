namespace RedMangoAPI.Controllers
{
    using System.Net;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Data;
    using RedMangoAPI.Models;


    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly RedMangoDbContext dbContext;
        private readonly ApiResponse response;

        public MenuItemController(RedMangoDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            response.Result = await this.dbContext.MenuItems.ToListAsync();
            response.StatusCode = HttpStatusCode.OK;

            return this.Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetMenuItem(Guid id)
        {
            if (id == Guid.Empty) 
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return this.BadRequest(response);
            }

            var menuItem = await this.dbContext.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return this.NotFound(response);
            }

            response.Result = menuItem;
            response.StatusCode = HttpStatusCode.OK;

            return this.Ok(response);
        }
    }
}
