namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using RedMangoAPI.Database;
    using RedMangoAPI.Models;
    using RedMangoAPI.Models.Dto.ShoppingCarts;
    using RedMangoAPI.Services.Mapper;

    using Stripe;

    public class PaymentController : BaseApiController
    {
        private readonly IConfiguration configuration;

        public PaymentController(RedMangoDbContext dbContext, IMapper mapper, IConfiguration configuration)
            : base(dbContext, mapper)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId)
        {
            var shoppingCart = this.DbContext.ShoppingCarts
                .To<GetShoppingCartForPaymentDTO>()
                .FirstOrDefault(sc => sc.UserId == userId);

            if (shoppingCart == null || shoppingCart.CartItems == null || shoppingCart.CartItems.Count == 0)
            {
                return this.BadRequest();
            }

            StripeConfiguration.ApiKey = this.configuration["StripeSettings:SecretKey"];
            shoppingCart.CartTotal = shoppingCart.CartItems
                .Sum(sc => sc.Quantity * sc.MenuItem.Price);

            var options = new PaymentIntentCreateOptions
            {
                Amount = (int)(shoppingCart.CartTotal * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string>
                {
                    "card",
                }
            };

            var service = new PaymentIntentService();
            var payment = service.Create(options);

            shoppingCart.StripePaymentIntentId = payment.Id;
            shoppingCart.ClientSecret = payment.ClientSecret;

            this.ApiResponse.Result = shoppingCart;

            return this.Ok(this.ApiResponse);
        }
    }
}
