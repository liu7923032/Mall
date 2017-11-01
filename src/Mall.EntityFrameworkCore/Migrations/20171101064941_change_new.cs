using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class change_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mall_Order_CartId",
                table: "Mall_Order",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Order_Mall_Cart_CartId",
                table: "Mall_Order",
                column: "CartId",
                principalTable: "Mall_Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Order_Mall_Cart_CartId",
                table: "Mall_Order");

            migrationBuilder.DropIndex(
                name: "IX_Mall_Order_CartId",
                table: "Mall_Order");
        }
    }
}
