using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlxaWebCore.Data.Migrations
{
    public partial class Service0807 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DemoAdmin",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DemoSite",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceForClient",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeDevelop",
                table: "Services",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemoAdmin",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DemoSite",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "PriceForClient",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TimeDevelop",
                table: "Services");
        }
    }
}
