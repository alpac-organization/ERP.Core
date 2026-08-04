using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionRegistrosCotizaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "quotes",
                newName: "is_active");

            migrationBuilder.AlterColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "quotes",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                schema: "public",
                table: "quotes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_quotes_created_by_user_id",
                schema: "public",
                table: "quotes",
                column: "created_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_quotes_users_created_by_user_id",
                schema: "public",
                table: "quotes",
                column: "created_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quotes_users_created_by_user_id",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropIndex(
                name: "IX_quotes_created_by_user_id",
                schema: "public",
                table: "quotes");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                schema: "public",
                table: "quotes");

            migrationBuilder.RenameColumn(
                name: "is_active",
                schema: "public",
                table: "quotes",
                newName: "IsActive");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "quotes",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);
        }
    }
}
