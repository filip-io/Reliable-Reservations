using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ReduceTableCountToFive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3648));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3652));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3654));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3658));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3660));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3661));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 10, 10, 53, 255, DateTimeKind.Utc).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3,
                column: "Location",
                value: "Corner");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4,
                column: "Location",
                value: "Outside");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5,
                column: "Location",
                value: "Outside");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1917));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1936));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 24, 11, 55, 9, 642, DateTimeKind.Utc).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3,
                column: "Location",
                value: "Center");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4,
                column: "Location",
                value: "Corner");

            migrationBuilder.UpdateData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5,
                column: "Location",
                value: "Center");

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Location", "SeatingCapacity", "TableNumber" },
                values: new object[,]
                {
                    { 6, "Window", 2, 6 },
                    { 7, "Private Room", 8, 7 },
                    { 8, "Patio", 6, 8 },
                    { 9, "Corner", 4, 9 },
                    { 10, "Window", 4, 10 }
                });
        }
    }
}
