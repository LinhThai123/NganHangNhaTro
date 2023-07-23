using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangNhaTro.Migrations
{
    public partial class dbEditRealDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "RealEstateDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "RealEstateDetail");
        }
    }
}
