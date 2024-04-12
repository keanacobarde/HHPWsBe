﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HHPWsBe.Migrations
{
    public partial class DateClosed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateClosed",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateClosed",
                table: "Orders");
        }
    }
}
