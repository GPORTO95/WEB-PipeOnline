using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dev.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompany = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdBranch = table.Column<string>(type: "varchar(2)", nullable: false),
                    NameCompany = table.Column<string>(type: "varchar(50)", nullable: false),
                    NameBranch = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    SegmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    IdPsp = table.Column<string>(type: "varchar(10)", nullable: false),
                    ProActive = table.Column<string>(type: "varchar(1)", nullable: false),
                    Competition = table.Column<string>(type: "varchar(1)", nullable: false),
                    NameCompetitors = table.Column<string>(type: "varchar(200)", nullable: true),
                    International = table.Column<string>(type: "varchar(1)", nullable: false),
                    Status = table.Column<string>(type: "varchar(3)", nullable: false),
                    AutomaticPhase = table.Column<string>(type: "varchar(2)", nullable: true),
                    AutomaticStatus = table.Column<string>(type: "varchar(2)", nullable: true),
                    Interlocutor = table.Column<string>(type: "varchar(200)", nullable: true),
                    Decision = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReasonText = table.Column<string>(type: "varchar(30)", nullable: true),
                    Opening = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstBriefing = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstProposal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedSale = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryJob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSale = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValueEstimated = table.Column<double>(type: "float", nullable: true),
                    ValueProposal = table.Column<double>(type: "float", nullable: true),
                    ValueApproved = table.Column<double>(type: "float", nullable: true),
                    ValueSold = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PhaseProspect = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prospects_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prospects_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProspectEmployees",
                columns: table => new
                {
                    ProspectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectEmployees", x => new { x.ProspectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProspectEmployees_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProspectEmployees_Prospects_ProspectId",
                        column: x => x.ProspectId,
                        principalTable: "Prospects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SegmentId",
                table: "Customers",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectEmployees_EmployeeId",
                table: "ProspectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CategoryId",
                table: "Prospects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CompanyId",
                table: "Prospects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CustomerId",
                table: "Prospects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_EmployeeId",
                table: "Prospects",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProspectEmployees");

            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Segments");
        }
    }
}
