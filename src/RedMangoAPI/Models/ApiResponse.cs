namespace RedMangoAPI.Models
{
    using System.Net;

    public class ApiResponse
    {
        public ApiResponse()
        {
            this.ErrorMessages = new List<string>();
            this.IsSuccess = true;
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}
