using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class UserRelationAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_users_UserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_machinery_users_UserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropIndex(
                name: "IX_assignments_machinery_UserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropIndex(
                name: "IX_assignment_collaborators_UserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.CreateIndex(
                name: "IX_assignments_machinery_CreatedByUserId",
                schema: "public",
                table: "assignments_machinery",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_collaborators_CreatedByUserId",
                schema: "public",
                table: "assignment_collaborators",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_users_CreatedByUserId",
                schema: "public",
                table: "assignment_collaborators",
                column: "CreatedByUserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_machinery_users_CreatedByUserId",
                schema: "public",
                table: "assignments_machinery",
                column: "CreatedByUserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_collaborators_users_CreatedByUserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_assignments_machinery_users_CreatedByUserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropIndex(
                name: "IX_assignments_machinery_CreatedByUserId",
                schema: "public",
                table: "assignments_machinery");

            migrationBuilder.DropIndex(
                name: "IX_assignment_collaborators_CreatedByUserId",
                schema: "public",
                table: "assignment_collaborators");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "assignments_machinery",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "public",
                table: "assignment_collaborators",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_assignments_machinery_UserId",
                schema: "public",
                table: "assignments_machinery",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_assignment_collaborators_UserId",
                schema: "public",
                table: "assignment_collaborators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_collaborators_users_UserId",
                schema: "public",
                table: "assignment_collaborators",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignments_machinery_users_UserId",
                schema: "public",
                table: "assignments_machinery",
                column: "UserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
