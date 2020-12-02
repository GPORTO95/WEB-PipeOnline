using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class addFieldsStatusPhase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhaseProspect",
                table: "Prospects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Prospects",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhaseProspect",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Prospects");
        }
    }
}
