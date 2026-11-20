using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesReportInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "physical_counts",
                schema: "public",
                columns: table => new
                {
                    physical_count_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    area_id = table.Column<Guid>(type: "uuid", nullable: true),
                    cost_center_id = table.Column<Guid>(type: "uuid", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "physical_count_status_enum", nullable: false, defaultValueSql: "'draft'::physical_count_status_enum"),
                    notes = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    completed_by = table.Column<Guid>(type: "uuid", nullable: true),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_counts", x => x.physical_count_id);
                    table.ForeignKey(
                        name: "FK_physical_counts_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_physical_counts_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_physical_counts_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_physical_counts_cost_centers_cost_center_id",
                        column: x => x.cost_center_id,
                        principalSchema: "public",
                        principalTable: "cost_centers",
                        principalColumn: "cost_center_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_physical_counts_work_areas_area_id",
                        column: x => x.area_id,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "physical_count_lines",
                schema: "public",
                columns: table => new
                {
                    physical_count_line_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    physical_count_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_stock_id = table.Column<Guid>(type: "uuid", nullable: false),
                    system_stock = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    physical_stock = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: true),
                    difference = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: true),
                    observations = table.Column<string>(type: "text", nullable: true),
                    counted_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    counted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_count_lines", x => x.physical_count_line_id);
                    table.ForeignKey(
                        name: "FK_physical_count_lines_physical_counts_physical_count_id",
                        column: x => x.physical_count_id,
                        principalSchema: "public",
                        principalTable: "physical_counts",
                        principalColumn: "physical_count_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_physical_count_lines_product_stock_product_stock_id",
                        column: x => x.product_stock_id,
                        principalSchema: "public",
                        principalTable: "product_stock",
                        principalColumn: "product_stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_physical_count_lines_product_stock_id",
                schema: "public",
                table: "physical_count_lines",
                column: "product_stock_id");

            migrationBuilder.CreateIndex(
                name: "ux_physical_count_line_count_productstock",
                schema: "public",
                table: "physical_count_lines",
                columns: new[] { "physical_count_id", "product_stock_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_physical_counts_area_id",
                schema: "public",
                table: "physical_counts",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_counts_branch_id",
                schema: "public",
                table: "physical_counts",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_counts_category_id",
                schema: "public",
                table: "physical_counts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_physical_counts_company_branch",
                schema: "public",
                table: "physical_counts",
                columns: new[] { "company_id", "branch_id" });

            migrationBuilder.CreateIndex(
                name: "IX_physical_counts_cost_center_id",
                schema: "public",
                table: "physical_counts",
                column: "cost_center_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "physical_count_lines",
                schema: "public");

            migrationBuilder.DropTable(
                name: "physical_counts",
                schema: "public");
        }
    }
}
