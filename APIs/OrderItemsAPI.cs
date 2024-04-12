using HHPWsBe.DTOs;
using HHPWsBe.Models;
using Microsoft.EntityFrameworkCore;

namespace HHPWsBe.APIs
{
    public class OrderItemsAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/order/additem", (HHPWsDbContext db, OrderItemDTO addItemToOrderDTO) => 
            {
                Order order = db.Orders.FirstOrDefault(o => o.Id == addItemToOrderDTO.OrderId);
                Item item = db.Items.FirstOrDefault(i => i.Id == addItemToOrderDTO.ItemId);

                if (order == null || item == null)
                {
                    return Results.NotFound();
                }

                OrderItem orderItem = new()
                {
                    Item = item,
                    Order = order,
                };

                db.OrderItems.Add(orderItem);

                db.SaveChanges();

                return Results.Ok(orderItem);

            });

            app.MapPost("/order/deleteitem/", (HHPWsDbContext db, DeleteOrderItemDTO orderItemToDelete) =>
            {
                Order order = db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item)
                         .FirstOrDefault(o => o.Id == orderItemToDelete.OrderId);
                OrderItem orderItemToRemove = order.Items.FirstOrDefault(oi => oi.Id == orderItemToDelete.OrderItemId);

                if (order == null || orderItemToRemove == null)
                {
                    return Results.NotFound();
                }

                order.Items.Remove(orderItemToRemove);
                db.SaveChanges();
                return Results.Ok(order);
            });
        }
    }
}
