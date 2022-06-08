using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public enum OrderStatus
    {
        Processing = 1,
        Delivering = 2,
        Done = 3,
    }

    [Table("Order")]
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double ToTalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string OrderAddress { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Processing;

        //
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }

        ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
