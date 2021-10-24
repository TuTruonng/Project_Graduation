using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "rates");

            migrationBuilder.AddColumn<string>(
                name: "RealEstateId",
                table: "rates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rates_RealEstateId",
                table: "rates",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_rates_realEstates_RealEstateId",
                table: "rates",
                column: "RealEstateId",
                principalTable: "realEstates",
                principalColumn: "RealEstateID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rates_realEstates_RealEstateId",
                table: "rates");

            migrationBuilder.DropIndex(
                name: "IX_rates_RealEstateId",
                table: "rates");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "rates");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "rates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
