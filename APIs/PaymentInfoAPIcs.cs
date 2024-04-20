using HHPWsBe.Models;
using HHPWsBe.DTOs;

namespace HHPWsBe.APIs
{
    public class PaymentInfoAPIcs
    {
        public static void Map(WebApplication app)
        {
            // Scenarios
            // A - The order is new, and its payment type/tip hasn't been accounted for yet.
            // B - The order has NOT been closed, but it has a pre-existing payment type and tip associated with it.
            // C - An order is closed.
            // Check if an order does or does not already have a payment type and tip associated with it. 
            // Get an order by ID
            app.MapGet("/order/payment/{id}", (HHPWsDbContext db, int id) => 
            {
                Order orderToGetPaymentInfo = db.Orders
                .FirstOrDefault(o => o.Id == id);

                if (orderToGetPaymentInfo == null)
                {
                    return Results.NotFound();
                };

                PaymentInfoDTO paymentInfo = new PaymentInfoDTO { 
                    PaymentType = orderToGetPaymentInfo.PaymentType,
                    Tip = orderToGetPaymentInfo.Tip,
                };
                return Results.Ok(paymentInfo);
            });
        }
    }
}
