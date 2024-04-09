using HHPWsBe.Models;

namespace HHPWsBe.Data
{
    public class OrderItemsData
    {
        public static List<OrderItem> OrderItems = new List<OrderItem>()
        {
            new OrderItem() { Id = 1, Item = ItemsData.Items[0], Order = OrdersData.Orders[0] },
            new OrderItem() { Id = 2, Item = ItemsData.Items[1], Order = OrdersData.Orders[0] },
            new OrderItem() { Id = 3, Item = ItemsData.Items[2], Order = OrdersData.Orders[1] },
            new OrderItem() { Id = 4, Item = ItemsData.Items[0], Order = OrdersData.Orders[1] },
            new OrderItem() { Id = 5, Item = ItemsData.Items[2], Order = OrdersData.Orders[2] },
            new OrderItem() { Id = 5, Item = ItemsData.Items[2], Order = OrdersData.Orders[2] },
        };
    }
}
