using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlinereservation.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
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
                name: "TblAeroPlaneInfo",
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
                    table.PrimaryKey("PK_TblAeroPlaneInfo", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "TblUserLogin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EmaiL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CPassword = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NIC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    usertype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TblFlightReservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResFrom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResTo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResDepDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ResReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResReturnTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    TripType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Planeid = table.Column<int>(type: "int", nullable: false),
                    SeatType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ResPlane = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFlightReservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_TblFlightReservation_TblAeroPlaneInfo_Planeid",
                        column: x => x.Planeid,
                        principalTable: "TblAeroPlaneInfo",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblFlightBook",
                columns: table => new
                {
                    BokId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BokCusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BokCusAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BokCusEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BokCusSeat = table.Column<int>(type: "int", nullable: false),
                    BokCusPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BokCusNic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResId = table.Column<int>(type: "int", nullable: false),
                    FlightReservationReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFlightBook", x => x.BokId);
                    table.ForeignKey(
                        name: "FK_TblFlightBook_TblFlightReservation_FlightReservationReservationId",
                        column: x => x.FlightReservationReservationId,
                        principalTable: "TblFlightReservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblFlightBook_FlightReservationReservationId",
                table: "TblFlightBook",
                column: "FlightReservationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_TblFlightReservation_Planeid",
                table: "TblFlightReservation",
                column: "Planeid");
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
                name: "TblFlightReservation");

            migrationBuilder.DropTable(
                name: "TblAeroPlaneInfo");
        }
    }
}
