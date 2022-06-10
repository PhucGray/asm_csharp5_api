using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class OrderStatusModel
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }

        [Required]
        public string Title { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
    }
}
