using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseCoreLib.Migrations
{
    public partial class cleanMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyId = table.Column<int>(type: "int", nullable: false),
                    ageRestriction = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    imageIurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "ageRestriction", "companyId", "description", "imageIurl", "name", "price" },
                values: new object[,]
                {
                    { 1, 5, 1, "Owen & Blue Jurassic World Dominion Extreme Damage", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcThvns4l8crE59d-onYVPiLEtmaU0nrBCmkq081nXaQEwSGZZZd-7fX37uoC_yvMnewMadxheOl4lwTy7HPBbzLZMgLUTT-dtt1jy9EwoHYnBSoptPQpY7UlA", "Jurassic World Dominion Extreme Damage", 619.4m },
                    { 2, 2, 1, "Toy Story Buzz Vuelo Espacial", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqYWqWbYTWEuI-d5Y4RB8UrFldHMpdkCfoqmv7CJYijolQfcy-Vbo1af2-a8KAK-jkf6PRDICytGtQ3TSjjxLpMw3i-aje0NfwqiW69WaG4R2hzaMGkvx1JA", "Toy Story Buzz Vuelo Espacial", 459.35m },
                    { 3, 6, 1, "Juguete Mattel Masters of the Universe Skelegod", "https://res.cloudinary.com/walmart-labs/image/upload/w_960,dpr_auto,f_auto,q_auto:best/mg/gm/1p/images/product-images/img_large/00088796197992l.jpg", "Juguete Mattel Masters of the Universe Skelegod", 499.2m },
                    { 4, 10, 2, "FIGLot ZD Toys Marvel Iron Man Mark 3 Mark III Figura de acción de 7", "https://m.media-amazon.com/images/I/51AEF32Dz+L._AC_SX300_SY300_.jpg", "Iron Man Mark 3 Mark III Figura de acción", 663.17m },
                    { 5, 10, 2, "Marvel Legends Spiderman Symbiote", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSKflghUkO7J_HIxgObXMQWXVQY8qQR9cR-8vKD8shg4QL3nqCoCD_1wOnHkIDOsaglMA1ClkjGfMtC8xJQ14LYqCDhDe7KqPa_cxZAFSDKTnFcbvqIEKgMWA", "Spiderman Symbiote Marvel Legends ", 599m },
                    { 6, 15, 2, "Thanos Avengers Endgame Hot Toys", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSwN3z4us5tzBooLkPyU9McTRMpav6kbHBcDeW1kaePEhRrhd3eDlYtUqzaljLBct5l-iAYeWhdNN1jj02sXS3XmJCPwRjNLlDX-8yhdjXtKzpnUfKb1iOIgA", "Thanos Avengers Endgame Hot Toys", 1580.74m },
                    { 7, 15, 3, "Nintendo NES Classic Mini Consola, color Gris - Classics Edition", "https://m.media-amazon.com/images/I/81s7B+Als-L._AC_SX679_.jpg", "NES Classic Mini Consola", 4997m },
                    { 8, 15, 3, "Nintendo Switch Lite -Turquesa", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSZUB1F7Ft-CQ2OpC7LyrPKg7GYYWfKulXAKDmIveVHsXbfdw-q6YycSDHDxiQjb1tXXckHkI3qraIaaHhuaVO-kaK1G8UOenP7AaqciGDa", "Nintendo Switch Lite -Turquesa", 5489m },
                    { 9, 15, 4, "Control Inalámbrico Dualsense Cosmic Red - Playstation 5", "https://m.media-amazon.com/images/I/71-2sMke9uS._AC_SX679_.jpg", "Control Inalámbrico Dualsense Cosmic Red ", 1390m },
                    { 10, 5, 4, "Bocina sony srs-xp500", "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRrEnuy_6KtpBKsl6dhdtt6xoh8MuwDL_amnqwy8kfXBW7d-v0Ndw7MTOzwQF0nAQCBDpUwzjdAqPMntZT-MzFjqM0eTQUGsX0FZvIyHgpbL28_mawQxasBCA", "Bocina sony srs-xp500", 7613m },
                    { 11, 5, 5, "Mouse Microsoft Óptico Camo SE, Inalámbrico, Bluetooth 5.0, 1000DPI, Verde", "https://www.cyberpuerta.mx/img/product/M/CP-MICROSOFT-8KX-00003-cb7e3a.jpg", "Mouse Microsoft Óptico Camo SE", 375m },
                    { 12, 5, 5, "Kit De Teclado Y Mouse Microsoft 1ai-00003", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQpd3HERKl-ka_ZdWXjM6kW0b2jGYe2VGlNol7dNvT4w2pZrqTs8cM5z_fc6Y-ZxHCiZjtqOWvOi4hUfmt3n72ekyaLdQ80oo4GXUyiD1gXn_XlfOfM1JNo", "Kit De Teclado Y Mouse Microsoft 1ai-00003", 999m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_companyId",
                table: "Products",
                column: "companyId");
        }
    }
}
