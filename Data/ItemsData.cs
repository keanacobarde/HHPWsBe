using HHPWsBe.Models;

namespace HHPWsBe.Data
{
    public class ItemsData
    {
        public static List<Item> Items = new List<Item>
        {
            new Item() { Id = 1, Name = "Margherita", Price = 8.99M },
            new Item() { Id = 2, Name = "Pepperoni", Price = 9.99M },
            new Item() { Id = 3, Name = "Vegetarian", Price = 10.99M },
            new Item() { Id = 4, Name = "Hawaiian", Price = 11.99M },
        };
    }
}
