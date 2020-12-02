using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class AddCompanyBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdBranch",
                table: "Prospects",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCompany",
                table: "Prospects",
                type: "varchar(2)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBranch",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Prospects");
        }
    }
}
