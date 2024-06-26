﻿using Microsoft.EntityFrameworkCore;
using HHPWsBe.Models;
using HHPWsBe.DTOs;

namespace HHPWsBe.APIs
{
    public class OrdersAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/orders", (HHPWsDbContext db, AddOrderDTO newOrder) => 
            {
                try
                {
                   db.Orders.Add(new Order
                    {
                        Id = db.Orders.Count() + 1,
                        Name = newOrder.Name,
                        Status = true,
                        Phone = newOrder.Phone,
                        Email = newOrder.Email,
                        OrderType = newOrder.OrderType,
                        PaymentType = String.Empty,
                        Tip = 0,
                    });
                    db.SaveChanges();
                    return Results.Created($"/orders/{newOrder.Id}", newOrder);
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

            app.MapPut("/orders/{id}", (HHPWsDbContext db, int id, AddOrderDTO updatedOrder) =>
            {
                var orderToUpdate = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                if (updatedOrder.Name != null)
                { 
                    orderToUpdate.Name = updatedOrder.Name;
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
                };

                db.SaveChanges();
                return Results.Ok();
            });

            app.MapPut("/orders/paymentinfo/{id}", (HHPWsDbContext db, int id, PaymentInfoDTO updatedOrder) =>
            {
                var orderToUpdate = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                if (updatedOrder.PaymentType != null)
                {
                    orderToUpdate.PaymentType = updatedOrder.PaymentType;
                }

                if (updatedOrder.Tip != null)
                {
                    orderToUpdate.Tip = updatedOrder.Tip;
                };

                orderToUpdate.Status = updatedOrder.Status;

                db.SaveChanges();
                return Results.Ok();
            });

            app.MapDelete("/orders/{id}", (HHPWsDbContext db, int id) =>
            {
                Order orderToDelete = db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item)
                         .SingleOrDefault(order => order.Id == id);
                if (orderToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(orderToDelete);
                db.SaveChanges();
                return Results.Ok(db.Orders);
            });

            // ** CUSTOM APIS ** //
            app.MapGet("/orders/{id}/items", (HHPWsDbContext db, int id) => {
                var orderToGetItems = db.Orders
                         .Where(o => o.Id == id)
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item)
                         .Select(order => new
                         {
                             Items = order.Items.Select(oi => new ItemDTO
                             {
                                 Id = oi.Item.Id,
                                 OrderItemId = oi.Id,
                                 Name = oi.Item.Name,
                                 Price = oi.Item.Price,
                             })
                         });      
                return Results.Ok(orderToGetItems);
            });

            app.MapGet("/order/edit/{id}", (HHPWsDbContext db, int id) =>
            {
                var orderToEdit = db.Orders.FirstOrDefault(o => o.Id == id);
                if (orderToEdit == null)
                { 
                    return Results.NotFound();
                }

                AddOrderDTO orderInfo = new AddOrderDTO {
                Id = orderToEdit.Id,
                Name = orderToEdit.Name,
                Phone = orderToEdit.Phone, 
                Email = orderToEdit.Email,
                OrderType = orderToEdit.OrderType,
                };
                return Results.Ok(orderInfo);
            });
        }
    }
}
