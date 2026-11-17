using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AuditEquipmentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "equipments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by_user_id",
                schema: "public",
                table: "equipments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_equipments_updated_by_user_id",
                schema: "public",
                table: "equipments",
                column: "updated_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_equipments_users_updated_by_user_id",
                schema: "public",
                table: "equipments",
                column: "updated_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipments_users_updated_by_user_id",
                schema: "public",
                table: "equipments");

            migrationBuilder.DropIndex(
                name: "IX_equipments_updated_by_user_id",
                schema: "public",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "public",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                schema: "public",
                table: "equipments");
        }
    }
}
