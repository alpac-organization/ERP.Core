using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class PositionReserved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_reserved",
                schema: "public",
                table: "tramo_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "target_lot_position_id",
                schema: "public",
                table: "reassignment_memory_items",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "target_rack_position_id",
                schema: "public",
                table: "reassignment_memory_items",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_reserved",
                schema: "public",
                table: "rack_positions",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_reserved",
                schema: "public",
                table: "tramo_positions");

            migrationBuilder.DropColumn(
                name: "target_lot_position_id",
                schema: "public",
                table: "reassignment_memory_items");

            migrationBuilder.DropColumn(
                name: "target_rack_position_id",
                schema: "public",
                table: "reassignment_memory_items");

            migrationBuilder.DropColumn(
                name: "is_reserved",
                schema: "public",
                table: "rack_positions");
        }
    }
}
