using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public enum Roles
    {
        Customer = -1,
        Employee = 0,
        Admin = 1,
        SuperAdmin = 2,
    }

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

        public bool IsDeleted { get; set; } = false;

        [Required]
        public Roles Role { get; set; } = Roles.Customer;
    }
}
