using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "Name" },
                values: new object[,]
                {
                    { 1, "Alcatel" },
                    { 2, "Apple" },
                    { 3, "Asus" },
                    { 4, "BlackBerry" },
                    { 5, "Google" },
                    { 6, "HTC" },
                    { 7, "Huawei" },
                    { 8, "LG" },
                    { 9, "OnePlus" },
                    { 10, "Samsung" },
                    { 11, "Sony" }
                });

            migrationBuilder.InsertData(
                table: "MaterialFrameType",
                columns: new[] { "MaterialFrameTypeID", "Type" },
                values: new object[,]
                {
                    { 3, "Stainless steel" },
                    { 2, "Aluminium" },
                    { 1, "Plastic" }
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
                    { 1, "GLS" },
                    { 2, "PostNord" },
                    { 3, "DAO365" },
                    { 4, "DHL" },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShippingMethods",
                keyColumn: "ShippingMethodID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MaterialFrameType",
                keyColumn: "MaterialFrameTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaterialFrameType",
                keyColumn: "MaterialFrameTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaterialFrameType",
                keyColumn: "MaterialFrameTypeID",
                keyValue: 3);
        }
    }
}
