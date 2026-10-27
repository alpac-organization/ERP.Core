using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarConfiguracionesUnidadesMedidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_allowed_unit_measures_units_measurement_UnitMeasur~",
                schema: "public",
                table: "category_allowed_unit_measures");

            migrationBuilder.DropIndex(
                name: "IX_category_allowed_unit_measures_UnitMeasureId1",
                schema: "public",
                table: "category_allowed_unit_measures");

            migrationBuilder.DropColumn(
                name: "UnitMeasureId1",
                schema: "public",
                table: "category_allowed_unit_measures");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "category_allowed_unit_measures",
                newName: "deleted_at");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "category_allowed_unit_measures",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "category_allowed_unit_measures");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "category_allowed_unit_measures",
                newName: "DeletedAt");

            migrationBuilder.AddColumn<Guid>(
                name: "UnitMeasureId1",
                schema: "public",
                table: "category_allowed_unit_measures",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_category_allowed_unit_measures_UnitMeasureId1",
                schema: "public",
                table: "category_allowed_unit_measures",
                column: "UnitMeasureId1");

            migrationBuilder.AddForeignKey(
                name: "FK_category_allowed_unit_measures_units_measurement_UnitMeasur~",
                schema: "public",
                table: "category_allowed_unit_measures",
                column: "UnitMeasureId1",
                principalSchema: "public",
                principalTable: "units_measurement",
                principalColumn: "unit_measure_id");
        }
    }
}
