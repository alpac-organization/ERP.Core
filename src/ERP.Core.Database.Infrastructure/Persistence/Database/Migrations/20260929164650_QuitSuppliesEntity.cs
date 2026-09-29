using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class QuitSuppliesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_orders_operational_orders_operational_order_id",
                schema: "public",
                table: "services_orders");

            migrationBuilder.DropTable(
                name: "unloading_supplies",
                schema: "public");

            migrationBuilder.DropTable(
                name: "supplies",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "operational_order_id",
                schema: "public",
                table: "services_orders",
                newName: "OperationalOrderId");

            migrationBuilder.RenameIndex(
                name: "ix_services_orders_operational_order_id",
                schema: "public",
                table: "services_orders",
                newName: "IX_services_orders_OperationalOrderId");

            migrationBuilder.AlterColumn<Guid>(
                name: "OperationalOrderId",
                schema: "public",
                table: "services_orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "has_enclosure_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_services_orders_operational_orders_OperationalOrderId",
                schema: "public",
                table: "services_orders",
                column: "OperationalOrderId",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_orders_operational_orders_OperationalOrderId",
                schema: "public",
                table: "services_orders");

            migrationBuilder.DropColumn(
                name: "has_enclosure_assigned",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.RenameColumn(
                name: "OperationalOrderId",
                schema: "public",
                table: "services_orders",
                newName: "operational_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_services_orders_OperationalOrderId",
                schema: "public",
                table: "services_orders",
                newName: "ix_services_orders_operational_order_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "operational_order_id",
                schema: "public",
                table: "services_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "supplies",
                schema: "public",
                columns: table => new
                {
                    supplies_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplies", x => x.supplies_id);
                });

            migrationBuilder.CreateTable(
                name: "unloading_supplies",
                schema: "public",
                columns: table => new
                {
                    unloading_supplies_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    supplies_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    quantity = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_supplies", x => x.unloading_supplies_id);
                    table.ForeignKey(
                        name: "FK_unloading_supplies_supplies_supplies_id",
                        column: x => x.supplies_id,
                        principalSchema: "public",
                        principalTable: "supplies",
                        principalColumn: "supplies_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unloading_supplies_unloading_details_unloading_details_id",
                        column: x => x.unloading_details_id,
                        principalSchema: "public",
                        principalTable: "unloading_details",
                        principalColumn: "unloading_details_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_unloading_supplies_supplies_id",
                schema: "public",
                table: "unloading_supplies",
                column: "supplies_id");

            migrationBuilder.CreateIndex(
                name: "IX_unloading_supplies_unloading_details_id",
                schema: "public",
                table: "unloading_supplies",
                column: "unloading_details_id");

            migrationBuilder.AddForeignKey(
                name: "FK_services_orders_operational_orders_operational_order_id",
                schema: "public",
                table: "services_orders",
                column: "operational_order_id",
                principalSchema: "public",
                principalTable: "operational_orders",
                principalColumn: "operational_order_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
