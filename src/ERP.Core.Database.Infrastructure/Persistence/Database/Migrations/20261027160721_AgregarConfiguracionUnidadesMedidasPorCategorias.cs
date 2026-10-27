using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarConfiguracionUnidadesMedidasPorCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category_allowed_unit_measures",
                schema: "public",
                columns: table => new
                {
                    category_allowed_unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitMeasureId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_allowed_unit_measures", x => x.category_allowed_unit_measure_id);
                    table.ForeignKey(
                        name: "FK_category_allowed_unit_measures_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category_allowed_unit_measures_units_measurement_UnitMeasur~",
                        column: x => x.UnitMeasureId1,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id");
                    table.ForeignKey(
                        name: "FK_category_allowed_unit_measures_units_measurement_unit_measu~",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_allowed_unit_measures_category_id",
                schema: "public",
                table: "category_allowed_unit_measures",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_allowed_unit_measures_unit_measure_id",
                schema: "public",
                table: "category_allowed_unit_measures",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_allowed_unit_measures_UnitMeasureId1",
                schema: "public",
                table: "category_allowed_unit_measures",
                column: "UnitMeasureId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_allowed_unit_measures",
                schema: "public");
        }
    }
}
