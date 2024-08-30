using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForOpeningHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "OpeningHoursId",
                keyValue: 7);
        }
    }
}
