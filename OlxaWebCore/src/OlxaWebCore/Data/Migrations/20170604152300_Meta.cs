using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlxaWebCore.Data.Migrations
{
    public partial class Meta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publish",
                table: "Portfolios");

            migrationBuilder.AddColumn<string>(
                name: "DevelopmentTime",
                table: "Portfolios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Portfolios",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Portfolios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentTime",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Portfolios");

            migrationBuilder.AddColumn<bool>(
                name: "Publish",
                table: "Portfolios",
                nullable: false,
                defaultValue: false);
        }
    }
}
