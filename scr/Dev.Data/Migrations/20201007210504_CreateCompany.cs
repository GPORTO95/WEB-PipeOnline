using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class CreateCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdBranch",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "Prospects");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Prospects",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCompany = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdBranch = table.Column<string>(type: "varchar(2)", nullable: false),
                    NameCompany = table.Column<string>(type: "varchar(50)", nullable: false),
                    NameBranch = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyId",
                table: "Prospects",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_Companies_CompanyId",
                table: "Prospects",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_Companies_CompanyId",
                table: "Prospects");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_CompanyId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Prospects");

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
    }
}
