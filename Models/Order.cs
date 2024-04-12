using System.ComponentModel.DataAnnotations;
using HHPWsBe;

namespace HHPWsBe.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OrderType { get; set; }
        public string PaymentType { get; set; }
        public float Tip { get; set; }
        public List<OrderItem>? Items { get; set; }
        public decimal? Total
        {
            get
            {
                return Items.Sum(item => item.Price);
            }
        }
    }
};
