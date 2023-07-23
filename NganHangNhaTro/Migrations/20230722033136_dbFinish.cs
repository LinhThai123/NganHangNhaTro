using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangNhaTro.Migrations
{
    public partial class dbFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "RealEstate");
        }
    }
}
