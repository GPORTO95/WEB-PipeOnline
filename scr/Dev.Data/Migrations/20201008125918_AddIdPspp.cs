using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class AddIdPspp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdPsp",
                table: "Prospects",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPsp",
                table: "Prospects");
        }
    }
}
