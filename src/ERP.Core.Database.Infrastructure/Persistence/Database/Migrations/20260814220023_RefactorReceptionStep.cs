using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RefactorReceptionStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "container_number",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "container_number",
                schema: "public",
                table: "customs_declaration_details");

            migrationBuilder.RenameColumn(
                name: "transport_unit_exit_time",
                schema: "public",
                table: "reception_entrance",
                newName: "vehicle_exit_time");

            migrationBuilder.RenameColumn(
                name: "transport_unit_exit_date",
                schema: "public",
                table: "reception_entrance",
                newName: "vehicle_exit_date");

            migrationBuilder.RenameColumn(
                name: "trailer_chassis",
                schema: "public",
                table: "reception_entrance",
                newName: "vehicle_plate_number");

            migrationBuilder.RenameColumn(
                name: "plate_number",
                schema: "public",
                table: "reception_entrance",
                newName: "vehicle_chassis_number");

            migrationBuilder.RenameColumn(
                name: "aduana",
                schema: "public",
                table: "reception_entrance",
                newName: "container_number");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomBranchId",
                schema: "public",
                table: "reception_entrance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "seal_evidence",
                schema: "public",
                table: "reception_entrance",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "customs_branches",
                schema: "public",
                columns: table => new
                {
                    custom_branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customs_branches", x => x.custom_branch_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_CustomBranchId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomBranchId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomBranchId",
                principalSchema: "public",
                principalTable: "customs_branches",
                principalColumn: "custom_branch_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomBranchId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropTable(
                name: "customs_branches",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_reception_entrance_CustomBranchId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "CustomBranchId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "container_exit_date",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "container_exit_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "seal_evidence",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.RenameColumn(
                name: "vehicle_plate_number",
                schema: "public",
                table: "reception_entrance",
                newName: "trailer_chassis");

            migrationBuilder.RenameColumn(
                name: "vehicle_exit_time",
                schema: "public",
                table: "reception_entrance",
                newName: "transport_unit_exit_time");

            migrationBuilder.RenameColumn(
                name: "vehicle_exit_date",
                schema: "public",
                table: "reception_entrance",
                newName: "transport_unit_exit_date");

            migrationBuilder.RenameColumn(
                name: "vehicle_chassis_number",
                schema: "public",
                table: "reception_entrance",
                newName: "plate_number");

            migrationBuilder.RenameColumn(
                name: "container_number",
                schema: "public",
                table: "reception_entrance",
                newName: "aduana");

            migrationBuilder.AddColumn<string>(
                name: "container_number",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "container_number",
                schema: "public",
                table: "customs_declaration_details",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
