using System.ComponentModel.DataAnnotations;

namespace api.Models.Request
{
    public class UpdateUserReqModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int RoleId { get; set; }
    }
}
