using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApi.Migrations
{
    public partial class updateroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
