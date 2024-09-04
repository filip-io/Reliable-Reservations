using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reliable_Reservations.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "AvailabilityStatus", "Category", "Description", "LastUpdated", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "Appetizer", "Grilled bread topped with diced tomatoes, garlic, and basil.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4657), "Bruschetta", 6.99m },
                    { 2, true, "Appetizer", "Mushrooms stuffed with garlic, herbs, and cream cheese.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4659), "Stuffed Mushrooms", 7.99m },
                    { 3, true, "Starter", "Toasted bread slices with garlic butter.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4661), "Garlic Bread", 4.99m },
                    { 4, true, "Starter", "Creamy tomato soup with fresh basil.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4662), "Tomato Basil Soup", 5.99m },
                    { 5, true, "MainCourse", "Grilled salmon fillet served with lemon butter sauce.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4663), "Grilled Salmon", 15.99m },
                    { 6, true, "MainCourse", "Juicy grilled beef steak with a side of vegetables.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4664), "Beef Steak", 19.99m },
                    { 7, true, "Dessert", "Warm chocolate cake with a gooey molten center.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4665), "Chocolate Lava Cake", 6.99m },
                    { 8, true, "Dessert", "Classic Italian dessert with layers of mascarpone and espresso-soaked ladyfingers.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4666), "Tiramisu", 5.99m },
                    { 9, true, "Beverage", "Strong and rich espresso coffee.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4668), "Espresso", 2.99m },
                    { 10, true, "Beverage", "Refreshing homemade lemonade.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4669), "Lemonade", 3.99m },
                    { 11, true, "SideDish", "Crispy golden fries with a side of ketchup.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4670), "French Fries", 3.99m },
                    { 12, true, "SideDish", "Creamy mashed potatoes with butter and herbs.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4671), "Mashed Potatoes", 4.99m },
                    { 13, true, "Soup", "Hearty Italian soup with vegetables and pasta.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4673), "Minestrone Soup", 5.99m },
                    { 14, true, "Soup", "Classic chicken soup with noodles and vegetables.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4674), "Chicken Noodle Soup", 5.99m },
                    { 15, true, "Salad", "Salad with tomatoes, cucumbers, olives, and feta cheese.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4675), "Greek Salad", 6.99m },
                    { 16, true, "Salad", "Fresh tomatoes, mozzarella, and basil with balsamic glaze.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4676), "Caprese Salad", 7.99m },
                    { 17, true, "Special", "Succulent lobster tail served with drawn butter.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4677), "Lobster Tail", 29.99m },
                    { 18, true, "Special", "Creamy risotto with truffle oil and parmesan.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4678), "Truffle Risotto", 24.99m },
                    { 19, true, "Kids", "Crispy chicken nuggets served with fries.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4679), "Chicken Nuggets", 5.99m },
                    { 20, true, "Kids", "Creamy macaroni and cheese.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4680), "Mac and Cheese", 4.99m },
                    { 21, true, "Vegetarian", "Mixed vegetables stir-fried with soy sauce and served over rice.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4681), "Vegetable Stir-Fry", 9.99m },
                    { 22, true, "Vegetarian", "Lasagna layered with spinach, ricotta, and marinara sauce.", new DateTime(2024, 9, 1, 17, 28, 56, 515, DateTimeKind.Utc).AddTicks(4682), "Vegetarian Lasagna", 11.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "MenuItemId",
                keyValue: 22);
        }
    }
}
