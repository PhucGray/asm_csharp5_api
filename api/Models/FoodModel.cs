using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Food")]
    public class FoodModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public double SpecialPrice { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Image { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }

        [Required]
        public bool Status { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public bool IsDeleted { get; set; } = false;

        //
        ICollection<OrderDetailModel> OrderDetails { get; set; }

        //
        [NotMapped]
        public IFormFile ImageFile { get; set; } 
    }
}
