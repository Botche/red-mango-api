namespace RedMangoAPI.Models.Dto.OrderHeaders
{
    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;


    public class UpdateOrderHeaderDTO : IMapTo<OrderHeader>
    {
        public Guid Id { get; set; }
        public string PickupName { get; set; }
        public string PickupPhoneNumber { get; set; }
        public string PickupEmail { get; set; }

        public string StripePaymentIntentId { get; set; }
        public string Status { get; set; }
    }
}
