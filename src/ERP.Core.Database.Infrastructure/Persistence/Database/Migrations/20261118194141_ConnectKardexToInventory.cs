using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ConnectKardexToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "inventory_output_id",
                schema: "public",
                table: "kardex",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_kardex_inventory_output_id",
                schema: "public",
                table: "kardex",
                column: "inventory_output_id");

            migrationBuilder.AddForeignKey(
                name: "FK_kardex_inventory_outputs_inventory_output_id",
                schema: "public",
                table: "kardex",
                column: "inventory_output_id",
                principalSchema: "public",
                principalTable: "inventory_outputs",
                principalColumn: "inventory_output_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kardex_inventory_outputs_inventory_output_id",
                schema: "public",
                table: "kardex");

            migrationBuilder.DropIndex(
                name: "IX_kardex_inventory_output_id",
                schema: "public",
                table: "kardex");

            migrationBuilder.DropColumn(
                name: "inventory_output_id",
                schema: "public",
                table: "kardex");
        }
    }
}
