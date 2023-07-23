using Microsoft.EntityFrameworkCore.Migrations;

namespace NganHangNhaTro.Migrations
{
    public partial class dbRealEstateDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstateDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acreage = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPrivateWc = table.Column<bool>(type: "bit", nullable: false),
                    HasMezzanine = table.Column<bool>(type: "bit", nullable: false),
                    AllowCook = table.Column<bool>(type: "bit", nullable: false),
                    FreeTime = table.Column<bool>(type: "bit", nullable: false),
                    SecurityCamera = table.Column<bool>(type: "bit", nullable: false),
                    WaterPrice = table.Column<int>(type: "int", nullable: true),
                    ElectronicPrice = table.Column<int>(type: "int", nullable: true),
                    WifiPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateDetail");
        }
    }
}
