using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRecoveredPayrollYPendingDeductionIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pending_deduction_balances_collaborator_id",
                schema: "public",
                table: "pending_deduction_balances");

            migrationBuilder.AddColumn<Guid>(
                name: "recovered_payroll_id",
                schema: "public",
                table: "pending_deduction_balances",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_pending_deduction_balances_collaborator_is_recovered",
                schema: "public",
                table: "pending_deduction_balances",
                columns: new[] { "collaborator_id", "is_recovered" });

            migrationBuilder.CreateIndex(
                name: "IX_pending_deduction_balances_recovered_payroll_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "recovered_payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pending_deduction_balances_payrolls_recovered_payroll_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "recovered_payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pending_deduction_balances_payrolls_recovered_payroll_id",
                schema: "public",
                table: "pending_deduction_balances");

            migrationBuilder.DropIndex(
                name: "ix_pending_deduction_balances_collaborator_is_recovered",
                schema: "public",
                table: "pending_deduction_balances");

            migrationBuilder.DropIndex(
                name: "IX_pending_deduction_balances_recovered_payroll_id",
                schema: "public",
                table: "pending_deduction_balances");

            migrationBuilder.DropColumn(
                name: "recovered_payroll_id",
                schema: "public",
                table: "pending_deduction_balances");

            migrationBuilder.CreateIndex(
                name: "IX_pending_deduction_balances_collaborator_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "collaborator_id");
        }
    }
}
