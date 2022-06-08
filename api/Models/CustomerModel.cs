using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        //
        public ICollection<OrderModel> Orders { get; set; }
    }
}
