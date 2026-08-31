using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class MoverBranchIdAUserProfileBranch : Migration
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
                nullable: false,
                defaultValue: new Guid("f9c8c488-f53e-46c2-9594-1e9b23cf805c"));

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

            migrationBuilder.AddColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
