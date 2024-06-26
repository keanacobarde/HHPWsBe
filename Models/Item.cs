﻿using System.ComponentModel.DataAnnotations;

namespace HHPWsBe.Models
{
    public class Item
    {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public decimal Price { get; set; }
            public List<OrderItem> Orders { get; set; } = new List<OrderItem>();

    }
}
