using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTiempoDisponibilidadInventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "availability_time",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "availability_time_type",
                schema: "public",
                table: "quotations",
                type: "time_type_enum",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "inventory_available",
                schema: "public",
                table: "quotations",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "availability_time",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "availability_time_type",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "inventory_available",
                schema: "public",
                table: "quotations");
        }
    }
}
