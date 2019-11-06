using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class FixMaterialFrameType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 1,
                column: "LogoName",
                value: "Alcatel.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "BrandID",
                keyValue: 1,
                column: "LogoName",
                value: "Alcaltel.png");
        }
    }
}
