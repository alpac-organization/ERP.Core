using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FuelRequestEntityServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fuel_requests",
                schema: "public",
                columns: table => new
                {
                    supply_request_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    justification = table.Column<string>(type: "text", nullable: true),
                    outflow_status = table.Column<int>(type: "outflow_status_enum", nullable: false, defaultValueSql: "'pending_review'::outflow_status_enum"),
                    work_area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cost_center_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requested_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    approved_by_user_chief_id = table.Column<Guid>(type: "uuid", nullable: true),
                    annulled_by_user_chief_id = table.Column<Guid>(type: "uuid", nullable: true),
                    machinery_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unit_measure_id = table.Column<Guid>(type: "uuid", nullable: false),
                    requested_quantity = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    MachineryId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductStockId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    UnitMeasureId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuel_requests", x => x.supply_request_id);
                    table.ForeignKey(
                        name: "FK_fuel_requests_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fuel_requests_cost_centers_cost_center_id",
                        column: x => x.cost_center_id,
                        principalSchema: "public",
                        principalTable: "cost_centers",
                        principalColumn: "cost_center_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fuel_requests_machineries_MachineryId1",
                        column: x => x.MachineryId1,
                        principalSchema: "public",
                        principalTable: "machineries",
                        principalColumn: "machinery_id");
                    table.ForeignKey(
                        name: "FK_fuel_requests_machineries_machinery_id",
                        column: x => x.machinery_id,
                        principalSchema: "public",
                        principalTable: "machineries",
                        principalColumn: "machinery_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fuel_requests_product_stock_ProductStockId1",
                        column: x => x.ProductStockId1,
                        principalSchema: "public",
                        principalTable: "product_stock",
                        principalColumn: "product_stock_id");
                    table.ForeignKey(
                        name: "FK_fuel_requests_product_stock_product_stock_id",
                        column: x => x.product_stock_id,
                        principalSchema: "public",
                        principalTable: "product_stock",
                        principalColumn: "product_stock_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fuel_requests_units_measurement_UnitMeasureId1",
                        column: x => x.UnitMeasureId1,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id");
                    table.ForeignKey(
                        name: "FK_fuel_requests_units_measurement_unit_measure_id",
                        column: x => x.unit_measure_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fuel_requests_users_requested_by_user_id",
                        column: x => x.requested_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_fuel_requests_work_areas_work_area_id",
                        column: x => x.work_area_id,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_branch_id",
                schema: "public",
                table: "fuel_requests",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_cost_center_id",
                schema: "public",
                table: "fuel_requests",
                column: "cost_center_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_machinery_id",
                schema: "public",
                table: "fuel_requests",
                column: "machinery_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_MachineryId1",
                schema: "public",
                table: "fuel_requests",
                column: "MachineryId1");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_product_stock_id",
                schema: "public",
                table: "fuel_requests",
                column: "product_stock_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_ProductStockId1",
                schema: "public",
                table: "fuel_requests",
                column: "ProductStockId1");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_requested_by_user_id",
                schema: "public",
                table: "fuel_requests",
                column: "requested_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_unit_measure_id",
                schema: "public",
                table: "fuel_requests",
                column: "unit_measure_id");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_UnitMeasureId1",
                schema: "public",
                table: "fuel_requests",
                column: "UnitMeasureId1");

            migrationBuilder.CreateIndex(
                name: "IX_fuel_requests_work_area_id",
                schema: "public",
                table: "fuel_requests",
                column: "work_area_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fuel_requests",
                schema: "public");
        }
    }
}
