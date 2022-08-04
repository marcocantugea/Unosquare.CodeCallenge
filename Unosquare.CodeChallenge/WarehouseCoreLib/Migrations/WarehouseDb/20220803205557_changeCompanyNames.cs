using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseCoreLib.Migrations.WarehouseDb
{
    public partial class changeCompanyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Companies",
                newName: "id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Companies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Companies",
                newName: "Id");

        }
    }
}
