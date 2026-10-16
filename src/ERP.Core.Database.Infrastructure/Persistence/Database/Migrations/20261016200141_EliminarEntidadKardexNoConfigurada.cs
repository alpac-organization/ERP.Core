using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EliminarEntidadKardexNoConfigurada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kardex",
                schema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kardex",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CostCenterId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AverageCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Concept = table.Column<int>(type: "integer", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MovementByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalInput = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalKardex = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalOutput = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalUnits = table.Column<int>(type: "integer", nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TransactionTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric", nullable: false),
                    Units = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kardex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kardex_cost_centers_CostCenterId",
                        column: x => x.CostCenterId,
                        principalSchema: "public",
                        principalTable: "cost_centers",
                        principalColumn: "cost_center_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kardex_products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kardex_users_UserId",
                        column: x => x.UserId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_CostCenterId",
                schema: "public",
                table: "Kardex",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_ProductId",
                schema: "public",
                table: "Kardex",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_UserId",
                schema: "public",
                table: "Kardex",
                column: "UserId");
        }
    }
}
