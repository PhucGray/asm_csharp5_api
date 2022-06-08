using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("OrderDetail")]
    public class OrderDetailModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FoodName { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double VAT { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        //
        [ForeignKey("FoodModel")]
        public int FoodId { get; set; }
        public FoodModel Food { get; set; }

        [ForeignKey("OrderModel")]
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
