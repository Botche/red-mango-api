namespace RedMangoAPI.Controllers
{
    using System.Text.Json;

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
        public ActionResult<ApiResponse> GetOrders(string userId, string searchString, string status, int pageNumber = 1, int pageSize = 5)
        {
            try
            {
                var orderHeaders = this.DbContext.OrderHeaders
                    .To<GetOrderHeaderDTO>();

                if (!string.IsNullOrEmpty(userId))
                {
                    orderHeaders = orderHeaders
                        .Where(oh => oh.UserId == userId);
                }

                if (!string.IsNullOrEmpty(searchString))
                {
                    var searcStringToUpper = searchString.ToUpper();

                    orderHeaders = orderHeaders
                        .Where(oh => oh.PickupPhoneNumber.ToUpper().Contains(searcStringToUpper)
                            || oh.PickupEmail.ToUpper().Contains(searcStringToUpper)
                            || oh.PickupName.ToUpper().Contains(searcStringToUpper));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    orderHeaders = orderHeaders
                        .Where(oh => oh.Status.ToUpper().Equals(status.ToUpper()));
                }

                var pagination = new Pagination()
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = orderHeaders.Count(),
                };

                this.Response.Headers
                    .Add("X-Pagination", JsonSerializer.Serialize(pagination));

                this.ApiResponse.Result = orderHeaders
                    .OrderByDescending(u => u.ItemNumber)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

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
        public ActionResult<ApiResponse> GetOrder(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return this.BadRequest();
                }

                var orderHeader = this.DbContext.OrderHeaders
                    .To<GetOrderHeaderDTO>()
                    .FirstOrDefault(oh => oh.Id == id);

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
                order.OrderDetails = null;
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

                    var mappedOrder = this.Mapper.Map<GetOrderHeaderDTO>(order);
                    this.ApiResponse.Result = mappedOrder;
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

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ApiResponse>> UpdateOrder(Guid id, [FromBody] UpdateOrderHeaderDTO model)
        {
            try
            {
                if (model == null || id != model.Id)
                {
                    return this.BadRequest();
                }

                var orderFromDb = this.DbContext.OrderHeaders
                    .Find(id);

                if (orderFromDb == null)
                {
                    return this.BadRequest();
                }

                if (!string.IsNullOrEmpty(model.PickupName))
                {
                    orderFromDb.PickupName = model.PickupName;
                }
                if (!string.IsNullOrEmpty(model.PickupEmail))
                {
                    orderFromDb.PickupEmail = model.PickupEmail;
                }
                if (!string.IsNullOrEmpty(model.PickupPhoneNumber))
                {
                    orderFromDb.PickupPhoneNumber = model.PickupPhoneNumber;
                }
                if (!string.IsNullOrEmpty(model.Status))
                {
                    orderFromDb.Status = model.Status;
                }
                if (!string.IsNullOrEmpty(model.StripePaymentIntentId))
                {
                    orderFromDb.StripePaymentIntentId = model.StripePaymentIntentId;
                }

                this.DbContext.Update(orderFromDb);
                await this.DbContext.SaveChangesAsync();

                return this.Ok(this.ApiResponse);
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
