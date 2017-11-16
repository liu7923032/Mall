using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Change_Integral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "IntergralDesc",
                table: "Mall_Integral");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mall_Integral",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DeptOrUser",
                table: "Mall_Integral",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "Mall_Integral",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstNo",
                table: "Mall_Integral",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Mall_Integral",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral",
                column: "UserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "DeptOrUser",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "Describe",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "InstNo",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Mall_Integral");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mall_Integral",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntergralDesc",
                table: "Mall_Integral",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral",
                column: "UserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
