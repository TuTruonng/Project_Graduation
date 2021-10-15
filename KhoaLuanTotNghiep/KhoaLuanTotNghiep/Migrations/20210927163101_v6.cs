using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

            migrationBuilder.AlterColumn<string>(
                name: "RealEstateID",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RealEstateID",
                table: "reports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportID",
                table: "realEstates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "realEstates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "news",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "UserID");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactions",
                table: "transactions");

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
                name: "UserID",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "realEstates");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "realEstates");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "news");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "RealEstateID",
                table: "transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RealEstateID",
                table: "reports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactions",
                table: "transactions",
                column: "RealEstateID");
        }
    }
}
