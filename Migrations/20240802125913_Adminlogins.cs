using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlinereservation.Migrations
{
    /// <inheritdoc />
    public partial class Adminlogins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAdminLogin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAdminLogin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "TblPlaneInfo",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APlaneName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPlaneInfo", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "TblUserLogin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EmaiL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TblFlightBook",
                columns: table => new
                {
                    bid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    To = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false),
                    PlaneInfoPlaneId = table.Column<int>(type: "int", nullable: false),
                    SeatType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFlightBook", x => x.bid);
                    table.ForeignKey(
                        name: "FK_TblFlightBook_TblPlaneInfo_PlaneInfoPlaneId",
                        column: x => x.PlaneInfoPlaneId,
                        principalTable: "TblPlaneInfo",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblFlightBook_PlaneInfoPlaneId",
                table: "TblFlightBook",
                column: "PlaneInfoPlaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAdminLogin");

            migrationBuilder.DropTable(
                name: "TblFlightBook");

            migrationBuilder.DropTable(
                name: "TblUserLogin");

            migrationBuilder.DropTable(
                name: "TblPlaneInfo");
        }
    }
}
