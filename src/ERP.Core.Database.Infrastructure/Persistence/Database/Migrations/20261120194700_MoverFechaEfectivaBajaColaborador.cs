using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class MoverFechaEfectivaBajaColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "departure_date",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropColumn(
                name: "departure_date",
                schema: "public",
                table: "collaborator_terminations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "departure_date",
                schema: "public",
                table: "working_information",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "departure_date",
                schema: "public",
                table: "collaborator_terminations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
