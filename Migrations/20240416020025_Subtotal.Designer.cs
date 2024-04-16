﻿// <auto-generated />
using System;
using HHPWsBe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HHPWsBe.Migrations
{
    [DbContext(typeof(HHPWsDbContext))]
    [Migration("20240416020025_Subtotal")]
    partial class Subtotal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HHPWsBe.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Margherita",
                            Price = 8.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pepperoni",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vegetarian",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hawaiian",
                            Price = 11.99m
                        });
                });

            modelBuilder.Entity("HHPWsBe.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentType")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Tip")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john@example.com",
                            Name = "John Doe",
                            OrderType = "Dine-in",
                            PaymentType = "Credit Card",
                            Phone = "123-456-7890",
                            Status = true,
                            Tip = 1.25m
                        },
                        new
                        {
                            Id = 2,
                            Email = "jane@example.com",
                            Name = "Jane Smith",
                            OrderType = "Pickup",
                            PaymentType = "Cash",
                            Phone = "987-654-3210",
                            Status = false,
                            Tip = 1.25m
                        },
                        new
                        {
                            Id = 3,
                            Email = "sam@example.com",
                            Name = "Sam Johnson",
                            OrderType = "Delivery",
                            PaymentType = "Online Payment",
                            Phone = "555-555-5555",
                            Status = true,
                            Tip = 1.25m
                        });
                });

            modelBuilder.Entity("HHPWsBe.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("HHPWsBe.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCashier")
                        .HasColumnType("boolean");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCashier = true,
                            Uid = "xGPegcj8fSPs1hIxDGdotN6m0fs2"
                        },
                        new
                        {
                            Id = 2,
                            IsCashier = true,
                            Uid = "V5gxdnBKXlPCtnoQ3c7XsXW0pRz2"
                        });
                });

            modelBuilder.Entity("HHPWsBe.Models.OrderItem", b =>
                {
                    b.HasOne("HHPWsBe.Models.Item", "Item")
                        .WithMany("Orders")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HHPWsBe.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HHPWsBe.Models.Item", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("HHPWsBe.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
