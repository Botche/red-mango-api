namespace RedMangoAPI.Controllers
{
    using AutoMapper;

    using Microsoft.AspNetCore.Mvc;

    using RedMangoAPI.Database;
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models;
    using RedMangoAPI.Models.Dto.OrderHeaders;
    using RedMangoAPI.Services.Mapper;
    using RedMangoAPI.Utility.Constants;

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

        [HttpGet("{orderId:Guid}")]
        public ActionResult<ApiResponse> GetOrder(Guid orderId)
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

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateOrder([FromBody] CreateOrderHeaderDTO model)
        {
            try
            {
                var order = this.Mapper.Map<OrderHeader>(model);

                if (string.IsNullOrEmpty(order.Status))
                {
                    order.Status = GlobalConstants.StatusPending;
                }

                if (ModelState.IsValid)
                {
                    this.DbContext.OrderHeaders.Add(order);
                    await this.DbContext.SaveChangesAsync();

                    foreach (var orderDetailsDto in model.OrderDetails)
                    {
                        var orderDetails = this.Mapper.Map<OrderDetails>(orderDetailsDto);
                        orderDetails.OrderHeaderId = order.Id;

                        this.DbContext.OrderDetails.Add(orderDetails);
                    }

                    await this.DbContext.SaveChangesAsync();

                    this.ApiResponse.Result = order;
                    return this.Ok(this.ApiResponse);
                }
            }
            catch (Exception ex)
            {
                this.ApiResponse.ErrorMessages = new List<string>()
                {
                    ex.Message
                };

                return this.BadRequest();
            }

            return this.ApiResponse;
        }
    }
}
