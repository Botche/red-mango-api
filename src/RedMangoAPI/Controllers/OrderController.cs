namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using RedMangoAPI.Database;
    using RedMangoAPI.Models;
    using RedMangoAPI.Models.Dto.OrderHeaders;
    using RedMangoAPI.Services.Mapper;

    public class OrderController : BaseApiController
    {
        public OrderController(RedMangoDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        [HttpGet]
        public ActionResult<ApiResponse> GetOrders(string? userId)
        {
            try
            {
                var orderHeaders = this.DbContext.OrderHeaders
                    .To<GetOrderHeaderDTO>()
                    .OrderByDescending(u => u.Id);

                if (!string.IsNullOrEmpty(userId))
                {
                    this.ApiResponse.Result = orderHeaders
                        .Where(u => u.UserId == userId)
                        .ToList();
                }

                this.ApiResponse.Result = orderHeaders;

                return this.Ok(ApiResponse);
            }
            catch (Exception ex)
            {
                this.ApiResponse.ErrorMessages = new List<string>()
                {
                    ex.Message
                };

                return this.BadRequest();
            }
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<ApiResponse> GetOrders(Guid orderId)
        {
            try
            {
                if (orderId == Guid.Empty)
                {
                    return this.BadRequest();
                }

                var orderHeader = this.DbContext.OrderHeaders
                    .To<GetOrderHeaderDTO>()
                    .FirstOrDefault(oh => oh.Id == orderId);

                if (orderHeader == null)
                {
                    return this.NotFound();
                }

                this.ApiResponse.Result = orderHeader;

                return this.Ok(ApiResponse);
            }
            catch (Exception ex)
            {
                this.ApiResponse.ErrorMessages = new List<string>()
                {
                    ex.Message
                };

                return this.BadRequest();
            }
        }
    }
}
