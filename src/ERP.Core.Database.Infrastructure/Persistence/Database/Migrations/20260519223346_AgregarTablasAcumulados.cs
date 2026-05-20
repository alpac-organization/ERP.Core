using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasAcumulados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigned_travel_expenses_collaborators_collaborator_id",
                schema: "public",
                table: "assigned_travel_expenses");

            migrationBuilder.DropTable(
                name: "assigned_travel_expenses_histories",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "christmas_bonus_accruals",
                schema: "public",
                columns: table => new
                {
                    christmas_bonus_accrual_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    base_salary = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    christmas_bonus_days = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_christmas_bonus_accruals", x => x.christmas_bonus_accrual_id);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_accruals_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_christmas_bonus_accruals_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "records_travel_expense_payments",
                schema: "public",
                columns: table => new
                {
                    records_travel_expense_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    paid_days = table.Column<int>(type: "integer", nullable: false),
                    lodging = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    feeding = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    transport = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    PayrollId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_records_travel_expense_payments", x => x.records_travel_expense_id);
                    table.ForeignKey(
                        name: "FK_records_travel_expense_payments_collaborators_collaborator_~",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_records_travel_expense_payments_payrolls_PayrollId1",
                        column: x => x.PayrollId1,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id");
                    table.ForeignKey(
                        name: "FK_records_travel_expense_payments_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vacations_accruals",
                schema: "public",
                columns: table => new
                {
                    vacation_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    available_vacations = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    equivalent_quantity_in_dollars = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    PayrollId = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacations_accruals", x => x.vacation_id);
                    table.ForeignKey(
                        name: "FK_vacations_accruals_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vacations_accruals_payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_accruals_payroll_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_christmas_bonus_collaborator_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_record_travel_expense_collaborator_id",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_records_travel_expense_payments_payroll_id",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_records_travel_expense_payments_PayrollId1",
                schema: "public",
                table: "records_travel_expense_payments",
                column: "PayrollId1");

            migrationBuilder.CreateIndex(
                name: "IX_vacations_accruals_collaborator_id",
                schema: "public",
                table: "vacations_accruals",
                column: "collaborator_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vacations_accruals_PayrollId",
                schema: "public",
                table: "vacations_accruals",
                column: "PayrollId");

            migrationBuilder.AddForeignKey(
                name: "FK_assigned_travel_expenses_collaborators_collaborator_id",
                schema: "public",
                table: "assigned_travel_expenses",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assigned_travel_expenses_collaborators_collaborator_id",
                schema: "public",
                table: "assigned_travel_expenses");

            migrationBuilder.DropTable(
                name: "christmas_bonus_accruals",
                schema: "public");

            migrationBuilder.DropTable(
                name: "records_travel_expense_payments",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vacations_accruals",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "assigned_travel_expenses_histories",
                schema: "public",
                columns: table => new
                {
                    assigned_travel_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    feeding = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    lodging = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    NumberDaysPaid = table.Column<int>(type: "integer", nullable: false),
                    total_amount_paid = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    transport = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assigned_travel_expenses_histories", x => x.assigned_travel_id);
                    table.ForeignKey(
                        name: "FK_assigned_travel_expenses_histories_collaborators_collaborat~",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_assigned_travel_expenses_histories_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assigned_travel_expenses_histories_collaborator_id",
                schema: "public",
                table: "assigned_travel_expenses_histories",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_assigned_travel_expenses_histories_payroll_id",
                schema: "public",
                table: "assigned_travel_expenses_histories",
                column: "payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assigned_travel_expenses_collaborators_collaborator_id",
                schema: "public",
                table: "assigned_travel_expenses",
                column: "collaborator_id",
                principalSchema: "public",
                principalTable: "collaborators",
                principalColumn: "collaborator_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
