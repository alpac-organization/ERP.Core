using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionRegistroProveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "public",
                table: "suppliers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_user_id",
                schema: "public",
                table: "suppliers",
                column: "user_id");

            migrationBuilder.Sql(@"
                UPDATE public.suppliers
                SET user_id = '7293b6b6-3070-402d-8594-34321cfabf07'
                WHERE user_id = '00000000-0000-0000-0000-000000000000';
            ");

            migrationBuilder.AddForeignKey(
                name: "FK_suppliers_users_user_id",
                schema: "public",
                table: "suppliers",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_suppliers_users_user_id",
                schema: "public",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_user_id",
                schema: "public",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "public",
                table: "suppliers");
        }
    }
}