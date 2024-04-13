using Microsoft.EntityFrameworkCore;
using HHPWsBe.Models;

namespace HHPWsBe.APIs
{
    public class OrdersAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/orders", (HHPWsDbContext db, Order newOrder) => 
            {
                try
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    return Results.Created($"/api/reservations/{newOrder.Id}", newOrder);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
            });

            app.MapGet("/orders", (HHPWsDbContext db) =>
            {
                return db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item);
            });

            app.MapGet("/orders/{id}", (HHPWsDbContext db, int id) =>
            {
                return db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item)
                         .SingleOrDefault(order => order.Id == id);
            });

            app.MapPut("/orders/{id}", (HHPWsDbContext db, int id, Order updatedOrder) =>
            {
                Order orderToUpdate = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                if (updatedOrder.Name != null)
                { 
                    orderToUpdate.Name = updatedOrder.Name;
                }

                if (updatedOrder.Status != orderToUpdate.Status)
                {
                    orderToUpdate.Status = updatedOrder.Status;
                }

                if (updatedOrder.Phone != null)
                {
                    orderToUpdate.Phone = updatedOrder.Phone;
                }

                if (updatedOrder.Email != null)
                {
                    orderToUpdate.Email = updatedOrder.Email;
                }

                if (updatedOrder.OrderType != null)
                {
                    orderToUpdate.OrderType = updatedOrder.OrderType;
                }

                if (updatedOrder.PaymentType != null)
                {
                    orderToUpdate.PaymentType = updatedOrder.PaymentType;
                }

                if (updatedOrder.Tip != null)
                {
                    orderToUpdate.Tip = updatedOrder.Tip;
                }

                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapDelete("/orders/{id}", (HHPWsDbContext db, int id) =>
            {
                Order orderToDelete = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(orderToDelete);
                return Results.Ok(db.Orders);
            });

            // ** CUSTOM APIS ** //
            app.MapGet("/orders/{id}/items", (HHPWsDbContext db, int id) => { 
                Order orderToGetItems = db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item)
                         .SingleOrDefault(order => order.Id == id);
                if (orderToGetItems == null)
                {
                    return Results.NotFound();
                }
                var itemsOfOrder = orderToGetItems.Items
                    .Select(oi => oi.Item)
                    .Select(i => new { i.Id, i.Name, i.Price});
                return Results.Ok(itemsOfOrder);
            });
        }
    }
}
