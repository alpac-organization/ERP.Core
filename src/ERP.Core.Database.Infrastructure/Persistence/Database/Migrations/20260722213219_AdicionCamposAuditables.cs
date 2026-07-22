using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AdicionCamposAuditables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "processed_by_user_name",
                schema: "public",
                table: "step_execution_logs",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "medio_exit_date",
                schema: "public",
                table: "reception_entrance",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "medio_exit_time",
                schema: "public",
                table: "reception_entrance",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_name",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "processed_by_user_name",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "medio_exit_date",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "medio_exit_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_by_user_name",
                schema: "public",
                table: "reception_entrance");
        }
    }
}
