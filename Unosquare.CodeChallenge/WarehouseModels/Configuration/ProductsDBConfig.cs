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
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.Description).HasMaxLength(100);
            builder.Property(prop => prop.Price).IsRequired();

            builder.HasData(PopulateProducts());
        }

        protected List<Product> PopulateProducts()
        {
            var products = new List<Product>();

            Company Mattel = new Company() { Id = 1, Name = "Mattel" };
            Company Marvel = new Company() { Id = 2, Name = "Marvel" };
            Company Nintento = new Company() { Id = 3, Name = "Nintento" };
            Company Sony = new Company() { Id = 4, Name = "Sony" };
            Company Microsot = new Company() { Id = 5, Name = "Microsot" };

            //adding mattel product
            products.Add(new Product() {
                Id=1,
                CompanyId=Mattel.Id,
                Description= "Owen & Blue Jurassic World Dominion Extreme Damage",
                AgeRestriction=5,
                Name="Jurassic World Dominion Extreme Damage",
                Price = (decimal)619.40,
                ImageIurl= "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcThvns4l8crE59d-onYVPiLEtmaU0nrBCmkq081nXaQEwSGZZZd-7fX37uoC_yvMnewMadxheOl4lwTy7HPBbzLZMgLUTT-dtt1jy9EwoHYnBSoptPQpY7UlA",
                Storeid=3

            });
            products.Add(new Product()
            {
                Id = 2,
                CompanyId = Mattel.Id,
                Description = "Toy Story Buzz Vuelo Espacial",
                AgeRestriction = 2,
                Name = "Toy Story Buzz Vuelo Espacial",
                Price = (decimal)459.35,
                ImageIurl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqYWqWbYTWEuI-d5Y4RB8UrFldHMpdkCfoqmv7CJYijolQfcy-Vbo1af2-a8KAK-jkf6PRDICytGtQ3TSjjxLpMw3i-aje0NfwqiW69WaG4R2hzaMGkvx1JA",
                Storeid=5
            });
            products.Add(new Product()
            {
                Id = 3,
                CompanyId = Mattel.Id,
                Description = "Juguete Mattel Masters of the Universe Skelegod",
                AgeRestriction = 6,
                Name = "Juguete Mattel Masters of the Universe Skelegod",
                Price = (decimal)499.20,
                ImageIurl = "https://res.cloudinary.com/walmart-labs/image/upload/w_960,dpr_auto,f_auto,q_auto:best/mg/gm/1p/images/product-images/img_large/00088796197992l.jpg",
                Storeid = 1

            });
            products.Add(new Product()
            {
                Id = 4,
                CompanyId = Marvel.Id,
                Description = "FIGLot ZD Toys Marvel Iron Man Mark 3 Mark III Figura de acción de 7",
                AgeRestriction = 10,
                Name = "Iron Man Mark 3 Mark III Figura de acción Marvel",
                Price = (decimal)663.17,
                ImageIurl = "https://m.media-amazon.com/images/I/51AEF32Dz+L._AC_SX300_SY300_.jpg",
                Storeid = 4

            });
            products.Add(new Product()
            {
                Id = 5,
                CompanyId = Marvel.Id,
                Description = "Marvel Legends Spiderman Symbiote Marvel",
                AgeRestriction = 10,
                Name = "Spiderman Symbiote Marvel Legends ",
                Price = (decimal)599.00,
                ImageIurl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSKflghUkO7J_HIxgObXMQWXVQY8qQR9cR-8vKD8shg4QL3nqCoCD_1wOnHkIDOsaglMA1ClkjGfMtC8xJQ14LYqCDhDe7KqPa_cxZAFSDKTnFcbvqIEKgMWA",
                Storeid = 2

            });
            products.Add(new Product()
            {
                Id = 6,
                CompanyId = Marvel.Id,
                Description = "Thanos Avengers Endgame Hot Toys Marvel",
                AgeRestriction = 15,
                Name = "Thanos Avengers Endgame Hot Toys",
                Price = (decimal)1580.74,
                ImageIurl = "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSwN3z4us5tzBooLkPyU9McTRMpav6kbHBcDeW1kaePEhRrhd3eDlYtUqzaljLBct5l-iAYeWhdNN1jj02sXS3XmJCPwRjNLlDX-8yhdjXtKzpnUfKb1iOIgA",
                Storeid = 1

            });
            products.Add(new Product()
            {
                Id = 7,
                CompanyId = Nintento.Id,
                Description = "Nintendo NES Classic Mini Consola, color Gris - Classics Edition",
                AgeRestriction = 15,
                Name = "NES Classic Mini Consola Nintendo",
                Price = (decimal)4997.00,
                ImageIurl = "https://m.media-amazon.com/images/I/81s7B+Als-L._AC_SX679_.jpg",
                Storeid = 3

            });
            products.Add(new Product()
            {
                Id = 8,
                CompanyId = Nintento.Id,
                Description = "Nintendo Switch Lite -Turquesa",
                AgeRestriction = 15,
                Name = "Nintendo Switch Lite -Turquesa",
                Price = (decimal)5489.00,
                ImageIurl = "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSZUB1F7Ft-CQ2OpC7LyrPKg7GYYWfKulXAKDmIveVHsXbfdw-q6YycSDHDxiQjb1tXXckHkI3qraIaaHhuaVO-kaK1G8UOenP7AaqciGDa",
                Storeid = 3

            });
            products.Add(new Product()
            {
                Id = 9,
                CompanyId = Sony.Id,
                Description = "Control Inalámbrico Dualsense Cosmic Red - Playstation 5",
                AgeRestriction = 15,
                Name = "Playstation Control Inalámbrico Dualsense Cosmic Red",
                Price = (decimal)1390.00,
                ImageIurl = "https://m.media-amazon.com/images/I/71-2sMke9uS._AC_SX679_.jpg",
                Storeid = 1

            });
            products.Add(new Product()
            {
                Id = 10,
                CompanyId = Sony.Id,
                Description = "Bocina sony srs-xp500",
                AgeRestriction = 5,
                Name = "Bocina sony srs-xp500",
                Price = (decimal)7613.00,
                ImageIurl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRrEnuy_6KtpBKsl6dhdtt6xoh8MuwDL_amnqwy8kfXBW7d-v0Ndw7MTOzwQF0nAQCBDpUwzjdAqPMntZT-MzFjqM0eTQUGsX0FZvIyHgpbL28_mawQxasBCA",
                Storeid = 5

            });
            products.Add(new Product()
            {
                Id = 11,
                CompanyId = Microsot.Id,
                Description = "Mouse Microsoft Óptico Camo SE, Inalámbrico, Bluetooth 5.0, 1000DPI, Verde",
                AgeRestriction = 5,
                Name = "Mouse Microsoft Óptico Camo SE",
                Price = (decimal)375.00,
                ImageIurl = "https://www.cyberpuerta.mx/img/product/M/CP-MICROSOFT-8KX-00003-cb7e3a.jpg",
                Storeid = 3

            });
            products.Add(new Product()
            {
                Id = 12,
                CompanyId = Microsot.Id,
                Description = "Kit De Teclado Y Mouse Microsoft 1ai-00003",
                AgeRestriction = 5,
                Name = "Kit De Teclado Y Mouse Microsoft 1ai-00003",
                Price = (decimal)999.00,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQpd3HERKl-ka_ZdWXjM6kW0b2jGYe2VGlNol7dNvT4w2pZrqTs8cM5z_fc6Y-ZxHCiZjtqOWvOi4hUfmt3n72ekyaLdQ80oo4GXUyiD1gXn_XlfOfM1JNo",
                Storeid = 2

            });

            return products;
        }

    }
}
