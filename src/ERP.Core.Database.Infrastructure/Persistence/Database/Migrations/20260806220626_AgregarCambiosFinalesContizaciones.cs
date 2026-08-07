using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCambiosFinalesContizaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotations_branches_BranchId",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_quotations_purchase_request_items_purchase_request_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropIndex(
                name: "IX_quotations_BranchId",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "public",
                table: "quotations");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "quotations",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "purchase_request_id",
                schema: "public",
                table: "quotations",
                newName: "purchase_request_item_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotations_purchase_request_id",
                schema: "public",
                table: "quotations",
                newName: "IX_quotations_purchase_request_item_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "purchase_request_items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "HasQuotation",
                schema: "public",
                table: "purchase_request_items",
                newName: "has_quotation");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "quotations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<bool>(
                name: "has_quotation",
                schema: "public",
                table: "purchase_request_items",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_purchase_request_items_purchase_request_item_id",
                schema: "public",
                table: "quotations",
                column: "purchase_request_item_id",
                principalSchema: "public",
                principalTable: "purchase_request_items",
                principalColumn: "purchase_request_item_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotations_purchase_request_items_purchase_request_item_id",
                schema: "public",
                table: "quotations");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "quotations");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "quotations",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "purchase_request_item_id",
                schema: "public",
                table: "quotations",
                newName: "purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_quotations_purchase_request_item_id",
                schema: "public",
                table: "quotations",
                newName: "IX_quotations_purchase_request_id");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "purchase_request_items",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "has_quotation",
                schema: "public",
                table: "purchase_request_items",
                newName: "HasQuotation");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                schema: "public",
                table: "quotations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "HasQuotation",
                schema: "public",
                table: "purchase_request_items",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_quotations_BranchId",
                schema: "public",
                table: "quotations",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_branches_BranchId",
                schema: "public",
                table: "quotations",
                column: "BranchId",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotations_purchase_request_items_purchase_request_id",
                schema: "public",
                table: "quotations",
                column: "purchase_request_id",
                principalSchema: "public",
                principalTable: "purchase_request_items",
                principalColumn: "purchase_request_item_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
