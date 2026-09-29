using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AssignmentSimplification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignment_enclosure",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "has_collaborators_assigned",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "has_enclosure_assigned",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "has_machinery_assigned",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.AddColumn<int>(
                name: "destination_type",
                schema: "public",
                table: "assignment_operational",
                type: "destination_type_enum",
                nullable: false,
                defaultValueSql: "'warehouse'::destination_type_enum");

            migrationBuilder.AddColumn<string>(
                name: "merchandise",
                schema: "public",
                table: "assignment_operational",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "merchandise_description",
                schema: "public",
                table: "assignment_operational",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "observations",
                schema: "public",
                table: "assignment_operational",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "warehosue_id",
                schema: "public",
                table: "assignment_operational",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignment_operational_warehosue_id",
                schema: "public",
                table: "assignment_operational",
                column: "warehosue_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_operational_warehouses_warehosue_id",
                schema: "public",
                table: "assignment_operational",
                column: "warehosue_id",
                principalSchema: "public",
                principalTable: "warehouses",
                principalColumn: "warehouse_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_operational_warehouses_warehosue_id",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropIndex(
                name: "IX_assignment_operational_warehosue_id",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "destination_type",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "merchandise",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "merchandise_description",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "observations",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "warehosue_id",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.AddColumn<bool>(
                name: "has_collaborators_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "has_enclosure_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "has_machinery_assigned",
                schema: "public",
                table: "operational_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "assignment_enclosure",
                schema: "public",
                columns: table => new
                {
                    assignment_enclosure_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    AssignmentOperationalId = table.Column<Guid>(type: "uuid", nullable: false),
                    warehosue_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    destination_type = table.Column<int>(type: "destination_type_enum", nullable: false, defaultValueSql: "'warehouse'::destination_type_enum"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    merchandise = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    merchandise_description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    observations = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignment_enclosure", x => x.assignment_enclosure_id);
                    table.ForeignKey(
                        name: "FK_assignment_enclosure_assignment_operational_AssignmentOpera~",
                        column: x => x.AssignmentOperationalId,
                        principalSchema: "public",
                        principalTable: "assignment_operational",
                        principalColumn: "assignment_operational_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assignment_enclosure_warehouses_warehosue_id",
                        column: x => x.warehosue_id,
                        principalSchema: "public",
                        principalTable: "warehouses",
                        principalColumn: "warehouse_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignment_enclosure_AssignmentOperationalId",
                schema: "public",
                table: "assignment_enclosure",
                column: "AssignmentOperationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assignment_enclosure_warehosue_id",
                schema: "public",
                table: "assignment_enclosure",
                column: "warehosue_id");
        }
    }
}
