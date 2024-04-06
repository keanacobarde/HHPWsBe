using System.ComponentModel.DataAnnotations;

namespace HHPWsBe.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderType { get; set; }
        public string PaymentType { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
