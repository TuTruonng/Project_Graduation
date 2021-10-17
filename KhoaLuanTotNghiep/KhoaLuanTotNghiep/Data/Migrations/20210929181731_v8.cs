using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep.Data.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "acreage",
                table: "realEstates",
                newName: "Acreage");

            migrationBuilder.RenameColumn(
                name: "Quanlity",
                table: "realEstates",
                newName: "Quality");

            migrationBuilder.RenameColumn(
                name: "NewID",
                table: "news",
                newName: "NewsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Acreage",
                table: "realEstates",
                newName: "acreage");

            migrationBuilder.RenameColumn(
                name: "Quality",
                table: "realEstates",
                newName: "Quanlity");

            migrationBuilder.RenameColumn(
                name: "NewsID",
                table: "news",
                newName: "NewID");
        }
    }
}
