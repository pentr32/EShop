using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LogoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "MaterialFrameTypes",
                columns: table => new
                {
                    MaterialFrameTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialFrameTypes", x => x.MaterialFrameTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                columns: table => new
                {
                    ShippingMethodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transporter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.ShippingMethodID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: true),
                    Storage = table.Column<double>(nullable: false),
                    BrandID = table.Column<int>(nullable: true),
                    MaterialFrameTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_MaterialFrameTypes_MaterialFrameTypeID",
                        column: x => x.MaterialFrameTypeID,
                        principalTable: "MaterialFrameTypes",
                        principalColumn: "MaterialFrameTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOrder = table.Column<DateTime>(nullable: false),
                    EstimatedDate = table.Column<DateTime>(nullable: false),
                    ShippingAddress = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    ShippingMethodID = table.Column<int>(nullable: false),
                    PaymentMethodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingMethods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "ShippingMethods",
                        principalColumn: "ShippingMethodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "LogoName", "Name" },
                values: new object[,]
                {
                    { 1, "Alcatel.png", "Alcatel" },
                    { 2, "Apple.svg", "Apple" },
                    { 3, "Asus.png", "Asus" },
                    { 4, "BlackBerry.png", "BlackBerry" },
                    { 5, "Google.jpg", "Google" },
                    { 6, "HTC.png", "HTC" },
                    { 7, "Huawei.png", "Huawei" },
                    { 8, "LG.png", "LG" },
                    { 9, "OnePlus.png", "OnePlus" },
                    { 10, "Samsung.png", "Samsung" },
                    { 11, "Sony.png", "Sony" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "Email", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 2, "Voldgade 12", "john6531@elevcampus.dk", "John", "Hansen" },
                    { 3, "Hilsensgade 201", "jaco8872@elevcampus.dk", "Jacob", "Koefed" },
                    { 1, "Sondgade 4", "robe1819@elevcampus.dk", "Robert-Iulian", "Zaharia" }
                });

            migrationBuilder.InsertData(
                table: "MaterialFrameTypes",
                columns: new[] { "MaterialFrameTypeID", "Type" },
                values: new object[,]
                {
                    { 1, "Plastic" },
                    { 2, "Aluminium" },
                    { 3, "Stainless steel" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodID", "Payment" },
                values: new object[,]
                {
                    { 1, "Dankort" },
                    { 2, "Visa" },
                    { 3, "MasterCard" },
                    { 4, "MobilePay" },
                    { 5, "Klarna" },
                    { 6, "JCB Card" }
                });

            migrationBuilder.InsertData(
                table: "ShippingMethods",
                columns: new[] { "ShippingMethodID", "Transporter" },
                values: new object[,]
                {
                    { 4, "DHL" },
                    { 1, "GLS" },
                    { 2, "PostNord" },
                    { 3, "DAO365" },
                    { 5, "Bring" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandID", "Color", "Description", "ImageName", "MaterialFrameTypeID", "Model", "Price", "Storage", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Blue", "Brand new phone with a brand new chipset by Unisoc SC9863A", "Alcatel-1s.jpg", 1, "1s", 500.0, 32.0, new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 11, "White", "A beautiful 4K display with true colors and a powerful chipset by Qualcom", "Sony-xperia-1.jpg", 2, "Xperia 1", 880.0, 128.0, new DateTime(2019, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 11, "Purple", "A super high quality display at highest PPI ever with premium design", "Sony-xperia-5.jpg", 2, "Xperia 5", 1080.0, 128.0, new DateTime(2019, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 10, "Green", "Share your energy and enjoy a full wide screen with punch hole camera designed with laser", "Samsung-galaxy-s10-plus.jpg", 2, "S10+", 1150.0, 512.0, new DateTime(2019, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 10, "Blue", "Change the way you take photoes with dual aperture camera", "Samsung-galaxy-s9-plus.jpg", 2, "S9+", 980.0, 64.0, new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 9, "Black", "Super premium design with fast charging from a hole another level at maximum performance", "Oneplus-7t-pro-mclaren-edition.jpg", 2, "7t Pro Mclaren Edition", 1100.0, 512.0, new DateTime(2019, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 9, "Blue", "Feel the smoothnes. Go beyond the speed at maximum performance", "Oneplus-7t-pro.jpg", 2, "7t Pro", 950.0, 512.0, new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 8, "White", "You will be captivated by the good quality of the new P-OLED display", "LG-v30.jpg", 2, "V30", 870.0, 64.0, new DateTime(2018, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 8, "Black", "Improve your sound experience with the new LG phone", "LG-gv50-thinq.jpg", 2, "V50 ThinQ 5G", 930.0, 64.0, new DateTime(2019, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 7, "Purple", "Mate 30 pro comes with a new powerful HiSilicon Kirin 990 and new features", "Huawei-mate30-pro.jpg", 2, "Mate 30 pro", 1200.0, 128.0, new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 7, "Blue", "Be a professional photographer only with P30 pro", "Huawei-p30-pro.jpg", 2, "P30 pro", 980.0, 128.0, new DateTime(2019, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 6, "Purple", "The U19e deliveres a new camera system with a new OLED display", "HTC-u19e.jpg", 2, "U19e", 930.0, 64.0, new DateTime(2019, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 6, "Blue", "Get rid of thiefs with a new fingerprint in-display", "HTC-wildfire-x.jpg", 2, "Wildfire X", 840.0, 64.0, new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, "Orange", "The pixel 4 comes with an wonderful P-OLED display and 90Hz refresh rate", "Google-pixel-4-r1.jpg", 2, "Pixel 4", 910.0, 128.0, new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5, "Orange", "The new pixel 4 XL comes with a new camera performance and with the new android 10", "Google-pixel-4-r1.jpg", 2, "Pixel 4 XL", 1000.0, 128.0, new DateTime(2019, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, "Black", "Get the new BlackBerry phone with small bezzels and maximum performance", "BlackBerry-exolve-x-5.jpg", 2, "Exolve X", 650.0, 64.0, new DateTime(2018, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Black", "Change the way you play games with ROG phone 2, powerful 6000mAh battery and 120Hz refresh rate", "Asus-rog-phone2.jpg", 2, "ROG Phone 2", 1100.0, 512.0, new DateTime(2019, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, "Silver", "The brand new Zenfone 5 will give you a good experience while listening to music", "Asus-Zenfone-5.jpg", 2, "Zenfone 5", 700.0, 64.0, new DateTime(2018, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Black", "A new powerful chipset by Mediatek", "Alcatel-3x.jpg", 2, "3x", 620.0, 64.0, new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, "Black", "You still want qwerty keyboard? KEY 2LE will be the perfect choice for you", "BlackBerry-key2-le.jpg", 1, "KEY 2LE", 600.0, 32.0, new DateTime(2018, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Black", "Fall in love with the new OLED display, stainless steel body frame and a new powerful CPU", "Apple-iphone-xs.jpg", 3, "Xs", 1300.0, 64.0, new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Gold", "Get the new Iphone with triple cameras and be a professional photographer", "Apple-iphone-11-pro.jpg", 3, "11 pro", 1400.0, 256.0, new DateTime(2019, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductID",
                table: "OrderProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodID",
                table: "Orders",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MaterialFrameTypeID",
                table: "Products",
                column: "MaterialFrameTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "MaterialFrameTypes");
        }
    }
}
