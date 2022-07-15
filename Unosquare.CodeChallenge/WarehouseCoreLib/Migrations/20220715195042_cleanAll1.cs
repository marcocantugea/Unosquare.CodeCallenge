using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseCoreLib.Migrations
{
    public partial class cleanAll1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Stores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    storeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wharehouses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wharehouses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    storeid = table.Column<int>(type: "int", nullable: false),
                    ageRestriction = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    imageIurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Stores_storeid",
                        column: x => x.storeid,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mattel" },
                    { 2, "Marvel" },
                    { 3, "Nintento" },
                    { 4, "Sony" },
                    { 5, "Microsot" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "address", "city", "storeName" },
                values: new object[,]
                {
                    { 1, "Plaza Galerias,Avenida Insurgentes 2500, Galerias Monterrey, Monterrey", "Monterrey, NL", "Galerias Monterrey" },
                    { 2, "9 sur 11302,Sobre Periférico Ecológico", "Puebla, Puebla", "Periplaza" },
                    { 3, "Avenida Francisco Medina Ascencio 2920, Puerto Vallarta", "Puerto Vallarta, Jal.", "Galerias Puerto Vallarta" },
                    { 4, "Libramiento Monterrey", "Reynosa, Tamaulipas", "Plaza Periferico" },
                    { 5, "Avenida Lázaro Cárdenas Sn", "Xalapa, Veracruz", "Plaza Cristal" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "ageRestriction", "companyId", "description", "imageIurl", "name", "price", "storeid" },
                values: new object[,]
                {
                    { 1, 5, 1, "Owen & Blue Jurassic World Dominion Extreme Damage", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcThvns4l8crE59d-onYVPiLEtmaU0nrBCmkq081nXaQEwSGZZZd-7fX37uoC_yvMnewMadxheOl4lwTy7HPBbzLZMgLUTT-dtt1jy9EwoHYnBSoptPQpY7UlA", "Jurassic World Dominion Extreme Damage", 619.4m, 3 },
                    { 2, 2, 1, "Toy Story Buzz Vuelo Espacial", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqYWqWbYTWEuI-d5Y4RB8UrFldHMpdkCfoqmv7CJYijolQfcy-Vbo1af2-a8KAK-jkf6PRDICytGtQ3TSjjxLpMw3i-aje0NfwqiW69WaG4R2hzaMGkvx1JA", "Toy Story Buzz Vuelo Espacial", 459.35m, 5 },
                    { 3, 6, 1, "Juguete Mattel Masters of the Universe Skelegod", "https://res.cloudinary.com/walmart-labs/image/upload/w_960,dpr_auto,f_auto,q_auto:best/mg/gm/1p/images/product-images/img_large/00088796197992l.jpg", "Juguete Mattel Masters of the Universe Skelegod", 499.2m, 1 },
                    { 4, 10, 2, "FIGLot ZD Toys Marvel Iron Man Mark 3 Mark III Figura de acción de 7", "https://m.media-amazon.com/images/I/51AEF32Dz+L._AC_SX300_SY300_.jpg", "Iron Man Mark 3 Mark III Figura de acción", 663.17m, 4 },
                    { 5, 10, 2, "Marvel Legends Spiderman Symbiote", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSKflghUkO7J_HIxgObXMQWXVQY8qQR9cR-8vKD8shg4QL3nqCoCD_1wOnHkIDOsaglMA1ClkjGfMtC8xJQ14LYqCDhDe7KqPa_cxZAFSDKTnFcbvqIEKgMWA", "Spiderman Symbiote Marvel Legends ", 599m, 2 },
                    { 6, 15, 2, "Thanos Avengers Endgame Hot Toys", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSwN3z4us5tzBooLkPyU9McTRMpav6kbHBcDeW1kaePEhRrhd3eDlYtUqzaljLBct5l-iAYeWhdNN1jj02sXS3XmJCPwRjNLlDX-8yhdjXtKzpnUfKb1iOIgA", "Thanos Avengers Endgame Hot Toys", 1580.74m, 1 },
                    { 7, 15, 3, "Nintendo NES Classic Mini Consola, color Gris - Classics Edition", "https://m.media-amazon.com/images/I/81s7B+Als-L._AC_SX679_.jpg", "NES Classic Mini Consola", 4997m, 3 },
                    { 8, 15, 3, "Nintendo Switch Lite -Turquesa", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSZUB1F7Ft-CQ2OpC7LyrPKg7GYYWfKulXAKDmIveVHsXbfdw-q6YycSDHDxiQjb1tXXckHkI3qraIaaHhuaVO-kaK1G8UOenP7AaqciGDa", "Nintendo Switch Lite -Turquesa", 5489m, 3 },
                    { 9, 15, 4, "Control Inalámbrico Dualsense Cosmic Red - Playstation 5", "https://m.media-amazon.com/images/I/71-2sMke9uS._AC_SX679_.jpg", "Control Inalámbrico Dualsense Cosmic Red ", 1390m, 1 },
                    { 10, 5, 4, "Bocina sony srs-xp500", "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRrEnuy_6KtpBKsl6dhdtt6xoh8MuwDL_amnqwy8kfXBW7d-v0Ndw7MTOzwQF0nAQCBDpUwzjdAqPMntZT-MzFjqM0eTQUGsX0FZvIyHgpbL28_mawQxasBCA", "Bocina sony srs-xp500", 7613m, 5 },
                    { 11, 5, 5, "Mouse Microsoft Óptico Camo SE, Inalámbrico, Bluetooth 5.0, 1000DPI, Verde", "https://www.cyberpuerta.mx/img/product/M/CP-MICROSOFT-8KX-00003-cb7e3a.jpg", "Mouse Microsoft Óptico Camo SE", 375m, 3 },
                    { 12, 5, 5, "Kit De Teclado Y Mouse Microsoft 1ai-00003", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQpd3HERKl-ka_ZdWXjM6kW0b2jGYe2VGlNol7dNvT4w2pZrqTs8cM5z_fc6Y-ZxHCiZjtqOWvOi4hUfmt3n72ekyaLdQ80oo4GXUyiD1gXn_XlfOfM1JNo", "Kit De Teclado Y Mouse Microsoft 1ai-00003", 999m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_companyId",
                table: "Products",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_storeid",
                table: "Products",
                column: "storeid");
        }
    }
}
