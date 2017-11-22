using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Mall.Migrations
{
    public partial class Add_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressInfo",
                table: "Mall_Order",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Mall_Integral",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Mall_Account",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Mall_Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AliasName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DetailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Provice = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RecUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mall_Address_Mall_Account_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Mall_Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mall_OrderRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mall_OrderRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mall_OrderRecord_Mall_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Mall_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mall_Order_CreatorUserId",
                table: "Mall_Order",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mall_Address_CreatorUserId",
                table: "Mall_Address",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mall_OrderRecord_OrderId",
                table: "Mall_OrderRecord",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mall_Order_Mall_Account_CreatorUserId",
                table: "Mall_Order",
                column: "CreatorUserId",
                principalTable: "Mall_Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mall_Order_Mall_Account_CreatorUserId",
                table: "Mall_Order");

            migrationBuilder.DropTable(
                name: "Mall_Address");

            migrationBuilder.DropTable(
                name: "Mall_OrderRecord");

            migrationBuilder.DropIndex(
                name: "IX_Mall_Order_CreatorUserId",
                table: "Mall_Order");

            migrationBuilder.DropColumn(
                name: "AddressInfo",
                table: "Mall_Order");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Mall_Integral",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Mall_Account",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
