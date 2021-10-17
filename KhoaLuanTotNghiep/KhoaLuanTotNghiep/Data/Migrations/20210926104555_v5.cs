using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep.Data.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealEstateID",
                table: "reports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "news",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reports_RealEstateID",
                table: "reports",
                column: "RealEstateID");

            migrationBuilder.CreateIndex(
                name: "IX_realEstates_CategoryID",
                table: "realEstates",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_news_UserID",
                table: "news",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_news_AspNetUsers_UserID",
                table: "news",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_realEstates_categories_CategoryID",
                table: "realEstates",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_realEstates_RealEstateID",
                table: "reports",
                column: "RealEstateID",
                principalTable: "realEstates",
                principalColumn: "RealEstateID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_news_AspNetUsers_UserID",
                table: "news");

            migrationBuilder.DropForeignKey(
                name: "FK_realEstates_categories_CategoryID",
                table: "realEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_realEstates_RealEstateID",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_reports_RealEstateID",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_realEstates_CategoryID",
                table: "realEstates");

            migrationBuilder.DropIndex(
                name: "IX_news_UserID",
                table: "news");

            migrationBuilder.DropColumn(
                name: "RealEstateID",
                table: "reports");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "news",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
