using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseModels.Configuration
{
    public class ProductsDBConfig : IEntityTypeConfiguration<Product>,IConfigurationDB
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prop => prop.name).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.description).HasMaxLength(100);
            builder.Property(prop => prop.price).IsRequired();

            builder.HasData(populateProducts());
        }

        protected List<Product> populateProducts()
        {
            var products = new List<Product>();

            Company Mattel = new Company() { Id = 1, Name = "Mattel" };
            Company Marvel = new Company() { Id = 2, Name = "Marvel" };
            Company Nintento = new Company() { Id = 3, Name = "Nintento" };
            Company Sony = new Company() { Id = 4, Name = "Sony" };
            Company Microsot = new Company() { Id = 5, Name = "Microsot" };

            //adding mattel product
            products.Add(new Product() {
                id=1,
                companyId=Mattel.Id,
                description= "Owen & Blue Jurassic World Dominion Extreme Damage",
                ageRestriction=5,
                name="Jurassic World Dominion Extreme Damage",
                price = (decimal)619.40,
                imageIurl= "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcThvns4l8crE59d-onYVPiLEtmaU0nrBCmkq081nXaQEwSGZZZd-7fX37uoC_yvMnewMadxheOl4lwTy7HPBbzLZMgLUTT-dtt1jy9EwoHYnBSoptPQpY7UlA",
                storeid=3

            });
            products.Add(new Product()
            {
                id = 2,
                companyId = Mattel.Id,
                description = "Toy Story Buzz Vuelo Espacial",
                ageRestriction = 2,
                name = "Toy Story Buzz Vuelo Espacial",
                price = (decimal)459.35,
                imageIurl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqYWqWbYTWEuI-d5Y4RB8UrFldHMpdkCfoqmv7CJYijolQfcy-Vbo1af2-a8KAK-jkf6PRDICytGtQ3TSjjxLpMw3i-aje0NfwqiW69WaG4R2hzaMGkvx1JA",
                storeid=5
            });
            products.Add(new Product()
            {
                id = 3,
                companyId = Mattel.Id,
                description = "Juguete Mattel Masters of the Universe Skelegod",
                ageRestriction = 6,
                name = "Juguete Mattel Masters of the Universe Skelegod",
                price = (decimal)499.20,
                imageIurl = "https://res.cloudinary.com/walmart-labs/image/upload/w_960,dpr_auto,f_auto,q_auto:best/mg/gm/1p/images/product-images/img_large/00088796197992l.jpg",
                storeid = 1

            });
            products.Add(new Product()
            {
                id = 4,
                companyId = Marvel.Id,
                description = "FIGLot ZD Toys Marvel Iron Man Mark 3 Mark III Figura de acción de 7",
                ageRestriction = 10,
                name = "Iron Man Mark 3 Mark III Figura de acción Marvel",
                price = (decimal)663.17,
                imageIurl = "https://m.media-amazon.com/images/I/51AEF32Dz+L._AC_SX300_SY300_.jpg",
                storeid = 4

            });
            products.Add(new Product()
            {
                id = 5,
                companyId = Marvel.Id,
                description = "Marvel Legends Spiderman Symbiote Marvel",
                ageRestriction = 10,
                name = "Spiderman Symbiote Marvel Legends ",
                price = (decimal)599.00,
                imageIurl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSKflghUkO7J_HIxgObXMQWXVQY8qQR9cR-8vKD8shg4QL3nqCoCD_1wOnHkIDOsaglMA1ClkjGfMtC8xJQ14LYqCDhDe7KqPa_cxZAFSDKTnFcbvqIEKgMWA",
                storeid = 2

            });
            products.Add(new Product()
            {
                id = 6,
                companyId = Marvel.Id,
                description = "Thanos Avengers Endgame Hot Toys Marvel",
                ageRestriction = 15,
                name = "Thanos Avengers Endgame Hot Toys",
                price = (decimal)1580.74,
                imageIurl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSwN3z4us5tzBooLkPyU9McTRMpav6kbHBcDeW1kaePEhRrhd3eDlYtUqzaljLBct5l-iAYeWhdNN1jj02sXS3XmJCPwRjNLlDX-8yhdjXtKzpnUfKb1iOIgA",
                storeid = 1

            });
            products.Add(new Product()
            {
                id = 7,
                companyId = Nintento.Id,
                description = "Nintendo NES Classic Mini Consola, color Gris - Classics Edition",
                ageRestriction = 15,
                name = "NES Classic Mini Consola Nintendo",
                price = (decimal)4997.00,
                imageIurl = "https://m.media-amazon.com/images/I/81s7B+Als-L._AC_SX679_.jpg",
                storeid = 3

            });
            products.Add(new Product()
            {
                id = 8,
                companyId = Nintento.Id,
                description = "Nintendo Switch Lite -Turquesa",
                ageRestriction = 15,
                name = "Nintendo Switch Lite -Turquesa",
                price = (decimal)5489.00,
                imageIurl = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSZUB1F7Ft-CQ2OpC7LyrPKg7GYYWfKulXAKDmIveVHsXbfdw-q6YycSDHDxiQjb1tXXckHkI3qraIaaHhuaVO-kaK1G8UOenP7AaqciGDa",
                storeid = 3

            });
            products.Add(new Product()
            {
                id = 9,
                companyId = Sony.Id,
                description = "Control Inalámbrico Dualsense Cosmic Red - Playstation 5",
                ageRestriction = 15,
                name = "Playstation Control Inalámbrico Dualsense Cosmic Red",
                price = (decimal)1390.00,
                imageIurl = "https://m.media-amazon.com/images/I/71-2sMke9uS._AC_SX679_.jpg",
                storeid = 1

            });
            products.Add(new Product()
            {
                id = 10,
                companyId = Sony.Id,
                description = "Bocina sony srs-xp500",
                ageRestriction = 5,
                name = "Bocina sony srs-xp500",
                price = (decimal)7613.00,
                imageIurl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRrEnuy_6KtpBKsl6dhdtt6xoh8MuwDL_amnqwy8kfXBW7d-v0Ndw7MTOzwQF0nAQCBDpUwzjdAqPMntZT-MzFjqM0eTQUGsX0FZvIyHgpbL28_mawQxasBCA",
                storeid = 5

            });
            products.Add(new Product()
            {
                id = 11,
                companyId = Microsot.Id,
                description = "Mouse Microsoft Óptico Camo SE, Inalámbrico, Bluetooth 5.0, 1000DPI, Verde",
                ageRestriction = 5,
                name = "Mouse Microsoft Óptico Camo SE",
                price = (decimal)375.00,
                imageIurl = "https://www.cyberpuerta.mx/img/product/M/CP-MICROSOFT-8KX-00003-cb7e3a.jpg",
                storeid = 3

            });
            products.Add(new Product()
            {
                id = 12,
                companyId = Microsot.Id,
                description = "Kit De Teclado Y Mouse Microsoft 1ai-00003",
                ageRestriction = 5,
                name = "Kit De Teclado Y Mouse Microsoft 1ai-00003",
                price = (decimal)999.00,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQpd3HERKl-ka_ZdWXjM6kW0b2jGYe2VGlNol7dNvT4w2pZrqTs8cM5z_fc6Y-ZxHCiZjtqOWvOi4hUfmt3n72ekyaLdQ80oo4GXUyiD1gXn_XlfOfM1JNo",
                storeid = 2

            });

            return products;
        }

    }
}
