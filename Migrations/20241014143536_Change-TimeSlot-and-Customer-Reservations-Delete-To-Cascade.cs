using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTimeSlotandCustomerReservationsDeleteToCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Reservations_ReservationId",
                table: "TimeSlots");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3803));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 14, 14, 35, 36, 590, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Reservations_ReservationId",
                table: "TimeSlots",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Reservations_ReservationId",
                table: "TimeSlots");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Reservations_ReservationId",
                table: "TimeSlots",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
