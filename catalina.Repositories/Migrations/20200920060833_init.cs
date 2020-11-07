using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace catalina.Repositories.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PasswordEncrypt = table.Column<string>(nullable: true),
                    ShippingCountry = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    OrderStatusString = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    ItemValue = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    ShippingCharge = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    HandlingFee = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    OrderMetaData = table.Column<string>(nullable: true),
                    CreatedOnUTC = table.Column<DateTime>(nullable: false),
                    UpdatedOnUTC = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
