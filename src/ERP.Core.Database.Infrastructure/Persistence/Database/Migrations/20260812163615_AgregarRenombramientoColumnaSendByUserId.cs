using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRenombramientoColumnaSendByUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requisition_accounting_reviews_users_SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews");

            migrationBuilder.RenameColumn(
                name: "SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews",
                newName: "send_by_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_requisition_accounting_reviews_SentByUserId",
                schema: "public",
                table: "requisition_accounting_reviews",
                newName: "IX_requisition_accounting_reviews_send_by_user_id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "send_to_review_at",
                schema: "public",
                table: "requisition_accounting_reviews",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_requisition_accounting_reviews_users_send_by_user_id",
                schema: "public",
                table: "requisition_accounting_reviews",
                column: "send_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requisition_accounting_reviews_users_send_by_user_id",
                schema: "public",
                table: "requisition_accounting_reviews");

            migrationBuilder.RenameColumn(
                name: "send_by_user_id",
                schema: "public",
                table: "requisition_accounting_reviews",
                newName: "SentByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_requisition_accounting_reviews_send_by_user_id",
                schema: "public",
                table: "requisition_accounting_reviews",
                newName: "IX_requisition_accounting_reviews_SentByUserId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "send_to_review_at",
                schema: "public",
                table: "requisition_accounting_reviews",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

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
    }
}
