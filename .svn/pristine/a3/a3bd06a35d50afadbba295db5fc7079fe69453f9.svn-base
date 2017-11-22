using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Add_Order_LastUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mall_Order_LastModifierUserId",
                table: "Mall_Order",
                column: "LastModifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Order_Mall_Account_LastModifierUserId",
                table: "Mall_Order",
                column: "LastModifierUserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Order_Mall_Account_LastModifierUserId",
                table: "Mall_Order");

            migrationBuilder.DropIndex(
                name: "IX_Mall_Order_LastModifierUserId",
                table: "Mall_Order");
        }
    }
}
