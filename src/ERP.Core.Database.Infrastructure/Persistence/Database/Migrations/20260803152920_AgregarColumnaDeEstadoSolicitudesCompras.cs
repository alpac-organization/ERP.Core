using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnaDeEstadoSolicitudesCompras : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "purchase_requests",
                type: "boolean",
                nullable: false,
                defaultValue: true);

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
                name: "is_active",
                schema: "public",
                table: "purchase_requests");

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
        }
    }
}
