using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FoodName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        //
        [ForeignKey("FoodModel")]
        public int FoodId { get; set; }
        public FoodModel Food { get; set; }

        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
