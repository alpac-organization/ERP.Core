using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToReception : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                schema: "public",
                table: "reception_entrance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_created_by_user_id",
                schema: "public",
                table: "reception_entrance",
                column: "created_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_users_created_by_user_id",
                schema: "public",
                table: "reception_entrance",
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
                name: "FK_reception_entrance_users_created_by_user_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropIndex(
                name: "IX_reception_entrance_created_by_user_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                schema: "public",
                table: "reception_entrance");
        }
    }
}
