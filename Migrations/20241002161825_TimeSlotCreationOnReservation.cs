using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlotCreationOnReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TimeSlotId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9239));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 2, 16, 18, 25, 470, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_ReservationId",
                table: "TimeSlots",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Reservations_ReservationId",
                table: "TimeSlots",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Reservations_ReservationId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_ReservationId",
                table: "TimeSlots");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TimeSlots_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "TimeSlotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
