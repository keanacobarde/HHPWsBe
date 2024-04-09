using Microsoft.EntityFrameworkCore;
using HHPWsBe.Models;

namespace HHPWsBe.APIs
{
    public class OrdersAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders", (HHPWsDbContext db) => 
            {
                return db.Orders.Include(o => o.Items);
            });

            app.MapGet("/orders/{id}", (HHPWsDbContext db, int id) =>
            { 
                Order orderDetails = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderDetails == null)
                { 
                    return Results.NotFound();
                }
                return Results.Ok(orderDetails);
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

        }
    }
}
