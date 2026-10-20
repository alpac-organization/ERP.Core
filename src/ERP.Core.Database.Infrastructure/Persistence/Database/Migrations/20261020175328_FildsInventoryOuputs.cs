using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FildsInventoryOuputs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inventory_outputs",
                schema: "public",
                columns: table => new
                {
                    inventory_output_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_outputs", x => x.inventory_output_id);
                    table.ForeignKey(
                        name: "FK_inventory_outputs_branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inventory_outputs_work_areas_WorkAreaId",
                        column: x => x.WorkAreaId,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_BranchId",
                schema: "public",
                table: "inventory_outputs",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_outputs_WorkAreaId",
                schema: "public",
                table: "inventory_outputs",
                column: "WorkAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_outputs",
                schema: "public");
        }
    }
}
