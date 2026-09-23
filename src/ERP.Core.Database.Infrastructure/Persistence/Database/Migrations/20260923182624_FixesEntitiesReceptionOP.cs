using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixesEntitiesReceptionOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "container_exit_date",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "container_exit_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "driver_license",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "driver_name",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "duca_numbers",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "evidence_urls",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "transport_unit",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "transportista",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_by_user_name",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_date",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "vehicle_chassis_number",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "vehicle_exit_date",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "vehicle_exit_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "vehicle_plate_number",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "reception_id",
                schema: "public",
                table: "operational_orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customs_branch_name",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "reception_transport_entrance",
                schema: "public",
                columns: table => new
                {
                    reception_transport_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicle_plate_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    vehicle_chassis_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    driver_license = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    transportista = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    driver_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    transport_unit = table.Column<int>(type: "transport_unit_enum", nullable: false),
                    vehicle_exit_date = table.Column<DateOnly>(type: "date", nullable: true),
                    vehicle_exit_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    container_exit_date = table.Column<DateOnly>(type: "date", nullable: true),
                    container_exit_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    additional_data = table.Column<JsonNode>(type: "jsonb", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception_transport_entrance", x => x.reception_transport_entrance_id);
                    table.ForeignKey(
                        name: "FK_reception_transport_entrance_reception_entrance_reception_t~",
                        column: x => x.reception_transport_entrance_id,
                        principalSchema: "public",
                        principalTable: "reception_entrance",
                        principalColumn: "reception_entrance_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomsBranchesId");

            migrationBuilder.CreateIndex(
                name: "ix_operational_orders_reception_id",
                schema: "public",
                table: "operational_orders",
                column: "reception_id");

            migrationBuilder.AddForeignKey(
                name: "FK_operational_orders_reception_entrance_reception_id",
                schema: "public",
                table: "operational_orders",
                column: "reception_id",
                principalSchema: "public",
                principalTable: "reception_entrance",
                principalColumn: "reception_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomsBranchesId",
                principalSchema: "public",
                principalTable: "customs_branches",
                principalColumn: "custom_branch_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operational_orders_reception_entrance_reception_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropTable(
                name: "reception_transport_entrance",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_reception_entrance_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropIndex(
                name: "ix_operational_orders_reception_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "reception_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.AddColumn<DateOnly>(
                name: "container_exit_date",
                schema: "public",
                table: "reception_entrance",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "container_exit_time",
                schema: "public",
                table: "reception_entrance",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "driver_license",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "driver_name",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<List<string>>(
                name: "duca_numbers",
                schema: "public",
                table: "reception_entrance",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "evidence_urls",
                schema: "public",
                table: "reception_entrance",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "transport_unit",
                schema: "public",
                table: "reception_entrance",
                type: "transport_unit_enum",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "transportista",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_id",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_name",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "updated_date",
                schema: "public",
                table: "reception_entrance",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "updated_time",
                schema: "public",
                table: "reception_entrance",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vehicle_chassis_number",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "vehicle_exit_date",
                schema: "public",
                table: "reception_entrance",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "vehicle_exit_time",
                schema: "public",
                table: "reception_entrance",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vehicle_plate_number",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "customs_branch_name",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
