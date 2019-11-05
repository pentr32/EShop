using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class DbSetOnMaterialFrameType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MaterialFrameType_MaterialFrameTypeID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialFrameType",
                table: "MaterialFrameType");

            migrationBuilder.RenameTable(
                name: "MaterialFrameType",
                newName: "MaterialFrameTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialFrameTypes",
                table: "MaterialFrameTypes",
                column: "MaterialFrameTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MaterialFrameTypes_MaterialFrameTypeID",
                table: "Products",
                column: "MaterialFrameTypeID",
                principalTable: "MaterialFrameTypes",
                principalColumn: "MaterialFrameTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MaterialFrameTypes_MaterialFrameTypeID",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialFrameTypes",
                table: "MaterialFrameTypes");

            migrationBuilder.RenameTable(
                name: "MaterialFrameTypes",
                newName: "MaterialFrameType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialFrameType",
                table: "MaterialFrameType",
                column: "MaterialFrameTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MaterialFrameType_MaterialFrameTypeID",
                table: "Products",
                column: "MaterialFrameTypeID",
                principalTable: "MaterialFrameType",
                principalColumn: "MaterialFrameTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
