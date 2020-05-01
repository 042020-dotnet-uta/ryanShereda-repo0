using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitsAndBobs.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomersDB",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustFirstName = table.Column<string>(nullable: true),
                    CustLastName = table.Column<string>(nullable: true),
                    CustUsername = table.Column<string>(nullable: true),
                    CustPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersDB", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDB",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDB", x => x.InventoryID);
                });

            migrationBuilder.CreateTable(
                name: "LocationsDB",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationAddress = table.Column<string>(nullable: true),
                    LocationState = table.Column<string>(nullable: true),
                    LocationCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsDB", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItemsDB",
                columns: table => new
                {
                    OrderLineItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    LinePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItemsDB", x => x.OrderLineItemID);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDB",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderTotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDB", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "ProductsDB",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDB", x => x.ProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersDB");

            migrationBuilder.DropTable(
                name: "InventoryDB");

            migrationBuilder.DropTable(
                name: "LocationsDB");

            migrationBuilder.DropTable(
                name: "OrderLineItemsDB");

            migrationBuilder.DropTable(
                name: "OrdersDB");

            migrationBuilder.DropTable(
                name: "ProductsDB");
        }
    }
}
