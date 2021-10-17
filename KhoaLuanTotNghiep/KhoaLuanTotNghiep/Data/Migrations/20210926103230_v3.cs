using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    NewID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.NewID);
                });

            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    ReportID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RealEstatetID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.ReportID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "reports");
        }
    }
}
