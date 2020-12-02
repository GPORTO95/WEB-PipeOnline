using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class addManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProspectEmployees",
                columns: table => new
                {
                    ProspectId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectEmployees", x => new { x.ProspectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProspectEmployees_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProspectEmployees_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProspectEmployees_EmployeeId",
                table: "ProspectEmployees",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProspectEmployees");
        }
    }
}
