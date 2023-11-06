namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Database;
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models;
    using RedMangoAPI.Models.Dto.ShoppingCarts;
    using RedMangoAPI.Services.Mapper;

    public class ShoppingCartController : BaseApiController
    {
        public ShoppingCartController(RedMangoDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        [HttpGet]
        public ActionResult<ApiResponse> GetShoppingCart(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return this.BadRequest();
                }

                var shoppingCart = this.DbContext.ShoppingCarts
                    .To<GetShoppingCartDTO>()
                    .FirstOrDefault(x => x.UserId == userId);

                if (shoppingCart != null && shoppingCart.CartItems.Count > 0)
                {
                    shoppingCart.CartTotal = shoppingCart.CartItems
                        .Sum(u => u.Quantity * u.MenuItem.Price);
                }

                this.ApiResponse.Result = shoppingCart;
            }
            catch (Exception ex)
            {
                this.ApiResponse.ErrorMessages
                    .Add(ex.ToString());

                return this.BadRequest(this.ApiResponse);
            }

            return this.Ok(this.ApiResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddOrUpdateItemInCart(string userId, Guid menuItemId, int updateQuantityBy)
        {
            var shoppingCart = this.DbContext.ShoppingCarts
                .Include(u => u.CartItems)
                .FirstOrDefault(u => u.UserId == userId);
            var menuItem = this.DbContext.MenuItems
                .FirstOrDefault(u => u.Id == menuItemId);

            if (menuItem == null)
            {
                return this.BadRequest(this.ApiResponse);
            }

            if (shoppingCart == null && updateQuantityBy > 0)
            {
                var newCart = new ShoppingCart()
                {
                    UserId = userId,
                };

                this.DbContext.ShoppingCarts.Add(newCart);
                await this.DbContext.SaveChangesAsync();

                var newCartItem = new CartItem()
                {
                    MenuItemId = menuItemId,
                    MenuItem = null,
                    Quantity = updateQuantityBy,
                    ShoppingCartId = newCart.Id,
                };

                this.DbContext.CartItems.Add(newCartItem);
                await this.DbContext.SaveChangesAsync();
            }
            else
            {
                var cartItemInCart = shoppingCart.CartItems.FirstOrDefault(u => u.MenuItemId == menuItemId);
                if (cartItemInCart == null)
                {
                    var newCartItem = new CartItem()
                    {
                        MenuItemId = menuItemId,
                        Quantity = updateQuantityBy,
                        ShoppingCartId = shoppingCart.Id,
                        MenuItem = null,
                    };
                    this.DbContext.CartItems.Add(newCartItem);
                    await this.DbContext.SaveChangesAsync();
                }
                else
                {
                    int newQuantity = cartItemInCart.Quantity + updateQuantityBy;

                    if (updateQuantityBy == 0 || newQuantity <= 0)
                    {
                        this.DbContext.CartItems.Remove(cartItemInCart);
                        if (shoppingCart.CartItems.Count == 1)
                        {
                            this.DbContext.ShoppingCarts.Remove(shoppingCart);
                        }

                        await this.DbContext.SaveChangesAsync();
                    }
                    else
                    {
                        cartItemInCart.Quantity = newQuantity;
                        this.DbContext.CartItems.Update(cartItemInCart);
                        await this.DbContext.SaveChangesAsync();
                    }
                }
            }

            return this.Ok(this.ApiResponse);
        }
    }
}
