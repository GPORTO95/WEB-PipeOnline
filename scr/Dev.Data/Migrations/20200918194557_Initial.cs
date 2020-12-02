using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prospects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    ProActive = table.Column<string>(type: "varchar(1)", nullable: false),
                    Competition = table.Column<string>(type: "varchar(1)", nullable: false),
                    International = table.Column<string>(type: "varchar(1)", nullable: false),
                    AutomaticPhase = table.Column<string>(type: "varchar(2)", nullable: true),
                    AutomaticStatus = table.Column<string>(type: "varchar(2)", nullable: true),
                    Opening = table.Column<DateTime>(nullable: false),
                    FirstBriefing = table.Column<DateTime>(nullable: true),
                    FirstProposal = table.Column<DateTime>(nullable: true),
                    ExpectedSale = table.Column<DateTime>(nullable: true),
                    DeliveryJob = table.Column<DateTime>(nullable: true),
                    FirstSale = table.Column<DateTime>(nullable: true),
                    ValueEstimated = table.Column<double>(nullable: true),
                    ValueProposal = table.Column<double>(nullable: true),
                    ValueApproved = table.Column<double>(nullable: true),
                    ValueSold = table.Column<double>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prospects_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CategoryId",
                table: "Prospects",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prospects");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
