using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("VATs")]
    public class VATModel
    {
        [Key]
        public int Id { get; set; }

        public double Value { get; set; } = 0;
    }
}
