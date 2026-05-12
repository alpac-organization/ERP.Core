using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCambiosColumnasDeducciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ir_tax_table",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "travel_expenses",
                schema: "public",
                table: "ordinary_payrolls",
                newName: "transport");

            migrationBuilder.RenameColumn(
                name: "food_travel_allowance",
                schema: "public",
                table: "ordinary_payrolls",
                newName: "feeding");

            migrationBuilder.RenameColumn(
                name: "TotalBalanceInDollars",
                schema: "public",
                table: "deductions",
                newName: "total_balance_in_dollars");

            migrationBuilder.RenameColumn(
                name: "TotalBalance",
                schema: "public",
                table: "deductions",
                newName: "total_balance");

            migrationBuilder.RenameColumn(
                name: "TotalAmountInDollars",
                schema: "public",
                table: "deductions",
                newName: "total_amount_in_dollars");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                schema: "public",
                table: "deductions",
                newName: "total_amount");

            migrationBuilder.RenameColumn(
                name: "AmountPaidInDollars",
                schema: "public",
                table: "deductions",
                newName: "amount_paid_in_dollars");

            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                schema: "public",
                table: "deductions",
                newName: "amount_paid");

            migrationBuilder.RenameColumn(
                name: "NumberOfFortnights",
                schema: "public",
                table: "deductions",
                newName: "number_fortnights_paid");

            migrationBuilder.AddColumn<decimal>(
                name: "ChristmasBonus",
                schema: "public",
                table: "ordinary_payrolls",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "number_fortnights",
                schema: "public",
                table: "deductions",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChristmasBonus",
                schema: "public",
                table: "ordinary_payrolls");

            migrationBuilder.DropColumn(
                name: "number_fortnights",
                schema: "public",
                table: "deductions");

            migrationBuilder.RenameColumn(
                name: "transport",
                schema: "public",
                table: "ordinary_payrolls",
                newName: "travel_expenses");

            migrationBuilder.RenameColumn(
                name: "feeding",
                schema: "public",
                table: "ordinary_payrolls",
                newName: "food_travel_allowance");

            migrationBuilder.RenameColumn(
                name: "total_balance_in_dollars",
                schema: "public",
                table: "deductions",
                newName: "TotalBalanceInDollars");

            migrationBuilder.RenameColumn(
                name: "total_balance",
                schema: "public",
                table: "deductions",
                newName: "TotalBalance");

            migrationBuilder.RenameColumn(
                name: "total_amount_in_dollars",
                schema: "public",
                table: "deductions",
                newName: "TotalAmountInDollars");

            migrationBuilder.RenameColumn(
                name: "total_amount",
                schema: "public",
                table: "deductions",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "amount_paid_in_dollars",
                schema: "public",
                table: "deductions",
                newName: "AmountPaidInDollars");

            migrationBuilder.RenameColumn(
                name: "amount_paid",
                schema: "public",
                table: "deductions",
                newName: "AmountPaid");

            migrationBuilder.RenameColumn(
                name: "number_fortnights_paid",
                schema: "public",
                table: "deductions",
                newName: "NumberOfFortnights");

            migrationBuilder.CreateTable(
                name: "ir_tax_table",
                schema: "public",
                columns: table => new
                {
                    tax_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    base_tax = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    from_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    OverExcessAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    percentage = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    to_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ir_tax_table", x => x.tax_id);
                });
        }
    }
}
