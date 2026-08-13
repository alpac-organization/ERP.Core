using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class PositionsRacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_racks_racks_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.RenameColumn(
                name: "racks_id",
                schema: "public",
                table: "stocks",
                newName: "rack_position_id");

            migrationBuilder.RenameIndex(
                name: "IX_stocks_racks_id",
                schema: "public",
                table: "stocks",
                newName: "IX_stocks_rack_position_id");

            migrationBuilder.AddColumn<Guid>(
                name: "RackPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "rack_positions",
                schema: "public",
                columns: table => new
                {
                    rack_position_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    rack_id = table.Column<Guid>(type: "uuid", nullable: false),
                    position_number = table.Column<int>(type: "integer", nullable: false),
                    position_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_blocked = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    block_reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rack_positions", x => x.rack_position_id);
                    table.ForeignKey(
                        name: "FK_rack_positions_racks_rack_id",
                        column: x => x.rack_id,
                        principalSchema: "public",
                        principalTable: "racks",
                        principalColumn: "rack_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_assignments_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "RackPositionsId");

            migrationBuilder.CreateIndex(
                name: "ix_rack_positions_rack_id",
                schema: "public",
                table: "rack_positions",
                column: "rack_id");

            migrationBuilder.CreateIndex(
                name: "ix_rack_positions_rack_id_position_code",
                schema: "public",
                table: "rack_positions",
                columns: new[] { "rack_id", "position_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_rack_positions_rack_id_position_number",
                schema: "public",
                table: "rack_positions",
                columns: new[] { "rack_id", "position_number" },
                unique: true);

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
                name: "FK_warehouse_assignments_rack_positions_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments",
                column: "RackPositionsId",
                principalSchema: "public",
                principalTable: "rack_positions",
                principalColumn: "rack_position_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_rack_positions_rack_position_id",
                schema: "public",
                table: "stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_warehouse_assignments_rack_positions_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropTable(
                name: "rack_positions",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_warehouse_assignments_RackPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.DropColumn(
                name: "RackPositionsId",
                schema: "public",
                table: "warehouse_assignments");

            migrationBuilder.RenameColumn(
                name: "rack_position_id",
                schema: "public",
                table: "stocks",
                newName: "racks_id");

            migrationBuilder.RenameIndex(
                name: "IX_stocks_rack_position_id",
                schema: "public",
                table: "stocks",
                newName: "IX_stocks_racks_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_racks_racks_id",
                schema: "public",
                table: "stocks",
                column: "racks_id",
                principalSchema: "public",
                principalTable: "racks",
                principalColumn: "rack_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
