using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AssignPositionWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock_placements",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "assignment_stock_placements",
                schema: "public",
                columns: table => new
                {
                    assignment_stock_placement_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rack_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lot_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    section_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    placed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    placed_by_user_id = table.Column<Guid>(type: "uuid", maxLength: 100, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_stock_placements", x => x.assignment_stock_placement_id);
                    table.ForeignKey(
                        name: "FK_assignment_stock_placements_lots_positions_lot_position_id",
                        column: x => x.lot_position_id,
                        principalSchema: "public",
                        principalTable: "lots_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assignment_stock_placements_rack_positions_rack_position_id",
                        column: x => x.rack_position_id,
                        principalSchema: "public",
                        principalTable: "rack_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assignment_stock_placements_section_positions_rack_position~",
                        column: x => x.rack_position_id,
                        principalSchema: "public",
                        principalTable: "section_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assignment_stock_placements_stocks_stock_id",
                        column: x => x.stock_id,
                        principalSchema: "public",
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignment_stock_placements_lot_position_id",
                schema: "public",
                table: "assignment_stock_placements",
                column: "lot_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_stock_placements_rack_position_id",
                schema: "public",
                table: "assignment_stock_placements",
                column: "rack_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_stock_placements_stock_id",
                schema: "public",
                table: "assignment_stock_placements",
                column: "stock_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignment_stock_placements",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "stock_placements",
                schema: "public",
                columns: table => new
                {
                    stock_placement_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    lot_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    placed_by_memory_item_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    SectionPositionId = table.Column<Guid>(type: "uuid", nullable: true),
                    stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vacated_by_memory_item_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    placed_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    placed_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    placed_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vacated_at_date = table.Column<DateOnly>(type: "date", nullable: true),
                    vacated_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    vacated_by_user_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_placements", x => x.stock_placement_id);
                    table.CheckConstraint("ck_stock_placements_exactly_one_position", "(rack_position_id IS NOT NULL AND lot_position_id IS NULL) OR (rack_position_id IS NULL AND lot_position_id IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_stock_placements_lots_positions_lot_position_id",
                        column: x => x.lot_position_id,
                        principalSchema: "public",
                        principalTable: "lots_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_placements_rack_positions_rack_position_id",
                        column: x => x.rack_position_id,
                        principalSchema: "public",
                        principalTable: "rack_positions",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_placements_reassignment_memory_items_placed_by_memory~",
                        column: x => x.placed_by_memory_item_id,
                        principalSchema: "public",
                        principalTable: "reassignment_memory_items",
                        principalColumn: "reassignment_memory_item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_placements_reassignment_memory_items_vacated_by_memor~",
                        column: x => x.vacated_by_memory_item_id,
                        principalSchema: "public",
                        principalTable: "reassignment_memory_items",
                        principalColumn: "reassignment_memory_item_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_placements_section_positions_SectionPositionId",
                        column: x => x.SectionPositionId,
                        principalSchema: "public",
                        principalTable: "section_positions",
                        principalColumn: "position_id");
                    table.ForeignKey(
                        name: "FK_stock_placements_stocks_stock_id",
                        column: x => x.stock_id,
                        principalSchema: "public",
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_stock_placements_lot_position_id",
                schema: "public",
                table: "stock_placements",
                column: "lot_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_placements_placed_by_memory_item_id",
                schema: "public",
                table: "stock_placements",
                column: "placed_by_memory_item_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_placements_rack_position_id",
                schema: "public",
                table: "stock_placements",
                column: "rack_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_stock_placements_SectionPositionId",
                schema: "public",
                table: "stock_placements",
                column: "SectionPositionId");

            migrationBuilder.CreateIndex(
                name: "ix_stock_placements_stock_id",
                schema: "public",
                table: "stock_placements",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_placements_vacated_at_date",
                schema: "public",
                table: "stock_placements",
                column: "vacated_at_date");

            migrationBuilder.CreateIndex(
                name: "ix_stock_placements_vacated_at_time",
                schema: "public",
                table: "stock_placements",
                column: "vacated_at_time");

            migrationBuilder.CreateIndex(
                name: "IX_stock_placements_vacated_by_memory_item_id",
                schema: "public",
                table: "stock_placements",
                column: "vacated_by_memory_item_id");
        }
    }
}
