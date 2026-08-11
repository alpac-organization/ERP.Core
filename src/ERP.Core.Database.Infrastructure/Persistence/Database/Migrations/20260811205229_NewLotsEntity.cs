using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewLotsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramos",
                schema: "public");

            migrationBuilder.AddColumn<Guid>(
                name: "LotsId",
                schema: "public",
                table: "warehouse_assignments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LotsId",
                schema: "public",
                table: "stocks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "lots",
                schema: "public",
                columns: table => new
                {
                    tramo_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    section_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    width_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    length_metres = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    nominal_rows = table.Column<int>(type: "integer", nullable: false),
                    nominal_columns = table.Column<int>(type: "integer", nullable: false),
                    allows_stacking = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    status = table.Column<int>(type: "rack_status_enum", nullable: false, defaultValueSql: "'available'::rack_status_enum"),
                    unavailable_reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    status_changed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lots", x => x.tramo_id);
                    table.ForeignKey(
                        name: "FK_lots_sections_section_id",
                        column: x => x.section_id,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tramo_positions",
                schema: "public",
                columns: table => new
                {
                    tramo_position_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    tramo_id = table.Column<Guid>(type: "uuid", nullable: false),
                    row_number = table.Column<int>(type: "integer", nullable: false),
                    column_number = table.Column<int>(type: "integer", nullable: false),
                    position_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    allows_stacking = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_blocked = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    block_reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CurrentStockId = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tramo_positions", x => x.tramo_position_id);
                    table.ForeignKey(
                        name: "FK_tramo_positions_lots_tramo_id",
                        column: x => x.tramo_id,
                        principalSchema: "public",
                        principalTable: "lots",
                        principalColumn: "tramo_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tramo_positions_stocks_CurrentStockId",
                        column: x => x.CurrentStockId,
                        principalSchema: "public",
                        principalTable: "stocks",
                        principalColumn: "stock_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_LotsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "LotsId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "LotsPositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_LotsId",
                schema: "public",
                table: "stocks",
                column: "LotsId");

            migrationBuilder.CreateIndex(
                name: "ix_tramos_section_id",
                schema: "public",
                table: "lots",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "ix_tramos_section_id_code",
                schema: "public",
                table: "lots",
                columns: new[] { "section_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tramo_positions_CurrentStockId",
                schema: "public",
                table: "tramo_positions",
                column: "CurrentStockId");

            migrationBuilder.CreateIndex(
                name: "ix_tramo_positions_tramo_id",
                schema: "public",
                table: "tramo_positions",
                column: "tramo_id");

            migrationBuilder.CreateIndex(
                name: "ix_tramo_positions_tramo_id_position_code",
                schema: "public",
                table: "tramo_positions",
                columns: new[] { "tramo_id", "position_code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_lots_LotsId",
                schema: "public",
                table: "stocks",
                column: "LotsId",
                principalSchema: "public",
                principalTable: "lots",
                principalColumn: "tramo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_lots_LotsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "LotsId",
                principalSchema: "public",
                principalTable: "lots",
                principalColumn: "tramo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "LotsPositionsId",
                principalSchema: "public",
                principalTable: "tramo_positions",
                principalColumn: "tramo_position_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_lots_LotsId",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_lots_LotsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_tramo_positions_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropTable(
                name: "tramo_positions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "lots",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_LotsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropIndex(
                name: "IX_stocks_LotsId",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "LotsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "LotsPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "LotsId",
                schema: "public",
                table: "stocks");

            migrationBuilder.CreateTable(
                name: "Tramos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramos_sections_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "public",
                        principalTable: "sections",
                        principalColumn: "section_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tramos_SectionId",
                schema: "public",
                table: "Tramos",
                column: "SectionId");
        }
    }
}
