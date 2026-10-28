using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarConfiguracionAreasPermitidasPorCompañias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                schema: "public",
                table: "inventory_areas_permissions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_inventory_areas_permissions_company_id",
                schema: "public",
                table: "inventory_areas_permissions",
                column: "company_id");

            migrationBuilder.AddForeignKey(
                name: "FK_inventory_areas_permissions_companies_company_id",
                schema: "public",
                table: "inventory_areas_permissions",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inventory_areas_permissions_companies_company_id",
                schema: "public",
                table: "inventory_areas_permissions");

            migrationBuilder.DropIndex(
                name: "IX_inventory_areas_permissions_company_id",
                schema: "public",
                table: "inventory_areas_permissions");

            migrationBuilder.DropColumn(
                name: "company_id",
                schema: "public",
                table: "inventory_areas_permissions");
        }
    }
}
