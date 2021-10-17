using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep.Data.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_realEstates_category_CategoryID",
                table: "realEstates");

            migrationBuilder.DropIndex(
                name: "IX_realEstates_CategoryID",
                table: "realEstates");

            migrationBuilder.AddColumn<string>(
                name: "CategoryID1",
                table: "realEstates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryID",
                table: "category",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_realEstates_CategoryID1",
                table: "realEstates",
                column: "CategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_realEstates_category_CategoryID1",
                table: "realEstates",
                column: "CategoryID1",
                principalTable: "category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_realEstates_category_CategoryID1",
                table: "realEstates");

            migrationBuilder.DropIndex(
                name: "IX_realEstates_CategoryID1",
                table: "realEstates");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "realEstates");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "category",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_realEstates_CategoryID",
                table: "realEstates",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_realEstates_category_CategoryID",
                table: "realEstates",
                column: "CategoryID",
                principalTable: "category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
