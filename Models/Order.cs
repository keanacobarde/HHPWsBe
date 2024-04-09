using System.ComponentModel.DataAnnotations;

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
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal? Total
        {
            get
            {
                if (Items.Count() != 0)
                {
                    decimal total = 0;
                    foreach (var item in Items)
                    {
                        total += item.Item.Price;
                    }
                    return total;
                }
                return null;
            }
        }
    }
}
