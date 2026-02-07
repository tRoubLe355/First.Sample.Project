using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Natura.Data.Migrations
{
    /// <inheritdoc />
    public partial class TurkishContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(654), "Taze organik sebzeler", "Sebzeler" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(656), "Taze organik meyveler", "Meyveler" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(658), "Mutfak ürünleri", "Mutfak" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(660), "Taze baharatlar ve otlar", "Baharatlar" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(802), "Premium organik avokadolar", "Organik Avokado", 89.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "Price", "Unit" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(805), "Saf köy balı", "Doğal Bal", 249.99m, "kavanoz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(808), "Taze köy domatesi", "Köy Domatesi", 45.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name", "Price", "Unit" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(810), "Aromatik taze fesleğen", "Taze Fesleğen", 25.00m, "demet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(813), "Taze organik elmalar", "Organik Elma", 35.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 16, 11, 36, 372, DateTimeKind.Utc).AddTicks(815), "Sulu organik portakallar", "Organik Portakal", 42.50m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5830), "Fresh organic vegetables", "Vegetables" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5831), "Fresh organic fruits", "Fruits" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5833), "Pantry essentials", "Pantry" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5834), "Fresh herbs and spices", "Herbs" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5941), "Premium organic avocados", "Organic Avocados", 5.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "Price", "Unit" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5944), "Pure artisan honey", "Artisan Honey", 12.50m, "jar" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5946), "Heirloom tomatoes", "Heritage Tomatoes", 4.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Name", "Price", "Unit" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5948), "Aromatic fresh basil", "Fresh Basil Bundle", 3.00m, "bundle" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5950), "Fresh organic apples", "Organic Apples", 3.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Name", "Price" },
                values: new object[] { new DateTime(2026, 1, 25, 15, 12, 3, 147, DateTimeKind.Utc).AddTicks(5952), "Juicy organic oranges", "Organic Oranges", 4.25m });
        }
    }
}
