using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseCoreLib.Migrations
{
    public partial class populatestockdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductsWarehouses",
                columns: new[] { "productId", "warehouseId", "stock" },
                values: new object[,]
                {
                    { 0, 1, 29 },
                    { 1, 1, 15 },
                    { 2, 1, 34 },
                    { 3, 1, 29 },
                    { 4, 1, 35 },
                    { 5, 1, 31 },
                    { 6, 1, 15 },
                    { 7, 1, 22 },
                    { 8, 2, 17 },
                    { 9, 1, 9 },
                    { 10, 2, 39 },
                    { 11, 1, 13 },
                    { 12, 1, 16 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 0, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsWarehouses",
                keyColumns: new[] { "productId", "warehouseId" },
                keyValues: new object[] { 12, 1 });
        }
    }
}
