using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class TimeInventoryCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "inventory_outputs",
                newName: "deleted_at");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "public",
                table: "inventory_outputs",
                type: "inventory_outputs_status_enum",
                nullable: false,
                defaultValueSql: "'output_pending'::inventory_outputs_status_enum",
                oldClrType: typeof(int),
                oldType: "inventory_outputs_status_enum",
                oldDefaultValueSql: "'outputpending'::inventory_outputs_status_enum");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "inventory_outputs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "inventory_outputs");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "inventory_outputs",
                newName: "DeletedAt");

            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "public",
                table: "inventory_outputs",
                type: "inventory_outputs_status_enum",
                nullable: false,
                defaultValueSql: "'outputpending'::inventory_outputs_status_enum",
                oldClrType: typeof(int),
                oldType: "inventory_outputs_status_enum",
                oldDefaultValueSql: "'output_pending'::inventory_outputs_status_enum");
        }
    }
}
