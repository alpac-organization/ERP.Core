using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class TiempoDucaControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "registered_time",
                schema: "public",
                table: "ducat_registry_details",
                newName: "registered_start_time");

            migrationBuilder.RenameColumn(
                name: "registered_date",
                schema: "public",
                table: "ducat_registry_details",
                newName: "registered_start_date");

            migrationBuilder.RenameColumn(
                name: "registered_time",
                schema: "public",
                table: "ducat_registry",
                newName: "registered_start_time");

            migrationBuilder.RenameColumn(
                name: "registered_date",
                schema: "public",
                table: "ducat_registry",
                newName: "registered_start_date");

            migrationBuilder.AddColumn<DateOnly>(
                name: "registered_end_date",
                schema: "public",
                table: "ducat_registry_details",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "registered_end_time",
                schema: "public",
                table: "ducat_registry_details",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "registered_end_date",
                schema: "public",
                table: "ducat_registry",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "registered_end_time",
                schema: "public",
                table: "ducat_registry",
                type: "time without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "registered_end_date",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registered_end_time",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registered_end_date",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "registered_end_time",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.RenameColumn(
                name: "registered_start_time",
                schema: "public",
                table: "ducat_registry_details",
                newName: "registered_time");

            migrationBuilder.RenameColumn(
                name: "registered_start_date",
                schema: "public",
                table: "ducat_registry_details",
                newName: "registered_date");

            migrationBuilder.RenameColumn(
                name: "registered_start_time",
                schema: "public",
                table: "ducat_registry",
                newName: "registered_time");

            migrationBuilder.RenameColumn(
                name: "registered_start_date",
                schema: "public",
                table: "ducat_registry",
                newName: "registered_date");
        }
    }
}
