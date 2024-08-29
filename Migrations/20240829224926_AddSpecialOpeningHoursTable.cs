using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialOpeningHoursTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialCloseTime",
                table: "OpeningHours");

            migrationBuilder.DropColumn(
                name: "SpecialDate",
                table: "OpeningHours");

            migrationBuilder.DropColumn(
                name: "SpecialOpenTime",
                table: "OpeningHours");

            migrationBuilder.CreateTable(
                name: "SpecialOpeningHours",
                columns: table => new
                {
                    SpecialOpeningHoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    OpenTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    CloseTime = table.Column<TimeOnly>(type: "time", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOpeningHours_OpeningHoursId",
                table: "SpecialOpeningHours",
                column: "OpeningHoursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialOpeningHours");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SpecialCloseTime",
                table: "OpeningHours",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SpecialDate",
                table: "OpeningHours",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SpecialOpenTime",
                table: "OpeningHours",
                type: "time",
                nullable: true);
        }
    }
}
