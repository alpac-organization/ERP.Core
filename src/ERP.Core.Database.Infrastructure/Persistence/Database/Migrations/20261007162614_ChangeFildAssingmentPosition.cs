using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFildAssingmentPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_section_positions_section_posit~",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.RenameColumn(
                name: "section_position_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "section_id");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_stock_placements_section_position_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "IX_assignment_stock_placements_section_id");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionPositionsId",
                schema: "public",
                table: "assignment_stock_placements",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignment_stock_placements_SectionPositionsId",
                schema: "public",
                table: "assignment_stock_placements",
                column: "SectionPositionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_section_positions_SectionPositi~",
                schema: "public",
                table: "assignment_stock_placements",
                column: "SectionPositionsId",
                principalSchema: "public",
                principalTable: "section_positions",
                principalColumn: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_sections_section_id",
                schema: "public",
                table: "assignment_stock_placements",
                column: "section_id",
                principalSchema: "public",
                principalTable: "sections",
                principalColumn: "section_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_section_positions_SectionPositi~",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropForeignKey(
                name: "FK_assignment_stock_placements_sections_section_id",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropIndex(
                name: "IX_assignment_stock_placements_SectionPositionsId",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.DropColumn(
                name: "SectionPositionsId",
                schema: "public",
                table: "assignment_stock_placements");

            migrationBuilder.RenameColumn(
                name: "section_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "section_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_stock_placements_section_id",
                schema: "public",
                table: "assignment_stock_placements",
                newName: "IX_assignment_stock_placements_section_position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_stock_placements_section_positions_section_posit~",
                schema: "public",
                table: "assignment_stock_placements",
                column: "section_position_id",
                principalSchema: "public",
                principalTable: "section_positions",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
