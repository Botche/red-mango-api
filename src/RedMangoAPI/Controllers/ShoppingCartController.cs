namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using RedMangoAPI.Database;
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models;

    public class ShoppingCartController : BaseApiController
    {
        public ShoppingCartController(RedMangoDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddOrUpdateItemInCart(Guid userId, Guid menuItemId, int updateQuantityBy)
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
