using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Order")]
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        public double ToTalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string OrderAddress { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }

        //
        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public UserModel User { get; set; }

        [ForeignKey("OrderStatusModel")]
        public int OrderStatusId { get; set; }
        public OrderStatusModel OrderStatus { get; set; }

        public ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
