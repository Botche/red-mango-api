namespace RedMangoAPI.Database.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderDetails : BaseEntity
    {
        [Required]
        public Guid OrderHeaderId { get; set; }
        [ForeignKey(nameof(OrderHeaderId))]
        public virtual OrderHeader OrderHeader { get; set; }

        [Required]
        public Guid MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        public virtual MenuItem MenuItem { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
