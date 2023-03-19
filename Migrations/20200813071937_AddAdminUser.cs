using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelAdmin.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Accesstime = table.Column<DateTime>(nullable: true),
                    RememberMe = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhotoLists",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Accesstime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoLists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phonumber = table.Column<string>(nullable: true),
                    RoomType = table.Column<string>(nullable: true),
                    NoOfGuest = table.Column<int>(nullable: false),
                    NoOfRoom = table.Column<int>(nullable: false),
                    NoOfNight = table.Column<int>(nullable: false),
                    Accesstime = table.Column<DateTime>(nullable: true),
                    CheckInDate = table.Column<DateTime>(nullable: true),
                    CheckOutDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "PhotoLists");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
