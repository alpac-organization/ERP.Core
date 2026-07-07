using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemovePendingBalances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pending_deduction_balances",
                schema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pending_deduction_balances",
                schema: "public",
                columns: table => new
                {
                    pending_deduction_balance_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    origin_payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_owed = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_recovered = table.Column<bool>(type: "boolean", nullable: false),
                    reason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pending_deduction_balances", x => x.pending_deduction_balance_id);
                    table.ForeignKey(
                        name: "FK_pending_deduction_balances_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pending_deduction_balances_payrolls_origin_payroll_id",
                        column: x => x.origin_payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pending_deduction_balance_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "pending_deduction_balance_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pending_deduction_balances_collaborator_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_pending_deduction_balances_origin_payroll_id",
                schema: "public",
                table: "pending_deduction_balances",
                column: "origin_payroll_id");
        }
    }
}
