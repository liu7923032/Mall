using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Add_Cart_CreatorUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mall_Cart_CreatorUserId",
                table: "Mall_Cart",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Cart_Mall_Account_CreatorUserId",
                table: "Mall_Cart",
                column: "CreatorUserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Cart_Mall_Account_CreatorUserId",
                table: "Mall_Cart");

            migrationBuilder.DropIndex(
                name: "IX_Mall_Cart_CreatorUserId",
                table: "Mall_Cart");
        }
    }
}
