using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeSlots",
                type: "datetime2(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeSlots",
                type: "datetime2(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenTime",
                table: "SpecialOpeningHours",
                type: "time(0)",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseTime",
                table: "SpecialOpeningHours",
                type: "time(0)",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservations",
                type: "datetime2(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeSlots",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeSlots",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenTime",
                table: "SpecialOpeningHours",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseTime",
                table: "SpecialOpeningHours",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)");
        }
    }
}
