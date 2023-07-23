using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangNhaTro.Migrations
{
    public partial class dbEditReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateId",
                table: "RealEstate");

            migrationBuilder.AlterColumn<int>(
                name: "RealEstateId",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateId",
                table: "RealEstate",
                column: "RealEstateId",
                principalTable: "RealEstateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "RealEstate");

            migrationBuilder.AlterColumn<int>(
                name: "RealEstateId",
                table: "RealEstate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateId",
                table: "RealEstate",
                column: "RealEstateId",
                principalTable: "RealEstateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
