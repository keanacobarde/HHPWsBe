using HHPWsBe.Models;
using HHPWsBe.DTOs;
using HHPWsBe.Migrations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

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
                    OrderId = id,
                    PaymentType = orderToGetPaymentInfo.PaymentType,
                    Tip = orderToGetPaymentInfo.Tip,
                };
                return Results.Ok(paymentInfo);
            });

            app.MapGet("/revenue", (HHPWsDbContext db) => 
            {
                decimal? total = 0;
                foreach (Order order in db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item))
                {
                    if (order.Status == false && order.Total != null)
                    {
                        total += order.Total;
                    }
                }
                RevenueDTO revenue = new RevenueDTO {
                    TotalRevenue = total,
                    TipTotal = db.Orders.Where(o => o.Status == false).Where(o => o.Tip != 0).Count(),
                    DineInTotal = db.Orders.Where(o => o.Status == false).Where(o => o.OrderType == "Dine-in").Count(),
                    PickupTotal = db.Orders.Where(o => o.Status == false).Where(o => o.OrderType == "Pickup").Count(),
                    DeliveryTotal = db.Orders.Where(o => o.Status == false).Where(o => o.OrderType == "Delivery").Count(),
                    CashTotal = db.Orders.Where(o => o.Status == false).Where(o => o.PaymentType == "Cash").Count(),
                    CreditTotal = db.Orders.Where(o => o.Status == false).Where(o => o.PaymentType == "Credit").Count(),
                    DebitTotal = db.Orders.Where(o => o.Status == false).Where(o => o.PaymentType == "Debit").Count(),
                };
                return Results.Ok(revenue);
            });
        }
    }
}
