using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCamposAnulacionPurchaseRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "annulled_by_user_id",
                schema: "public",
                table: "purchase_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "annulment_reason",
                schema: "public",
                table: "purchase_requests",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_annulled_by_user_id",
                schema: "public",
                table: "purchase_requests",
                column: "annulled_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_users_annulled_by_user_id",
                schema: "public",
                table: "purchase_requests",
                column: "annulled_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_users_annulled_by_user_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropIndex(
                name: "IX_purchase_requests_annulled_by_user_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropColumn(
                name: "annulled_by_user_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropColumn(
                name: "annulment_reason",
                schema: "public",
                table: "purchase_requests");
        }
    }
}
