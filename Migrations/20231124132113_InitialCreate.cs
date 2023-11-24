using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStationery.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "PrintingStationery",
                columns: table => new
                {
                    PrintingStationeryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsNumbered = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsWithCarbon = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsContinuos = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoOfPagesInOneBook = table.Column<int>(type: "INTEGER", nullable: true),
                    NoOfCopies = table.Column<int>(type: "INTEGER", nullable: true),
                    TenantId = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintingStationery", x => x.PrintingStationeryId);
                });

            migrationBuilder.CreateTable(
                name: "StationeryQuote",
                columns: table => new
                {
                    StationeryQuoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrintingStationeryId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuoteNo = table.Column<string>(type: "TEXT", nullable: true),
                    ReferenceNo = table.Column<string>(type: "TEXT", nullable: true),
                    QuotedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuotePerCopyPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    QuotePerBookPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    ApprovedPerCopyPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    ApprovedPerBookPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    MinmumOrderQuantity = table.Column<decimal>(type: "TEXT", nullable: true),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: true),
                    TenantId = table.Column<string>(type: "TEXT", nullable: true),
                    ApprovalState = table.Column<int>(type: "INTEGER", nullable: false),
                    ApprovedById = table.Column<int>(type: "INTEGER", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationeryQuote", x => x.StationeryQuoteId);
                    table.ForeignKey(
                        name: "FK_StationeryQuote_ApplicationUser_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StationeryQuote_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "BranchId");
                    table.ForeignKey(
                        name: "FK_StationeryQuote_PrintingStationery_PrintingStationeryId",
                        column: x => x.PrintingStationeryId,
                        principalTable: "PrintingStationery",
                        principalColumn: "PrintingStationeryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StationeryQuote_ApprovedById",
                table: "StationeryQuote",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_StationeryQuote_BranchId",
                table: "StationeryQuote",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_StationeryQuote_PrintingStationeryId",
                table: "StationeryQuote",
                column: "PrintingStationeryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationeryQuote");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "PrintingStationery");
        }
    }
}
