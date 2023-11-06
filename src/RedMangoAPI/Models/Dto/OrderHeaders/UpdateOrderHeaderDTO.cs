namespace RedMangoAPI.Models.Dto.OrderHeaders
{
    using System.ComponentModel.DataAnnotations;

    using RedMangoAPI.Database.Entities;
    using RedMangoAPI.Services.Mapper.Interfaces;


    public class UpdateOrderHeaderDTO : IMapTo<OrderHeader>
    {
        public Guid Id { get; set; }
        [Required]
        public string PickupName { get; set; }
        [Required]
        public string PickupPhoneNumber { get; set; }
        [Required]
        public string PickupEmail { get; set; }

        public DateTime OrderDate { get; set; }
        public string StripePaymentIntentId { get; set; }
        public string Status { get; set; }
    }
}
