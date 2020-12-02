using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class AddColumnsInterlocutorDecisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Decision",
                table: "Prospects",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Interlocutor",
                table: "Prospects",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decision",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "Interlocutor",
                table: "Prospects");
        }
    }
}
