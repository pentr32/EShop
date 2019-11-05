﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EShopContext))]
    partial class EShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandID = 1,
                            LogoName = "Alcaltel.png",
                            Name = "Alcatel"
                        },
                        new
                        {
                            BrandID = 2,
                            LogoName = "Apple.svg",
                            Name = "Apple"
                        },
                        new
                        {
                            BrandID = 3,
                            LogoName = "Asus.png",
                            Name = "Asus"
                        },
                        new
                        {
                            BrandID = 4,
                            LogoName = "BlackBerry.png",
                            Name = "BlackBerry"
                        },
                        new
                        {
                            BrandID = 5,
                            LogoName = "Google.jpg",
                            Name = "Google"
                        },
                        new
                        {
                            BrandID = 6,
                            LogoName = "HTC.png",
                            Name = "HTC"
                        },
                        new
                        {
                            BrandID = 7,
                            LogoName = "Huawei.png",
                            Name = "Huawei"
                        },
                        new
                        {
                            BrandID = 8,
                            LogoName = "LG.png",
                            Name = "LG"
                        },
                        new
                        {
                            BrandID = 9,
                            LogoName = "OnePlus.png",
                            Name = "OnePlus"
                        },
                        new
                        {
                            BrandID = 10,
                            LogoName = "Samsung.png",
                            Name = "Samsung"
                        },
                        new
                        {
                            BrandID = 11,
                            LogoName = "Sony.png",
                            Name = "Sony"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Address = "Sondgade 4",
                            Email = "robe1819@elevcampus.dk",
                            Firstname = "Robert-Iulian",
                            Lastname = "Zaharia"
                        },
                        new
                        {
                            CustomerID = 2,
                            Address = "Voldgade 12",
                            Email = "john6531@elevcampus.dk",
                            Firstname = "John",
                            Lastname = "Hansen"
                        },
                        new
                        {
                            CustomerID = 3,
                            Address = "Hilsensgade 201",
                            Email = "jaco8872@elevcampus.dk",
                            Firstname = "Jacob",
                            Lastname = "Koefed"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.MaterialFrameType", b =>
                {
                    b.Property<int>("MaterialFrameTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialFrameTypeID");

                    b.ToTable("MaterialFrameTypes");

                    b.HasData(
                        new
                        {
                            MaterialFrameTypeID = 1,
                            Type = "Plastic"
                        },
                        new
                        {
                            MaterialFrameTypeID = 2,
                            Type = "Aluminium"
                        },
                        new
                        {
                            MaterialFrameTypeID = 3,
                            Type = "Stainless steel"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOrder")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EstimatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentMethodID")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShippingMethodID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PaymentMethodID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Entities.OrderProduct", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Payment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentMethodID");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            PaymentMethodID = 1,
                            Payment = "Dankort"
                        },
                        new
                        {
                            PaymentMethodID = 2,
                            Payment = "Visa"
                        },
                        new
                        {
                            PaymentMethodID = 3,
                            Payment = "MasterCard"
                        },
                        new
                        {
                            PaymentMethodID = 4,
                            Payment = "MobilePay"
                        },
                        new
                        {
                            PaymentMethodID = 5,
                            Payment = "Klarna"
                        },
                        new
                        {
                            PaymentMethodID = 6,
                            Payment = "JCB Card"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaterialFrameTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Storage")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductID");

                    b.HasIndex("BrandID");

                    b.HasIndex("MaterialFrameTypeID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            BrandID = 1,
                            Color = "Blue",
                            Description = "Brand new phone with a brand new chipset by Unisoc SC9863A",
                            ImageName = "Alcatel-1s.jpg",
                            MaterialFrameTypeID = 1,
                            Model = "1s",
                            Price = 500.0,
                            Storage = 32.0,
                            Year = new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 2,
                            BrandID = 1,
                            Color = "Black",
                            Description = "A new powerful chipset by Mediatek",
                            ImageName = "Alcatel-3x.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "3x",
                            Price = 620.0,
                            Storage = 64.0,
                            Year = new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 3,
                            BrandID = 2,
                            Color = "Black",
                            Description = "Fall in love with the new OLED display, stainless steel body frame and a new powerful CPU",
                            ImageName = "Apple-iphone-xs.jpg",
                            MaterialFrameTypeID = 3,
                            Model = "Xs",
                            Price = 1300.0,
                            Storage = 64.0,
                            Year = new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 4,
                            BrandID = 2,
                            Color = "Gold",
                            Description = "Get the new Iphone with triple cameras and be a professional photographer",
                            ImageName = "Apple-iphone-11-pro.jpg",
                            MaterialFrameTypeID = 3,
                            Model = "11 pro",
                            Price = 1400.0,
                            Storage = 256.0,
                            Year = new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 5,
                            BrandID = 3,
                            Color = "Silver",
                            Description = "The brand new Zenfone 5 will give you a good experience while listening to music",
                            ImageName = "Asus-Zenfone-5.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Zenfone 5",
                            Price = 700.0,
                            Storage = 64.0,
                            Year = new DateTime(2018, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 6,
                            BrandID = 3,
                            Color = "Black",
                            Description = "Change the way you play games with ROG phone 2, powerful 6000mAh battery and 120Hz refresh rate",
                            ImageName = "Asus-rog-phone2.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "ROG Phone 2",
                            Price = 1100.0,
                            Storage = 512.0,
                            Year = new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 7,
                            BrandID = 4,
                            Color = "Black",
                            Description = "You still want qwerty keyboard? KEY 2LE will be the perfect choice for you",
                            ImageName = "BlackBerry-key2-le.jpg",
                            MaterialFrameTypeID = 1,
                            Model = "KEY 2LE",
                            Price = 600.0,
                            Storage = 32.0,
                            Year = new DateTime(2018, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 8,
                            BrandID = 4,
                            Color = "Black",
                            Description = "Get the new BlackBerry phone with small bezzels and maximum performance",
                            ImageName = "BlackBerry-exolve-x-5.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Exolve X",
                            Price = 650.0,
                            Storage = 64.0,
                            Year = new DateTime(2018, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 9,
                            BrandID = 5,
                            Color = "Orange",
                            Description = "The new pixel 4 XL comes with a new camera performance and with the new android 10",
                            ImageName = "Google-pixel-4-r1.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Pixel 4 XL",
                            Price = 1000.0,
                            Storage = 128.0,
                            Year = new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 10,
                            BrandID = 5,
                            Color = "Orange",
                            Description = "The pixel 4 comes with an wonderful P-OLED display and 90Hz refresh rate",
                            ImageName = "Google-pixel-4-r1.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Pixel 4",
                            Price = 910.0,
                            Storage = 128.0,
                            Year = new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 11,
                            BrandID = 6,
                            Color = "Blue",
                            Description = "Get rid of thiefs with a new fingerprint in-display",
                            ImageName = "HTC-wildfire-x.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Wildfire X",
                            Price = 840.0,
                            Storage = 64.0,
                            Year = new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 12,
                            BrandID = 6,
                            Color = "Purple",
                            Description = "The U19e deliveres a new camera system with a new OLED display",
                            ImageName = "HTC-u19e.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "U19e",
                            Price = 930.0,
                            Storage = 64.0,
                            Year = new DateTime(2019, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 13,
                            BrandID = 7,
                            Color = "Blue",
                            Description = "Be a professional photographer only with P30 pro",
                            ImageName = "Huawei-p30-pro.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "P30 pro",
                            Price = 980.0,
                            Storage = 128.0,
                            Year = new DateTime(2019, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 14,
                            BrandID = 7,
                            Color = "Purple",
                            Description = "Mate 30 pro comes with a new powerful HiSilicon Kirin 990 and new features",
                            ImageName = "Huawei-mate30-pro.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Mate 30 pro",
                            Price = 1200.0,
                            Storage = 128.0,
                            Year = new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 15,
                            BrandID = 8,
                            Color = "Black",
                            Description = "Improve your sound experience with the new LG phone",
                            ImageName = "LG-gv50-thinq.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "V50 ThinQ 5G",
                            Price = 930.0,
                            Storage = 64.0,
                            Year = new DateTime(2019, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 16,
                            BrandID = 8,
                            Color = "White",
                            Description = "You will be captivated by the good quality of the new P-OLED display",
                            ImageName = "LG-v30.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "V30",
                            Price = 870.0,
                            Storage = 64.0,
                            Year = new DateTime(2018, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 17,
                            BrandID = 9,
                            Color = "Blue",
                            Description = "Feel the smoothnes. Go beyond the speed at maximum performance",
                            ImageName = "Oneplus-7t-pro.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "7t Pro",
                            Price = 950.0,
                            Storage = 512.0,
                            Year = new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 18,
                            BrandID = 9,
                            Color = "Black",
                            Description = "Super premium design with fast charging from a hole another level at maximum performance",
                            ImageName = "Oneplus-7t-pro-mclaren-edition.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "7t Pro Mclaren Edition",
                            Price = 1100.0,
                            Storage = 512.0,
                            Year = new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 19,
                            BrandID = 10,
                            Color = "Blue",
                            Description = "Change the way you take photoes with dual aperture camera",
                            ImageName = "Samsung-galaxy-s9-plus.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "S9+",
                            Price = 980.0,
                            Storage = 64.0,
                            Year = new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 20,
                            BrandID = 10,
                            Color = "Green",
                            Description = "Share your energy and enjoy a full wide screen with punch hole camera designed with laser",
                            ImageName = "Samsung-galaxy-s10-plus.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "S10+",
                            Price = 1150.0,
                            Storage = 512.0,
                            Year = new DateTime(2019, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 21,
                            BrandID = 11,
                            Color = "Purple",
                            Description = "A super high quality display at highest PPI ever with premium design",
                            ImageName = "Sony-xperia-5.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Xperia 5",
                            Price = 1080.0,
                            Storage = 128.0,
                            Year = new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductID = 22,
                            BrandID = 11,
                            Color = "White",
                            Description = "A beautiful 4K display with true colors and a powerful chipset by Qualcom",
                            ImageName = "Sony-xperia-1.jpg",
                            MaterialFrameTypeID = 2,
                            Model = "Xperia 1",
                            Price = 880.0,
                            Storage = 128.0,
                            Year = new DateTime(2019, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.ShippingMethod", b =>
                {
                    b.Property<int>("ShippingMethodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Transporter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShippingMethodID");

                    b.ToTable("ShippingMethods");

                    b.HasData(
                        new
                        {
                            ShippingMethodID = 1,
                            Transporter = "GLS"
                        },
                        new
                        {
                            ShippingMethodID = 2,
                            Transporter = "PostNord"
                        },
                        new
                        {
                            ShippingMethodID = 3,
                            Transporter = "DAO365"
                        },
                        new
                        {
                            ShippingMethodID = 4,
                            Transporter = "DHL"
                        },
                        new
                        {
                            ShippingMethodID = 5,
                            Transporter = "Bring"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.HasOne("DataLayer.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.ShippingMethod", "ShippingMethod")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentMethodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.OrderProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.HasOne("DataLayer.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandID");

                    b.HasOne("DataLayer.Entities.MaterialFrameType", "MaterialFrameType")
                        .WithMany("Products")
                        .HasForeignKey("MaterialFrameTypeID");
                });
#pragma warning restore 612, 618
        }
    }
}
