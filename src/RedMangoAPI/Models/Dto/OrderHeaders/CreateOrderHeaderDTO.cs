namespace RedMangoAPI.Models.Dto.OrderHeaders
{
    using System.ComponentModel.DataAnnotations;

    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Models.Dto.OrderDetails;
    using RedMangoAPI.Services.Mapper.Interfaces;


    public class CreateOrderHeaderDTO : IMapTo<OrderHeader>
    {
        [Required]
        public string PickupName { get; set; }
        [Required]
        public string PickupPhoneNumber { get; set; }
        [Required]
        public string PickupEmail { get; set; }

        public string UserId { get; set; }

        public double OrderTotal { get; set; }

        public string StripePaymentIntentId { get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }

        public IEnumerable<CreateOrderDetailsDTO> OrderDetails { get; set; }
    }
}
