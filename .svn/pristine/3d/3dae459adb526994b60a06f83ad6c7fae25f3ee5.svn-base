using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Add_Address_Area : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Mall_OrderRecord");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Mall_OrderRecord");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Mall_Address",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Mall_Address",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Mall_Address");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Mall_OrderRecord",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Mall_OrderRecord",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Mall_Address",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
