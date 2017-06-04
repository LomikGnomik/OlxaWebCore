using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlxaWebCore.Data.Migrations
{
    public partial class Portfolio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Portfolios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Portfolios",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Portfolios",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Publish",
                table: "Portfolios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Portfolios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Publish",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Portfolios");
        }
    }
}
