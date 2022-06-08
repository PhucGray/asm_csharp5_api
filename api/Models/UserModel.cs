using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey("RoleModel")]
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
