using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitsAndBobs.Migrations
{
    public partial class ThirdNormalRefactor : Migration
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
                name: "LocationCountry",
                columns: table => new
                {
                    LocationCountryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCountry", x => x.LocationCountryID);
                });

            migrationBuilder.CreateTable(
                name: "LocationState",
                columns: table => new
                {
                    LocationStateID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationState", x => x.LocationStateID);
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

            migrationBuilder.CreateTable(
                name: "LocationsDB",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationAddress = table.Column<string>(nullable: true),
                    LocationStateID = table.Column<int>(nullable: true),
                    LocationCountryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsDB", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_LocationsDB_LocationCountry_LocationCountryID",
                        column: x => x.LocationCountryID,
                        principalTable: "LocationCountry",
                        principalColumn: "LocationCountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationsDB_LocationState_LocationStateID",
                        column: x => x.LocationStateID,
                        principalTable: "LocationState",
                        principalColumn: "LocationStateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventoryDB",
                columns: table => new
                {
                    InventoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InventoryLocationLocationID = table.Column<int>(nullable: true),
                    InventoryProductProductID = table.Column<int>(nullable: true),
                    QuantityAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDB", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_InventoryDB_LocationsDB_InventoryLocationLocationID",
                        column: x => x.InventoryLocationLocationID,
                        principalTable: "LocationsDB",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryDB_ProductsDB_InventoryProductProductID",
                        column: x => x.InventoryProductProductID,
                        principalTable: "ProductsDB",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDB",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderCustomerCustomerID = table.Column<int>(nullable: true),
                    OrderLocationLocationID = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDB", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_OrdersDB_CustomersDB_OrderCustomerCustomerID",
                        column: x => x.OrderCustomerCustomerID,
                        principalTable: "CustomersDB",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdersDB_LocationsDB_OrderLocationLocationID",
                        column: x => x.OrderLocationLocationID,
                        principalTable: "LocationsDB",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItemsDB",
                columns: table => new
                {
                    OrderLineItemID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LineItemOrderOrderID = table.Column<int>(nullable: true),
                    LineItemProductProductID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    LinePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItemsDB", x => x.OrderLineItemID);
                    table.ForeignKey(
                        name: "FK_OrderLineItemsDB_OrdersDB_LineItemOrderOrderID",
                        column: x => x.LineItemOrderOrderID,
                        principalTable: "OrdersDB",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLineItemsDB_ProductsDB_LineItemProductProductID",
                        column: x => x.LineItemProductProductID,
                        principalTable: "ProductsDB",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDB_InventoryLocationLocationID",
                table: "InventoryDB",
                column: "InventoryLocationLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDB_InventoryProductProductID",
                table: "InventoryDB",
                column: "InventoryProductProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationsDB_LocationCountryID",
                table: "LocationsDB",
                column: "LocationCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationsDB_LocationStateID",
                table: "LocationsDB",
                column: "LocationStateID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItemsDB_LineItemOrderOrderID",
                table: "OrderLineItemsDB",
                column: "LineItemOrderOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItemsDB_LineItemProductProductID",
                table: "OrderLineItemsDB",
                column: "LineItemProductProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDB_OrderCustomerCustomerID",
                table: "OrdersDB",
                column: "OrderCustomerCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDB_OrderLocationLocationID",
                table: "OrdersDB",
                column: "OrderLocationLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDB");

            migrationBuilder.DropTable(
                name: "OrderLineItemsDB");

            migrationBuilder.DropTable(
                name: "OrdersDB");

            migrationBuilder.DropTable(
                name: "ProductsDB");

            migrationBuilder.DropTable(
                name: "CustomersDB");

            migrationBuilder.DropTable(
                name: "LocationsDB");

            migrationBuilder.DropTable(
                name: "LocationCountry");

            migrationBuilder.DropTable(
                name: "LocationState");
        }
    }
}
