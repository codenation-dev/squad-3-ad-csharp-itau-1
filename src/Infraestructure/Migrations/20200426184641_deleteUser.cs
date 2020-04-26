using Microsoft.EntityFrameworkCore.Migrations;

namespace TryLog.Infraestructure.Migrations
{
    public partial class deleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user",
                table: "log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "user",
                table: "log",
                type: "integer",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
