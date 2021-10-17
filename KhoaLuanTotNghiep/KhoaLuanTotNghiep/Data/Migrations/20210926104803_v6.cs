using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep.Data.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");
        }
    }
}
