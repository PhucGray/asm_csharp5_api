using api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("User")]
    public class UserModel
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

        public bool Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Required]
        public RolesEnum Role { get; set; } = RolesEnum.CUSTOMER;

        public bool IsDeleted { get; set; } = false;
    }
}
