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

            // Una sucursal por empresa (la más antigua). Ajusta el ORDER BY si quieres otra regla.
            migrationBuilder.Sql("""
                UPDATE public.users_profiles up
                SET branch_id = b.branch_id
                FROM (
                    SELECT DISTINCT ON (company_id) company_id, branch_id
                    FROM public.branches
                    WHERE deleted_at IS NULL
                    ORDER BY company_id, created_at
                ) b
                WHERE b.company_id = up.company_id
                AND up.branch_id IS NULL;
                """);

            migrationBuilder.Sql("""
                DO $$
                DECLARE
                    huerfanos INT;
                BEGIN
                    SELECT COUNT(*) INTO huerfanos
                    FROM public.users_profiles
                    WHERE branch_id IS NULL;
                    IF huerfanos > 0 THEN
                        RAISE EXCEPTION 'Existen % users_profiles sin branch_id mapeable a branches', huerfanos;
                    END IF;
                END $$;
                """);

            migrationBuilder.Sql("""
                ALTER TABLE public.users_profiles
                ALTER COLUMN branch_id SET NOT NULL;
                """);

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
            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.Sql("""
                UPDATE public.users u
                SET branch_id = p.branch_id
                FROM (
                    SELECT DISTINCT ON (user_id) user_id, branch_id
                    FROM public.users_profiles
                    WHERE branch_id IS NOT NULL
                      AND branch_id <> '00000000-0000-0000-0000-000000000000'
                    ORDER BY user_id, created_at
                ) p
                INNER JOIN public.branches b ON b.branch_id = p.branch_id
                WHERE u.user_id = p.user_id;
                """);

            migrationBuilder.Sql("""
                DO $$
                DECLARE
                    huerfanos INT;
                BEGIN
                    SELECT COUNT(*) INTO huerfanos
                    FROM public.users
                    WHERE branch_id IS NULL;

                    IF huerfanos > 0 THEN
                        RAISE EXCEPTION 'Existen % usuarios sin branch_id restaurable desde users_profiles', huerfanos;
                    END IF;
                END $$;
                """);

            migrationBuilder.Sql("""
                ALTER TABLE public.users
                ALTER COLUMN branch_id SET NOT NULL;
                """);

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
