using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    public partial class updaterelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingRoomToUser",
                table: "BookingRoomToUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingRoomToUser",
                table: "BookingRoomToUser",
                columns: new[] { "UserId", "RoomId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingRoomToUser",
                table: "BookingRoomToUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingRoomToUser",
                table: "BookingRoomToUser",
                columns: new[] { "UserId", "RoomId", "HotelId" });
        }
    }
}
