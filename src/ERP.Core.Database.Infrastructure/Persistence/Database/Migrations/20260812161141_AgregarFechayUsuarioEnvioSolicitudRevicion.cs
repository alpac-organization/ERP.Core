using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechayUsuarioEnvioSolicitudRevicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("7293b6b6-3070-402d-8594-34321cfabf07"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "send_to_review_at",
                schema: "public",
                table: "requisition_accounting_reviews",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_requisition_accounting_reviews_SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews",
                column: "SentByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_requisition_accounting_reviews_users_SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews",
                column: "SentByUserId",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requisition_accounting_reviews_users_SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews");

            migrationBuilder.DropIndex(
                name: "IX_requisition_accounting_reviews_SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews");

            migrationBuilder.DropColumn(
                name: "SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews");

            migrationBuilder.DropColumn(
                name: "send_to_review_at",
                schema: "public",
                table: "requisition_accounting_reviews");
        }
    }
}
