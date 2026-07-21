using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCambioNombreTablasWarehouses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "warehouse_tercerizada",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "outsourced_warehouses",
                schema: "public",
                columns: table => new
                {
                    outsourced_warehouse_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outsourced_warehouses", x => x.outsourced_warehouse_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_outsourced_warehouse_id",
                schema: "public",
                table: "outsourced_warehouses",
                column: "outsourced_warehouse_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outsourced_warehouses",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "warehouse_tercerizada",
                schema: "public",
                columns: table => new
                {
                    warehouse_tercerizada_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_tercerizada", x => x.warehouse_tercerizada_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_warehouse_tercerizada_id",
                schema: "public",
                table: "warehouse_tercerizada",
                column: "warehouse_tercerizada_id",
                unique: true);
        }
    }
}
