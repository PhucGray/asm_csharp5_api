using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class VATModel
    {
        [Key]
        public int Id { get; set; }

        public double VAT { get; set; } = 0;
    }
}
