using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class AddReasonAndReasonText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reason",
                table: "Prospects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonText",
                table: "Prospects",
                type: "varchar(30)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "ReasonText",
                table: "Prospects");
        }
    }
}
