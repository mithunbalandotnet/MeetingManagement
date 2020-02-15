using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingManagement.DL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Attendee 1" },
                    { 2, "Attendee 2" },
                    { 3, "Attendee 3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "pass1", "user1" },
                    { 2, "pass2", "user2" },
                    { 3, "pass3", "user3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
