using HHPWsBe.DTOs;
using HHPWsBe.Models;

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

            });
        }
    }
}
