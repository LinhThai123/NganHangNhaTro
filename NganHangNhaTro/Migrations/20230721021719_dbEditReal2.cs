using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangNhaTro.Migrations
{
    public partial class dbEditReal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_Agent_UserId",
                table: "RealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "RealEstateId",
                table: "RealEstate",
                newName: "RealEstateTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstate_RealEstateId",
                table: "RealEstate",
                newName: "IX_RealEstate_RealEstateTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_Agent_UserId",
                table: "RealEstate",
                column: "UserId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateTypeId",
                table: "RealEstate",
                column: "RealEstateTypeId",
                principalTable: "RealEstateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_Agent_UserId",
                table: "RealEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateTypeId",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "RealEstateTypeId",
                table: "RealEstate",
                newName: "RealEstateId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstate_RealEstateTypeId",
                table: "RealEstate",
                newName: "IX_RealEstate_RealEstateId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RealEstate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_Agent_UserId",
                table: "RealEstate",
                column: "UserId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateType_RealEstateId",
                table: "RealEstate",
                column: "RealEstateId",
                principalTable: "RealEstateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
