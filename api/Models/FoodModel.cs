using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Foods")]
    public class FoodModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public double Price { get; set; }

        public double SpecialPrice { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Image { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        public bool Status { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        //
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
