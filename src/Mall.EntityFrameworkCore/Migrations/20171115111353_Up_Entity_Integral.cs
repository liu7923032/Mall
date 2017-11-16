using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Up_Entity_Integral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "DeptOrUser",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "InstNo",
                table: "Mall_Integral");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mall_Integral",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActDate",
                table: "Mall_Integral",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Mall_Integral",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral",
                column: "UserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "ActDate",
                table: "Mall_Integral");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Mall_Integral");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mall_Integral",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeptOrUser",
                table: "Mall_Integral",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InstNo",
                table: "Mall_Integral",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Integral_Mall_Account_UserId",
                table: "Mall_Integral",
                column: "UserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
