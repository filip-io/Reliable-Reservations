using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOpeningHoursTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenTime",
                table: "OpeningHours",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseTime",
                table: "OpeningHours",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "OpenTime",
                table: "OpeningHours",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CloseTime",
                table: "OpeningHours",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");
        }
    }
}
