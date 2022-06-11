using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }
        public double VAT { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Note { get; set; }

        //
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public UserModel User { get; set; }

        [ForeignKey("OrderStatuses")]
        public int OrderStatusId { get; set; } = 1;
        public OrderStatusModel OrderStatus { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
