using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CampoNombreNuevo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "trailer_identifier",
                schema: "public",
                table: "ducat_registry",
                newName: "container_number");

            migrationBuilder.AlterColumn<string>(
                name: "transportista",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "container_number",
                schema: "public",
                table: "ducat_registry",
                newName: "trailer_identifier");

            migrationBuilder.AlterColumn<string>(
                name: "transportista",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
