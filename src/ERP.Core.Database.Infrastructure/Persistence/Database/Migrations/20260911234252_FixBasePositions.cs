using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixBasePositions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lots_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_rack_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropForeignKey(
                name: "FK_section_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropTable(
                name: "base_posiions_pallets",
                schema: "public");

            migrationBuilder.AddColumn<bool>(
                name: "allows_stocking",
                schema: "public",
                table: "section_positions",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "column",
                schema: "public",
                table: "section_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "section_positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "section_positions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "level",
                schema: "public",
                table: "section_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "section_positions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "position_code",
                schema: "public",
                table: "section_positions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "row",
                schema: "public",
                table: "section_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "section_positions",
                type: "rack_status_enum",
                nullable: false,
                defaultValueSql: "'available'::rack_status_enum");

            migrationBuilder.AddColumn<bool>(
                name: "allows_stocking",
                schema: "public",
                table: "rack_positions",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "column",
                schema: "public",
                table: "rack_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "rack_positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "rack_positions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "level",
                schema: "public",
                table: "rack_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "rack_positions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "position_code",
                schema: "public",
                table: "rack_positions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "row",
                schema: "public",
                table: "rack_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "rack_positions",
                type: "rack_status_enum",
                nullable: false,
                defaultValueSql: "'available'::rack_status_enum");

            migrationBuilder.AddColumn<bool>(
                name: "allows_stocking",
                schema: "public",
                table: "lots_positions",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "column",
                schema: "public",
                table: "lots_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "lots_positions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                schema: "public",
                table: "lots_positions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "level",
                schema: "public",
                table: "lots_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "lots_positions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "position_code",
                schema: "public",
                table: "lots_positions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "row",
                schema: "public",
                table: "lots_positions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "lots_positions",
                type: "rack_status_enum",
                nullable: false,
                defaultValueSql: "'available'::rack_status_enum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allows_stocking",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "column",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "level",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "position_code",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "row",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "section_positions");

            migrationBuilder.DropColumn(
                name: "allows_stocking",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "column",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "level",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "position_code",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "row",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "rack_positions");

            migrationBuilder.DropColumn(
                name: "allows_stocking",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "column",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "level",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "position_code",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "row",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "lots_positions");

            migrationBuilder.CreateTable(
                name: "base_posiions_pallets",
                schema: "public",
                columns: table => new
                {
                    position_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    allows_stocking = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    column = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    level = table.Column<int>(type: "integer", nullable: false),
                    observations = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    position_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    row = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "rack_status_enum", nullable: false, defaultValueSql: "'available'::rack_status_enum")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_base_posiions_pallets", x => x.position_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_lots_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "lots_positions",
                column: "position_id",
                principalSchema: "public",
                principalTable: "base_posiions_pallets",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rack_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "rack_positions",
                column: "position_id",
                principalSchema: "public",
                principalTable: "base_posiions_pallets",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_section_positions_base_posiions_pallets_position_id",
                schema: "public",
                table: "section_positions",
                column: "position_id",
                principalSchema: "public",
                principalTable: "base_posiions_pallets",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
