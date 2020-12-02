using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class AddTableEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Prospects",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_EmployeeId",
                table: "Prospects",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_Employee_EmployeeId",
                table: "Prospects",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_Employee_EmployeeId",
                table: "Prospects");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_EmployeeId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Prospects");
        }
    }
}
