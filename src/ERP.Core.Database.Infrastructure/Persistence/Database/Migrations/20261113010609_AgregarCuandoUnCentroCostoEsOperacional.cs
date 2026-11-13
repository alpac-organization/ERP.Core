using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCuandoUnCentroCostoEsOperacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_operational",
                schema: "public",
                table: "cost_centers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_operational",
                schema: "public",
                table: "cost_centers");
        }
    }
}
