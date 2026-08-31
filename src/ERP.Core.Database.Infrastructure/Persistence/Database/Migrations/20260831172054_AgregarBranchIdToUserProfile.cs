using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarBranchIdToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_branches_branch_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_branch_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "users");

            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "users_profiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_profiles_branch_id",
                schema: "public",
                table: "users_profiles",
                column: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_branches_branch_id",
                schema: "public",
                table: "users_profiles",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Restaurar users.branch_id desde perfiles ANTES de borrar users_profiles.branch_id.
            // Sin esto EF ponía Guid.Empty y la FK a branches fallaba o dejaba basura.
            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE users u
                SET branch_id = p.branch_id
                FROM (
                    SELECT DISTINCT ON (user_id) user_id, branch_id
                    FROM users_profiles
                    WHERE branch_id IS NOT NULL
                    ORDER BY user_id, created_at
                ) p
                WHERE u.user_id = p.user_id;
                """);

            // Falla a propósito si algún usuario no tiene sucursal en ningún perfil (mejor que Guid vacío).
            migrationBuilder.Sql(
                "ALTER TABLE public.users ALTER COLUMN branch_id SET NOT NULL;");

            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_branches_branch_id",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.DropIndex(
                name: "IX_users_profiles_branch_id",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.DropColumn(
                name: "branch_id",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.CreateIndex(
                name: "IX_users_branch_id",
                schema: "public",
                table: "users",
                column: "branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_branches_branch_id",
                schema: "public",
                table: "users",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
