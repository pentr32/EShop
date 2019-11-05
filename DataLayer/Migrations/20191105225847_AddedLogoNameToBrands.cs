using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddedLogoNameToBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoName",
                table: "Brands",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 1,
                column: "LogoName",
                value: "Alcaltel.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 2,
                column: "LogoName",
                value: "Apple.svg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 3,
                column: "LogoName",
                value: "Asus.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 4,
                column: "LogoName",
                value: "BlackBerry.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 5,
                column: "LogoName",
                value: "Google.jpg");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 6,
                column: "LogoName",
                value: "HTC.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 7,
                column: "LogoName",
                value: "Huawei.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 8,
                column: "LogoName",
                value: "LG.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 9,
                column: "LogoName",
                value: "OnePlus.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 10,
                column: "LogoName",
                value: "Samsung.png");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 11,
                column: "LogoName",
                value: "Sony.png");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "Email", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Sondgade 4", "robe1819@elevcampus.dk", "Robert-Iulian", "Zaharia" },
                    { 2, "Voldgade 12", "john6531@elevcampus.dk", "John", "Hansen" },
                    { 3, "Hilsensgade 201", "jaco8872@elevcampus.dk", "Jacob", "Koefed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "LogoName",
                table: "Brands");
        }
    }
}
