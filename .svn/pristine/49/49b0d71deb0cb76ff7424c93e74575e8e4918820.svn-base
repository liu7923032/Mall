using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Up_Address_Proterty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provice",
                table: "Mall_Address");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Mall_Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Province",
                table: "Mall_Address");

            migrationBuilder.AddColumn<string>(
                name: "Provice",
                table: "Mall_Address",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
