namespace RedMangoAPI.Controllers
{
    using System.Net;

    using AutoMapper;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Database;
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models;
    using RedMangoAPI.Models.Dto.MenuItems;
    using RedMangoAPI.Services.Interfaces;
    using RedMangoAPI.Utility.Constants;

    public class MenuItemController : BaseApiController
    {
        private readonly IBlobService blobService;

        public MenuItemController(RedMangoDbContext dbContext, IMapper mapper, IBlobService blobService)
            : base(dbContext, mapper)
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
        [Authorize(Roles = GlobalConstants.RoleAdmin)]
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

                    var menuItemToCreate = this.Mapper.Map<MenuItem>(model);
                    menuItemToCreate.ImageUrl = await this.blobService
                            .Upload(model.ImageFileName, GlobalConstants.StorageContainerName, model.ImageFile);

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
        [Authorize(Roles = GlobalConstants.RoleAdmin)]
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

                    menuItem = this.Mapper.Map(model, menuItem); 

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        await this.blobService.Delete(menuItem.ImageName, GlobalConstants.StorageContainerName);

                        menuItem.ImageUrl = await this.blobService
                            .Upload(model.ImageFileName, GlobalConstants.StorageContainerName, model.ImageFile);
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
        [Authorize(Roles = GlobalConstants.RoleAdmin)]
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

                await this.blobService.Delete(menuItem.ImageName, GlobalConstants.StorageContainerName);

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
