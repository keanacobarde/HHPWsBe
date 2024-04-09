using HHPWsBe.Models;

namespace HHPWsBe.APIs
{
    public class ItemsAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/items", (HHPWsDbContext db) =>
            {
               return db.Items.ToList();
            });

            app.MapDelete("/items/delete", (HHPWsDbContext db, int id) => 
            { 
                Item itemToDelete = db.Items.FirstOrDefault(i => i.Id == id);
                if (itemToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Items.Remove(itemToDelete);
                db.SaveChanges();
                return Results.Ok(db.Items);
            });
        }
    }
}
