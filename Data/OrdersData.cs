using HHPWsBe.Models;

namespace HHPWsBe.Data
{
    public class OrdersData
    {
        public static List<Order> Orders = new List<Order>()
        {
        new Order() { Id = 1, Name = "John Doe", Status = true, Phone = "123-456-7890", Email = "john@example.com", OrderType = "Delivery", PaymentType = "Credit Card" },
        new Order() { Id = 2, Name = "Jane Smith", Status = false, Phone = "987-654-3210", Email = "jane@example.com", OrderType = "Pickup", PaymentType = "Cash" },
        new Order() { Id = 3, Name = "Sam Johnson", Status = true, Phone = "555-555-5555", Email = "sam@example.com", OrderType = "Delivery", PaymentType = "Online Payment" },
        };
    }
}
