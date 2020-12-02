using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dev.Data.Migrations
{
    public partial class addTableCustomerAndSegment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Prospects",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    SegmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospects_CustomerId",
                table: "Prospects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SegmentId",
                table: "Customers",
                column: "SegmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospects_Customers_CustomerId",
                table: "Prospects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prospects_Customers_CustomerId",
                table: "Prospects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropIndex(
                name: "IX_Prospects_CustomerId",
                table: "Prospects");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Prospects");
        }
    }
}
