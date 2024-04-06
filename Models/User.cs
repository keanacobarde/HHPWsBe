using System.ComponentModel.DataAnnotations;

namespace HHPWsBe.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public bool IsCashier { get; set; }
        public string Uid { get; set; }
    }
}
