using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarJustificacionesSeleccionRechazoCotizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "supplier_rejection_justification",
                schema: "public",
                table: "quotations",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "supplier_selection_justification",
                schema: "public",
                table: "quotations",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supplier_rejection_justification",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "supplier_selection_justification",
                schema: "public",
                table: "quotations");
        }
    }
}
