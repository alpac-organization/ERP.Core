using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class StocksForUnloading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_lots_LotsId",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_rack_positions_rack_position_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_stocks_sections_section_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_tramo_positions_stocks_CurrentStockId",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropIndex(
                name: "IX_tramo_positions_CurrentStockId",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropIndex(
                name: "IX_stocks_LotsId",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_stocks_section_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "CurrentStockId",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "LotsId",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "section_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.RenameColumn(
                name: "rack_position_id",
                schema: "public",
                table: "stocks",
                newName: "merchandise_id");

            migrationBuilder.RenameIndex(
                name: "IX_stocks_rack_position_id",
                schema: "public",
                table: "stocks",
                newName: "IX_stocks_merchandise_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_merchandise_merchandise_id",
                schema: "public",
                table: "stocks",
                column: "merchandise_id",
                principalSchema: "public",
                principalTable: "merchandise",
                principalColumn: "merchandise_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_merchandise_merchandise_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.RenameColumn(
                name: "merchandise_id",
                schema: "public",
                table: "stocks",
                newName: "rack_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_stocks_merchandise_id",
                schema: "public",
                table: "stocks",
                newName: "IX_stocks_rack_position_id");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentStockId",
                schema: "public",
                table: "tramo_positions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LotsId",
                schema: "public",
                table: "stocks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "section_id",
                schema: "public",
                table: "stocks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tramo_positions_CurrentStockId",
                schema: "public",
                table: "tramo_positions",
                column: "CurrentStockId");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_LotsId",
                schema: "public",
                table: "stocks",
                column: "LotsId");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_section_id",
                schema: "public",
                table: "stocks",
                column: "section_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_lots_LotsId",
                schema: "public",
                table: "stocks",
                column: "LotsId",
                principalSchema: "public",
                principalTable: "lots",
                principalColumn: "tramo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_rack_positions_rack_position_id",
                schema: "public",
                table: "stocks",
                column: "rack_position_id",
                principalSchema: "public",
                principalTable: "rack_positions",
                principalColumn: "rack_position_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_sections_section_id",
                schema: "public",
                table: "stocks",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tramo_positions_stocks_CurrentStockId",
                schema: "public",
                table: "tramo_positions",
                column: "CurrentStockId",
                principalSchema: "public",
                principalTable: "stocks",
                principalColumn: "stock_id");
        }
    }
}
