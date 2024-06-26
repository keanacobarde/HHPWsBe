﻿using System.ComponentModel.DataAnnotations;
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
        public decimal? Tip { get; set; }
        public DateTime? DateClosed { get; set; }  
        public decimal? Total {
            get
            {
                return Subtotal + Tip;
            }
        }
        public List<OrderItem>? Items { get; set; }
        public decimal? Subtotal
        {
            get
            {
                if (Items != null)
                {
                    return Items?.Sum(item => item.Price);
                }
                return 0;
            }
        }
    }
};
