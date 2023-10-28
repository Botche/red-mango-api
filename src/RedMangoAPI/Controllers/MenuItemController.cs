namespace RedMangoAPI.Controllers
{
    using System.Net;

    using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetMenuItems()
        {
            response.Result = this.dbContext.MenuItems.ToList();
            response.StatusCode = HttpStatusCode.OK;

            return this.Ok(response);
        }
    }
}
