using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvailabilityStatus = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "OpeningHours",
                columns: table => new
                {
                    OpeningHoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    CloseTime = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningHours", x => x.OpeningHoursId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOpeningHours",
                columns: table => new
                {
                    SpecialOpeningHoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "time(0)", nullable: true),
                    CloseTime = table.Column<TimeOnly>(type: "time(0)", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    OpeningHoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOpeningHours", x => x.SpecialOpeningHoursId);
                    table.ForeignKey(
                        name: "FK_SpecialOpeningHours_OpeningHours_OpeningHoursId",
                        column: x => x.OpeningHoursId,
                        principalTable: "OpeningHours",
                        principalColumn: "OpeningHoursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningHoursId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotId);
                    table.ForeignKey(
                        name: "FK_TimeSlots_OpeningHours_OpeningHoursId",
                        column: x => x.OpeningHoursId,
                        principalTable: "OpeningHours",
                        principalColumn: "OpeningHoursId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlots_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SpecialRequests = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTables",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTables", x => new { x.ReservationId, x.TableId });
                    table.ForeignKey(
                        name: "FK_ReservationTables_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationTables_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "AvailabilityStatus", "Category", "Description", "LastUpdated", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "Appetizer", "Grilled bread topped with diced tomatoes, garlic, and basil.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8394), "Bruschetta", 6.99m },
                    { 2, true, "Appetizer", "Mushrooms stuffed with garlic, herbs, and cream cheese.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8397), "Stuffed Mushrooms", 7.99m },
                    { 3, true, "Starter", "Toasted bread slices with garlic butter.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8398), "Garlic Bread", 4.99m },
                    { 4, true, "Starter", "Creamy tomato soup with fresh basil.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8399), "Tomato Basil Soup", 5.99m },
                    { 5, true, "MainCourse", "Grilled salmon fillet served with lemon butter sauce.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8400), "Grilled Salmon", 15.99m },
                    { 6, true, "MainCourse", "Juicy grilled beef steak with a side of vegetables.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8401), "Beef Steak", 19.99m },
                    { 7, true, "Dessert", "Warm chocolate cake with a gooey molten center.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8402), "Chocolate Lava Cake", 6.99m },
                    { 8, true, "Dessert", "Classic Italian dessert with layers of mascarpone and espresso-soaked ladyfingers.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8403), "Tiramisu", 5.99m },
                    { 9, true, "Beverage", "Strong and rich espresso coffee.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8405), "Espresso", 2.99m },
                    { 10, true, "Beverage", "Refreshing homemade lemonade.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8406), "Lemonade", 3.99m },
                    { 11, true, "SideDish", "Crispy golden fries with a side of ketchup.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8407), "French Fries", 3.99m },
                    { 12, true, "SideDish", "Creamy mashed potatoes with butter and herbs.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8409), "Mashed Potatoes", 4.99m },
                    { 13, true, "Soup", "Hearty Italian soup with vegetables and pasta.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8410), "Minestrone Soup", 5.99m },
                    { 14, true, "Soup", "Classic chicken soup with noodles and vegetables.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8411), "Chicken Noodle Soup", 5.99m },
                    { 15, true, "Salad", "Salad with tomatoes, cucumbers, olives, and feta cheese.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8412), "Greek Salad", 6.99m },
                    { 16, true, "Salad", "Fresh tomatoes, mozzarella, and basil with balsamic glaze.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8413), "Caprese Salad", 7.99m },
                    { 17, true, "Special", "Succulent lobster tail served with drawn butter.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8414), "Lobster Tail", 29.99m },
                    { 18, true, "Special", "Creamy risotto with truffle oil and parmesan.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8415), "Truffle Risotto", 24.99m },
                    { 19, true, "Kids", "Crispy chicken nuggets served with fries.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8416), "Chicken Nuggets", 5.99m },
                    { 20, true, "Kids", "Creamy macaroni and cheese.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8417), "Mac and Cheese", 4.99m },
                    { 21, true, "Vegetarian", "Mixed vegetables stir-fried with soy sauce and served over rice.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8418), "Vegetable Stir-Fry", 9.99m },
                    { 22, true, "Vegetarian", "Lasagna layered with spinach, ricotta, and marinara sauce.", new DateTime(2024, 9, 8, 0, 19, 11, 925, DateTimeKind.Utc).AddTicks(8419), "Vegetarian Lasagna", 11.99m }
                });

            migrationBuilder.InsertData(
                table: "OpeningHours",
                columns: new[] { "OpeningHoursId", "CloseTime", "DayOfWeek", "IsClosed", "OpenTime" },
                values: new object[,]
                {
                    { 1, new TimeOnly(23, 0, 0), 0, false, new TimeOnly(10, 0, 0) },
                    { 2, new TimeOnly(23, 0, 0), 1, true, new TimeOnly(10, 0, 0) },
                    { 3, new TimeOnly(23, 0, 0), 2, true, new TimeOnly(10, 0, 0) },
                    { 4, new TimeOnly(23, 0, 0), 3, false, new TimeOnly(10, 0, 0) },
                    { 5, new TimeOnly(23, 0, 0), 4, false, new TimeOnly(10, 0, 0) },
                    { 6, new TimeOnly(23, 0, 0), 5, false, new TimeOnly(10, 0, 0) },
                    { 7, new TimeOnly(23, 0, 0), 6, false, new TimeOnly(10, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Location", "SeatingCapacity", "TableNumber" },
                values: new object[,]
                {
                    { 1, "Window", 4, 1 },
                    { 2, "Patio", 2, 2 },
                    { 3, "Center", 6, 3 },
                    { 4, "Corner", 4, 4 },
                    { 5, "Center", 4, 5 },
                    { 6, "Window", 2, 6 },
                    { 7, "Private Room", 8, 7 },
                    { 8, "Patio", 6, 8 },
                    { 9, "Corner", 4, 9 },
                    { 10, "Window", 4, 10 },
                    { 11, "Bar", 2, 11 },
                    { 12, "Center", 6, 12 },
                    { 13, "Private Room", 8, 13 },
                    { 14, "Patio", 2, 14 },
                    { 15, "Window", 4, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTables_TableId",
                table: "ReservationTables",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOpeningHours_OpeningHoursId",
                table: "SpecialOpeningHours",
                column: "OpeningHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TableNumber",
                table: "Tables",
                column: "TableNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_OpeningHoursId",
                table: "TimeSlots",
                column: "OpeningHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_TableId",
                table: "TimeSlots",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "ReservationTables");

            migrationBuilder.DropTable(
                name: "SpecialOpeningHours");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "OpeningHours");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
