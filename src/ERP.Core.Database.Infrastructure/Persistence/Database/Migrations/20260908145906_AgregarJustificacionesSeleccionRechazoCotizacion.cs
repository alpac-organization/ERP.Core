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
            migrationBuilder.RenameColumn(
                name: "delivery_time_type",
                schema: "public",
                table: "quotations",
                newName: "DeliveryTimeType");

            migrationBuilder.RenameColumn(
                name: "delivery_time",
                schema: "public",
                table: "quotations",
                newName: "DeliveryTime");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryTimeType",
                schema: "public",
                table: "quotations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "time_type_enum",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryTime",
                schema: "public",
                table: "quotations",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

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

            migrationBuilder.RenameColumn(
                name: "DeliveryTimeType",
                schema: "public",
                table: "quotations",
                newName: "delivery_time_type");

            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                schema: "public",
                table: "quotations",
                newName: "delivery_time");

            migrationBuilder.AlterColumn<int>(
                name: "delivery_time_type",
                schema: "public",
                table: "quotations",
                type: "time_type_enum",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "delivery_time",
                schema: "public",
                table: "quotations",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
