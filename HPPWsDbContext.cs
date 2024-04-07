using Microsoft.EntityFrameworkCore;
using HHPWsBe.Models;
using HHPWsBe.Data;

namespace HHPWsBe
{
    public class HHPWsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public HHPWsDbContext(DbContextOptions<HHPWsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UsersData.Users);
            modelBuilder.Entity<Item>().HasData(ItemsData.Items);
            modelBuilder.Entity<OrderItem>().HasData(OrderItemsData.OrderItems);
            modelBuilder.Entity<Order>().HasData(OrdersData.Orders);
        }
    }
}
