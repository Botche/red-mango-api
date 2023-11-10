namespace RedMangoAPI.Models.Dto.OrderHeaders
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.OrderDetails;
    using RedMangoAPI.Services.Mapper.Interfaces;

    public class GetOrderHeaderDTO : IMapFrom<OrderHeader>
    {
        public Guid Id { get; set; }
        public int ItemNumber { get; set; }

        public string UserId { get; set; }

        public string PickupName { get; set; }
        public string PickupPhoneNumber { get; set; }
        public string PickupEmail { get; set; }

        public double OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }
        public string StripePaymentIntentId { get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }

        public IEnumerable<GetOrderDetailsDTO> OrderDetails { get; set; }
    }
}
