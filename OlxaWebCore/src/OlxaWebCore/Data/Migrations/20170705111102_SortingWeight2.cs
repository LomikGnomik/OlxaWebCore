using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlxaWebCore.Data.Migrations
{
    public partial class SortingWeight2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortingWeight",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortingWeight",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortingWeight",
                table: "Portfolios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortingWeight",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SortingWeight",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SortingWeight",
                table: "Portfolios");
        }
    }
}
