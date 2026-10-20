using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarComoObligatorioElCampoSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_branches_branch_id",
                schema: "public",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_branches_branch_id",
                schema: "public",
                table: "products",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_branches_branch_id",
                schema: "public",
                table: "products");

            migrationBuilder.AlterColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "products",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_products_branches_branch_id",
                schema: "public",
                table: "products",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id");
        }
    }
}
