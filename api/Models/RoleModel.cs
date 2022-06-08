using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class RoleModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        ICollection<UserModel> Users { get; set; }
    }
}
