namespace RedMangoAPI.Controllers
{
    using System.Net;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    using RedMangoAPI.Data;
    using RedMangoAPI.Models;


    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly RedMangoDbContext DbContext;
        protected readonly ApiResponse ApiResponse;

        public BaseApiController(RedMangoDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.ApiResponse = new ApiResponse();
        }

        public override OkResult Ok()
        {
            this.ApiResponse.StatusCode = HttpStatusCode.OK;

            return base.Ok();
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            this.ApiResponse.StatusCode = HttpStatusCode.OK;

            return base.Ok(value);
        }

        public override BadRequestResult BadRequest()
        {
            this.ApiResponse.StatusCode = HttpStatusCode.BadRequest;
            this.ApiResponse.IsSuccess = false;

            return base.BadRequest();
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object error)
        {
            this.ApiResponse.StatusCode = HttpStatusCode.BadRequest;
            this.ApiResponse.IsSuccess = false;

            return base.BadRequest(error);
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] ModelStateDictionary modelState)
        {
            this.ApiResponse.StatusCode = HttpStatusCode.BadRequest;
            this.ApiResponse.IsSuccess = false;

            return base.BadRequest(modelState);
        }

        public override NotFoundResult NotFound()
        {
            this.ApiResponse.StatusCode = HttpStatusCode.NotFound;
            this.ApiResponse.IsSuccess = false;

            return base.NotFound();
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object value)
        {
            this.ApiResponse.StatusCode = HttpStatusCode.NotFound;
            this.ApiResponse.IsSuccess = false;

            return base.NotFound(value);
        }
    }
}
