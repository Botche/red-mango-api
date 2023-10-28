﻿namespace RedMangoAPI.Controllers
{
    using System.Net;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Data;
    using RedMangoAPI.Models;
    using RedMangoAPI.Models.Dto;
    using RedMangoAPI.Services;
    using RedMangoAPI.Utility.Constants;

    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly RedMangoDbContext dbContext;
        private readonly IBlobService blobService;
        private readonly ApiResponse response;

        public MenuItemController(RedMangoDbContext dbContext, IBlobService blobService)
        {
            this.dbContext = dbContext;
            this.blobService = blobService;
            this.response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            this.response.Result = await this.dbContext.MenuItems.ToListAsync();
            this.response.StatusCode = HttpStatusCode.OK;

            return this.Ok(this.response);
        }

        [HttpGet("{id:Guid}", Name = "GetMenuItem")]
        public async Task<IActionResult> GetMenuItem(Guid id)
        {
            if (id == Guid.Empty)
            {
                this.response.StatusCode = HttpStatusCode.BadRequest;
                this.response.IsSuccess = false;
                return this.BadRequest(this.response);
            }

            var menuItem = await this.dbContext.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                this.response.StatusCode = HttpStatusCode.NotFound;
                this.response.IsSuccess = false;
                return this.NotFound(this.response);
            }

            this.response.Result = menuItem;
            this.response.StatusCode = HttpStatusCode.OK;

            return this.Ok(this.response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    if (model.ImageFile == null || model.ImageFile.Length == 0)
                    {
                        return this.BadRequest();
                    }

                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
                    var menuItemToCreate = new MenuItem()
                    {
                        Name = model.Name,
                        Category = model.Category,
                        Description = model.Description,
                        Price = model.Price,
                        SpecialTag = model.SpecialTag,
                        ImageUrl = await this.blobService
                            .Upload(fileName, GlobalConstants.StorageContainerName, model.ImageFile),
                    };

                    this.dbContext.MenuItems.Add(menuItemToCreate);
                    await this.dbContext.SaveChangesAsync();

                    this.response.Result = menuItemToCreate;
                    this.response.StatusCode = HttpStatusCode.Created;

                    return this.CreatedAtRoute(nameof(GetMenuItem), new {id = menuItemToCreate.Id}, this.response);
                }
                else
                {
                    this.response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                this.response.IsSuccess = false;
                this.response.ErrorMessages = new List<string>() { ex.Message };
            }

            return this.response;
        }
    }
}
