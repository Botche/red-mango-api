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

    public class MenuItemController : BaseApiController
    {
        private readonly IBlobService blobService;

        public MenuItemController(RedMangoDbContext dbContext, IBlobService blobService)
            : base(dbContext) 
        {
            this.blobService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            this.ApiResponse.Result = await this.DbContext.MenuItems.ToListAsync();
            this.ApiResponse.StatusCode = HttpStatusCode.OK;

            return this.Ok(this.ApiResponse);
        }

        [HttpGet("{id:Guid}", Name = "GetMenuItem")]
        public async Task<IActionResult> GetMenuItem(Guid id)
        {
            if (id == Guid.Empty)
            {
                return this.BadRequest(this.ApiResponse);
            }

            var menuItem = await this.DbContext.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return this.NotFound(this.ApiResponse);
            }

            this.ApiResponse.Result = menuItem;
            this.ApiResponse.StatusCode = HttpStatusCode.OK;

            return this.Ok(this.ApiResponse);
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

                    this.DbContext.MenuItems.Add(menuItemToCreate);
                    await this.DbContext.SaveChangesAsync();

                    this.ApiResponse.Result = menuItemToCreate;
                    this.ApiResponse.StatusCode = HttpStatusCode.Created;

                    return this.CreatedAtRoute(nameof(GetMenuItem), new { id = menuItemToCreate.Id }, this.ApiResponse);
                }
                else
                {
                    this.ApiResponse.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                this.ApiResponse.IsSuccess = false;
                this.ApiResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return this.ApiResponse;
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ApiResponse>> UpdateMenuItem(Guid id, [FromForm] MenuItemUpdateDTO model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    if (model == null || id != model.Id)
                    {
                        return this.BadRequest();
                    }

                    var menuItem = await this.DbContext.MenuItems.FindAsync(id);

                    if (menuItem == null)
                    {
                        return this.BadRequest();
                    }

                    menuItem.Name = model.Name;
                    menuItem.Description = model.Description;
                    menuItem.Category = model.Category;
                    menuItem.Price = model.Price;
                    menuItem.SpecialTag = model.SpecialTag;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        var imageName = menuItem.ImageUrl.Split('/').Last();
                        await this.blobService.Delete(imageName, GlobalConstants.StorageContainerName);

                        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
                        menuItem.ImageUrl = await this.blobService
                            .Upload(fileName, GlobalConstants.StorageContainerName, model.ImageFile);
                    }

                    this.DbContext.MenuItems.Update(menuItem);
                    await this.DbContext.SaveChangesAsync();

                    this.ApiResponse.StatusCode = HttpStatusCode.NoContent;
                    return this.Ok(this.ApiResponse);
                }
                else
                {
                    this.ApiResponse.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                this.ApiResponse.IsSuccess = false;
                this.ApiResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return this.ApiResponse;
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<ApiResponse>> DeleteMenuItem(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return this.BadRequest();
                }
                
                var menuItem = await this.DbContext.MenuItems.FindAsync(id);

                if (menuItem == null)
                {
                    return this.BadRequest();
                }

                var imageName = menuItem.ImageUrl.Split('/').Last();
                await this.blobService.Delete(imageName, GlobalConstants.StorageContainerName);

                // Intentionaly added delay
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);

                this.DbContext.MenuItems.Remove(menuItem);
                await this.DbContext.SaveChangesAsync();

                this.ApiResponse.StatusCode = HttpStatusCode.NoContent;
                return this.Ok(this.ApiResponse);
            }
            catch (Exception ex)
            {
                this.ApiResponse.IsSuccess = false;
                this.ApiResponse.ErrorMessages = new List<string>() { ex.Message };
            }

            return this.ApiResponse;
        }
    }
}
