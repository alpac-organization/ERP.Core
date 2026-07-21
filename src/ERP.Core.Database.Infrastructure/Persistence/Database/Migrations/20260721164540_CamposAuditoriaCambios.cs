using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CamposAuditoriaCambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_id",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
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
        }
    }
}
