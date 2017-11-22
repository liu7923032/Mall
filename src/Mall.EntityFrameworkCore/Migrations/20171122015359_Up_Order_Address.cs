using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Up_Order_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressInfo",
                table: "Mall_Order");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Mall_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mall_Order_AddressId",
                table: "Mall_Order",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Order_Mall_Address_AddressId",
                table: "Mall_Order",
                column: "AddressId",
                principalTable: "Mall_Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Order_Mall_Address_AddressId",
                table: "Mall_Order");

            migrationBuilder.DropIndex(
                name: "IX_Mall_Order_AddressId",
                table: "Mall_Order");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Mall_Order");

            migrationBuilder.AddColumn<string>(
                name: "AddressInfo",
                table: "Mall_Order",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
