using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AuditoriaDucaRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "finished_by_user_id",
                schema: "public",
                table: "step_execution_logs",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "finished_by_user_name",
                schema: "public",
                table: "step_execution_logs",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "trailer_chassis",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "seal_number",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "driver_name",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "driver_license",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "aduana",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registered_by_user_name",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "registered_date",
                schema: "public",
                table: "ducat_registry_details",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "registered_time",
                schema: "public",
                table: "ducat_registry_details",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registered_by_user_name",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "registered_date",
                schema: "public",
                table: "ducat_registry",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "registered_time",
                schema: "public",
                table: "ducat_registry",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "number",
                schema: "public",
                table: "customs_declarations",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "container_number",
                schema: "public",
                table: "customs_declaration_details",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finished_by_user_id",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "finished_by_user_name",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registered_by_user_name",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registered_date",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registered_time",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "registered_by_user_name",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "registered_date",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "registered_time",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.AlterColumn<string>(
                name: "trailer_chassis",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "seal_number",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "driver_name",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "driver_license",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "aduana",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "number",
                schema: "public",
                table: "customs_declarations",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "container_number",
                schema: "public",
                table: "customs_declaration_details",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);
        }
    }
}
