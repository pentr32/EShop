using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public EShopContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = eShopDb; Trusted_Connection = True;")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new ServiceCollection()
                .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ************************ Fluent API ***************************

            modelBuilder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(f => f.CustomerID);

            modelBuilder.Entity<Order>()
                .HasOne(s => s.ShippingMethod)
                .WithMany(o => o.Orders)
                .HasForeignKey(f => f.PaymentMethodID);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(o => o.Orders)
                .HasForeignKey(f => f.PaymentMethodID);

            modelBuilder.Entity<Product>()
                .HasOne(b => b.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(f => f.BrandID);

            modelBuilder.Entity<Product>()
                .HasOne(m => m.MaterialFrameType)
                .WithMany(p => p.Products)
                .HasForeignKey(f => f.MaterialFrameTypeID);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(fk => new { fk.OrderID, fk.ProductID });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(f => f.OrderID);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(f => f.ProductID);

            #endregion

            #region  ************************ Data Seeding ***************************

            modelBuilder.Entity<ShippingMethod>().HasData(
                new ShippingMethod { ShippingMethodID = 1, Transporter = "GLS" },
                new ShippingMethod { ShippingMethodID = 2, Transporter = "PostNord" },
                new ShippingMethod { ShippingMethodID = 3, Transporter = "DAO365" },
                new ShippingMethod { ShippingMethodID = 4, Transporter = "DHL" },
                new ShippingMethod { ShippingMethodID = 5, Transporter = "Bring" });

            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { PaymentMethodID = 1, Payment = "Dankort" },
                new PaymentMethod { PaymentMethodID = 2, Payment = "Visa" },
                new PaymentMethod { PaymentMethodID = 3, Payment = "MasterCard" },
                new PaymentMethod { PaymentMethodID = 4, Payment = "MobilePay" },
                new PaymentMethod { PaymentMethodID = 5, Payment = "Klarna" },
                new PaymentMethod { PaymentMethodID = 6, Payment = "JCB Card" });

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandID = 1, Name = "Alcatel" },
                new Brand { BrandID = 2, Name = "Apple" },
                new Brand { BrandID = 3, Name = "Asus" },
                new Brand { BrandID = 4, Name = "BlackBerry" },
                new Brand { BrandID = 5, Name = "Google" },
                new Brand { BrandID = 6, Name = "HTC" },
                new Brand { BrandID = 7, Name = "Huawei" },
                new Brand { BrandID = 8, Name = "LG" },
                new Brand { BrandID = 9, Name = "OnePlus" },
                new Brand { BrandID = 10, Name = "Samsung" },
                new Brand { BrandID = 11, Name = "Sony" });

            modelBuilder.Entity<MaterialFrameType>().HasData(
                new MaterialFrameType { MaterialFrameTypeID = 1, Type = "Plastic" },
                new MaterialFrameType { MaterialFrameTypeID = 2, Type = "Aluminium" },
                new MaterialFrameType { MaterialFrameTypeID = 3, Type = "Stainless steel" });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    BrandID = 1,
                    Model = "1s",
                    Price = 500,
                    Color = "Blue",
                    Description = "Brand new phone with a brand new chipset by Unisoc SC9863A",
                    ImageName = "Alcatel-1s.jpg",
                    Storage = 32,
                    Year = new DateTime(2019, 2, 12),
                    MaterialFrameTypeID = 1
                },
                new Product
                {
                    ProductID = 2,
                    BrandID = 1,
                    Model = "3x",
                    Price = 620,
                    Color = "Black",
                    Description = "A new powerful chipset by Mediatek",
                    ImageName = "Alcatel-3x.jpg",
                    Storage = 64,
                    Year = new DateTime(2019, 9, 8),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 3,
                    BrandID = 2,
                    Model = "Xs",
                    Price = 1300,
                    Color = "Black",
                    Description = "Fall in love with the new OLED display, stainless steel body frame and a new powerful CPU",
                    ImageName = "Apple-iphone-xs.jpg",
                    Storage = 64,
                    Year = new DateTime(2018, 9, 11),
                    MaterialFrameTypeID = 3
                },
                new Product
                {
                    ProductID = 4,
                    BrandID = 2,
                    Model = "11 pro",
                    Price = 1400,
                    Color = "Gold",
                    Description = "Get the new Iphone with triple cameras and be a professional photographer",
                    ImageName = "Apple-iphone-11-pro.jpg",
                    Storage = 256,
                    Year = new DateTime(2019, 9, 13),
                    MaterialFrameTypeID = 3
                },
                new Product
                {
                    ProductID = 5,
                    BrandID = 3,
                    Model = "Zenfone 5",
                    Price = 700,
                    Color = "Silver",
                    Description = "The brand new Zenfone 5 will give you a good experience while listening to music",
                    ImageName = "Asus-Zenfone-5.jpg",
                    Storage = 64,
                    Year = new DateTime(2018, 2, 23),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 6,
                    BrandID = 3,
                    Model = "ROG Phone 2",
                    Price = 1100,
                    Color = "Black",
                    Description = "Change the way you play games with ROG phone 2, powerful 6000mAh battery and 120Hz refresh rate",
                    ImageName = "Asus-rog-phone2.jpg",
                    Storage = 512,
                    Year = new DateTime(2019, 7, 10),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 7,
                    BrandID = 4,
                    Model = "KEY 2LE",
                    Price = 600,
                    Color = "Black",
                    Description = "You still want qwerty keyboard? KEY 2LE will be the perfect choice for you",
                    ImageName = "BlackBerry-key2-le.jpg",
                    Storage = 32,
                    Year = new DateTime(2018, 8, 24),
                    MaterialFrameTypeID = 1
                },
                new Product
                {
                    ProductID = 8,
                    BrandID = 4,
                    Model = "Exolve X",
                    Price = 650,
                    Color = "Black",
                    Description = "Get the new BlackBerry phone with small bezzels and maximum performance",
                    ImageName = "BlackBerry-exolve-x-5.jpg",
                    Storage = 64,
                    Year = new DateTime(2018, 8, 24),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 9,
                    BrandID = 5,
                    Model = "Pixel 4 XL",
                    Price = 1000,
                    Color = "Orange",
                    Description = "The new pixel 4 XL comes with a new camera performance and with the new android 10",
                    ImageName = "Google-pixel-4-r1.jpg",
                    Storage = 128,
                    Year = new DateTime(2019, 10, 18),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 10,
                    BrandID = 5,
                    Model = "Pixel 4",
                    Price = 910,
                    Color = "Orange",
                    Description = "The pixel 4 comes with an wonderful P-OLED display and 90Hz refresh rate",
                    ImageName = "Google-pixel-4-r1.jpg",
                    Storage = 128,
                    Year = new DateTime(2019, 10, 18),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 11,
                    BrandID = 6,
                    Model = "Wildfire X",
                    Price = 840,
                    Color = "Blue",
                    Description = "Get rid of thiefs with a new fingerprint in-display",
                    ImageName = "HTC-wildfire-x.jpg",
                    Storage = 64,
                    Year = new DateTime(2019, 8, 11),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 12,
                    BrandID = 6,
                    Model = "U19e",
                    Price = 930,
                    Color = "Purple",
                    Description = "The U19e deliveres a new camera system with a new OLED display",
                    ImageName = "HTC-u19e.jpg",
                    Storage = 64,
                    Year = new DateTime(2019, 6, 21),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 13,
                    BrandID = 7,
                    Model = "P30 pro",
                    Price = 980,
                    Color = "Blue",
                    Description = "Be a professional photographer only with P30 pro",
                    ImageName = "Huawei-p30-pro.jpg",
                    Storage = 128,
                    Year = new DateTime(2019, 6, 26),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 14,
                    BrandID = 7,
                    Model = "Mate 30 pro",
                    Price = 1200,
                    Color = "Purple",
                    Description = "Mate 30 pro comes with a new powerful HiSilicon Kirin 990 and new features",
                    ImageName = "Huawei-mate30-pro.jpg",
                    Storage = 128,
                    Year = new DateTime(2019, 9, 16),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 15,
                    BrandID = 8,
                    Model = "V50 ThinQ 5G",
                    Price = 930,
                    Color = "Black",
                    Description = "Improve your sound experience with the new LG phone",
                    ImageName = "LG-gv50-thinq.jpg",
                    Storage = 64,
                    Year = new DateTime(2019, 2, 24),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 16,
                    BrandID = 8,
                    Model = "V30",
                    Price = 870,
                    Color = "White",
                    Description = "You will be captivated by the good quality of the new P-OLED display",
                    ImageName = "LG-v30.jpg",
                    Storage = 64,
                    Year = new DateTime(2018, 10, 27),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 17,
                    BrandID = 9,
                    Model = "7t Pro",
                    Price = 950,
                    Color = "Blue",
                    Description = "Feel the smoothnes. Go beyond the speed at maximum performance",
                    ImageName = "Oneplus-7t-pro.jpg",
                    Storage = 512,
                    Year = new DateTime(2019, 10, 3),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 18,
                    BrandID = 9,
                    Model = "7t Pro Mclaren Edition",
                    Price = 1100,
                    Color = "Black",
                    Description = "Super premium design with fast charging from a hole another level at maximum performance",
                    ImageName = "Oneplus-7t-pro-mclaren-edition.jpg",
                    Storage = 512,
                    Year = new DateTime(2019, 10, 23),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 19,
                    BrandID = 10,
                    Model = "S9+",
                    Price = 980,
                    Color = "Blue",
                    Description = "Change the way you take photoes with dual aperture camera",
                    ImageName = "Samsung-galaxy-s9-plus.jpg",
                    Storage = 64,
                    Year = new DateTime(2018, 2, 18),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 20,
                    BrandID = 10,
                    Model = "S10+",
                    Price = 1150,
                    Color = "Green",
                    Description = "Share your energy and enjoy a full wide screen with punch hole camera designed with laser",
                    ImageName = "Samsung-galaxy-s10-plus.jpg",
                    Storage = 512,
                    Year = new DateTime(2019, 2, 21),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 21,
                    BrandID = 11,
                    Model = "Xperia 5",
                    Price = 1080,
                    Color = "Purple",
                    Description = "A super high quality display at highest PPI ever with premium design",
                    ImageName = "Sony-xperia-5.jpg",
                    Storage = 128,
                    Year = new DateTime(2019, 9, 2),
                    MaterialFrameTypeID = 2
                },
                new Product
                {
                    ProductID = 22,
                    BrandID = 11,
                    Model = "Xperia 1",
                    Price = 880,
                    Color = "White",
                    Description = "A beautiful 4K display with true colors and a powerful chipset by Qualcom",
                    ImageName = "Sony-xperia-1.jpg",
                    Storage = 128,
                    Year = new DateTime(2019, 2, 24),
                    MaterialFrameTypeID = 2
                });

            #endregion
        }
    }
}
