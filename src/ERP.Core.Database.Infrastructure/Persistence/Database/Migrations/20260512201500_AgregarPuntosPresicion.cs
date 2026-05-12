using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPuntosPresicion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currency",
                schema: "public",
                table: "deductions",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "FortnightlyAmountInDollars",
                schema: "public",
                table: "deductions",
                newName: "fortnightly_amount_in_dollars");

            migrationBuilder.RenameColumn(
                name: "FortnightlyAmount",
                schema: "public",
                table: "deductions",
                newName: "fortnightly_amount");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_balance_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_balance",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_amount_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_amount",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_paid_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_paid",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "currency",
                schema: "public",
                table: "deductions",
                type: "currency_enum",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "fortnightly_amount_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "fortnightly_amount",
                schema: "public",
                table: "deductions",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currency",
                schema: "public",
                table: "deductions",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "fortnightly_amount_in_dollars",
                schema: "public",
                table: "deductions",
                newName: "FortnightlyAmountInDollars");

            migrationBuilder.RenameColumn(
                name: "fortnightly_amount",
                schema: "public",
                table: "deductions",
                newName: "FortnightlyAmount");

            migrationBuilder.AlterColumn<decimal>(
                name: "total_balance_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_balance",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_amount_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "total_amount",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                schema: "public",
                table: "deductions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "currency_enum");

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_paid_in_dollars",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "amount_paid",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FortnightlyAmountInDollars",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FortnightlyAmount",
                schema: "public",
                table: "deductions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
