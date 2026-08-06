using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class MerchandiseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_products_product_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "merchandise_id");

            migrationBuilder.RenameIndex(
                name: "IX_ducat_registry_details_product_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "IX_ducat_registry_details_merchandise_id");

            migrationBuilder.AddColumn<string>(
                name: "merchandise_name",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "merchandise",
                schema: "public",
                columns: table => new
                {
                    merchandise_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    merchandise_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merchandise", x => x.merchandise_id);
                    table.ForeignKey(
                        name: "FK_merchandise_category_products_category_id",
                        column: x => x.category_id,
                        principalSchema: "public",
                        principalTable: "category_products",
                        principalColumn: "category_product_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_merchandise_category_id",
                schema: "public",
                table: "merchandise",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_merchandise_merchandise_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "merchandise_id",
                principalSchema: "public",
                principalTable: "merchandise",
                principalColumn: "merchandise_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_merchandise_merchandise_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropTable(
                name: "merchandise",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "merchandise_name",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.RenameColumn(
                name: "merchandise_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ducat_registry_details_merchandise_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "IX_ducat_registry_details_product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_products_product_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
