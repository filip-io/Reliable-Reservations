using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ChangeReservationTimeSlotDeleteToCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 24, 28, 650, DateTimeKind.Utc).AddTicks(617));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8058));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8074));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 11, 14, 25, 14, 356, DateTimeKind.Utc).AddTicks(8082));
        }
    }
}
