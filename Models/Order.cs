using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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

        public decimal? Total
        {
            get
            {
                if (Items.Count() != 0)
                {
                    decimal total = 0;
                    foreach (var item in Items)
                    {
                        total += item.Price;
                    }
                    return total;
                }
                return null;
            }
        }
    }
}
