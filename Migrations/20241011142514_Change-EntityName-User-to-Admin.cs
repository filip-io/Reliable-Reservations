using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntityNameUsertoAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

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
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }
    }
}
