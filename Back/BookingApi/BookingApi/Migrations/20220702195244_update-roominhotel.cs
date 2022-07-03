using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    public partial class updateroominhotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAvailabes");

            migrationBuilder.RenameColumn(
                name: "roomNumbers",
                table: "Rooms",
                newName: "roomNumber");

            migrationBuilder.CreateTable(
                name: "RoomsInHotel",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsInHotel", x => new { x.HotelId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomsInHotel_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsInHotel_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomsInHotel_RoomId",
                table: "RoomsInHotel",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomsInHotel");

            migrationBuilder.RenameColumn(
                name: "roomNumber",
                table: "Rooms",
                newName: "roomNumbers");

            migrationBuilder.CreateTable(
                name: "RoomAvailabes",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isAvalable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAvailabes", x => new { x.HotelId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomAvailabes_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAvailabes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAvailabes_RoomId",
                table: "RoomAvailabes",
                column: "RoomId");
        }
    }
}
