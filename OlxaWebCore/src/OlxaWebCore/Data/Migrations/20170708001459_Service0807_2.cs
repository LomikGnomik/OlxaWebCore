using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlxaWebCore.Data.Migrations
{
    public partial class Service0807_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDevelop",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "TimeDevelopForClient",
                table: "Services",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeDevelopForClient",
                table: "Services");

            migrationBuilder.AddColumn<string>(
                name: "TimeDevelop",
                table: "Services",
                nullable: true);
        }
    }
}
