using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangNhaTro.Migrations
{
    public partial class dbfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateDetail");

            migrationBuilder.AddColumn<int>(
                name: "Acreage",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCook",
                table: "RealEstate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElectronicPrice",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FreeTime",
                table: "RealEstate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMezzanine",
                table: "RealEstate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPrivateWc",
                table: "RealEstate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "RealEstate",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SecurityCamera",
                table: "RealEstate",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaterPrice",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WifiPrice",
                table: "RealEstate",
                type: "decimal(18,0)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acreage",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "AllowCook",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "ElectronicPrice",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "FreeTime",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "HasMezzanine",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "HasPrivateWc",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "SecurityCamera",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "WaterPrice",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "WifiPrice",
                table: "RealEstate");

            migrationBuilder.CreateTable(
                name: "RealEstateDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Acreage = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AllowCook = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectronicPrice = table.Column<int>(type: "int", nullable: true),
                    FreeTime = table.Column<bool>(type: "bit", nullable: false),
                    HasMezzanine = table.Column<bool>(type: "bit", nullable: false),
                    HasPrivateWc = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    SecurityCamera = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterPrice = table.Column<int>(type: "int", nullable: true),
                    WifiPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateDetail_RealEstate_Id",
                        column: x => x.Id,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
