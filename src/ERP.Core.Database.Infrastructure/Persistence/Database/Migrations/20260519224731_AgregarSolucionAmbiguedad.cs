using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSolucionAmbiguedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_records_travel_expense_payments_payrolls_PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments");

            migrationBuilder.DropForeignKey(
                name: "FK_vacations_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_vacations_accruals_payrolls_PayrollId",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.DropIndex(
                name: "IX_records_travel_expense_payments_PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments");

            migrationBuilder.DropColumn(
                name: "PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "vacations_accruals",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_accruals_payrolls_PayrollId",
                schema: "public",
                table: "vacations_accruals",
                column: "PayrollId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vacations_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_vacations_accruals_payrolls_PayrollId",
                schema: "public",
                table: "vacations_accruals");

            migrationBuilder.AddColumn<Guid>(
                name: "PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_records_travel_expense_payments_PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "PayrollId1");

            migrationBuilder.AddForeignKey(
                name: "FK_records_travel_expense_payments_payrolls_PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "PayrollId1",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_accruals_collaborators_collaborator_id",
                schema: "public",
                table: "vacations_accruals",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vacations_accruals_payrolls_PayrollId",
                schema: "public",
                table: "vacations_accruals",
                column: "PayrollId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
