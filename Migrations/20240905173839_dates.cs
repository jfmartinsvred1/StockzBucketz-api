using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stockz_bucketz_api.Migrations
{
    /// <inheritdoc />
    public partial class dates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyRecord_Portfolios_PortfolioId",
                table: "MonthlyRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyRecord",
                table: "MonthlyRecord");

            migrationBuilder.RenameTable(
                name: "MonthlyRecord",
                newName: "MonthlyRecords");

            migrationBuilder.RenameIndex(
                name: "IX_MonthlyRecord_PortfolioId",
                table: "MonthlyRecords",
                newName: "IX_MonthlyRecords_PortfolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyRecords",
                table: "MonthlyRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyRecords_Portfolios_PortfolioId",
                table: "MonthlyRecords",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyRecords_Portfolios_PortfolioId",
                table: "MonthlyRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyRecords",
                table: "MonthlyRecords");

            migrationBuilder.RenameTable(
                name: "MonthlyRecords",
                newName: "MonthlyRecord");

            migrationBuilder.RenameIndex(
                name: "IX_MonthlyRecords_PortfolioId",
                table: "MonthlyRecord",
                newName: "IX_MonthlyRecord_PortfolioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyRecord",
                table: "MonthlyRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyRecord_Portfolios_PortfolioId",
                table: "MonthlyRecord",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "PortfolioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
