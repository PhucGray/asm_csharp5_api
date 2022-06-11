using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("OrderStatuses")]
    public class OrderStatusModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Title { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
    }
}
