namespace RedMangoAPI.Database.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderHeader : BaseEntity
    {
        public OrderHeader()
        {
            this.OrderDetails = new HashSet<OrderDetails>();
        }

        [Required]
        public string PickupName { get; set; }
        [Required]
        public string PickupPhoneNumber { get; set; }
        [Required]
        public string PickupEmail { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public double OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }
        public string StripePaymentIntentId { get; set; }
        public string Status { get; set; }
        public int TotalItems { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
