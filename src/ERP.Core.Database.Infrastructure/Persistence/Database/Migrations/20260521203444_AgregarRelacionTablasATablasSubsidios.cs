using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionTablasATablasSubsidios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subsidies_types_subsidy_TypesSubsidyId",
                schema: "public",
                table: "subsidies");

            migrationBuilder.RenameColumn(
                name: "TypesSubsidyId",
                schema: "public",
                table: "subsidies",
                newName: "PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_subsidies_TypesSubsidyId",
                schema: "public",
                table: "subsidies",
                newName: "IX_subsidies_PayrollId");

            migrationBuilder.AddColumn<int>(
                name: "AmountDays",
                schema: "public",
                table: "subsidies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "public",
                table: "payrolls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subsidies_type_subsidy_id",
                schema: "public",
                table: "subsidies",
                column: "type_subsidy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_subsidies_payrolls_PayrollId",
                schema: "public",
                table: "subsidies",
                column: "PayrollId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subsidies_types_subsidy_type_subsidy_id",
                schema: "public",
                table: "subsidies",
                column: "type_subsidy_id",
                principalSchema: "public",
                principalTable: "types_subsidy",
                principalColumn: "type_subsidy_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subsidies_payrolls_PayrollId",
                schema: "public",
                table: "subsidies");

            migrationBuilder.DropForeignKey(
                name: "FK_subsidies_types_subsidy_type_subsidy_id",
                schema: "public",
                table: "subsidies");

            migrationBuilder.DropIndex(
                name: "IX_subsidies_type_subsidy_id",
                schema: "public",
                table: "subsidies");

            migrationBuilder.DropColumn(
                name: "AmountDays",
                schema: "public",
                table: "subsidies");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                schema: "public",
                table: "subsidies",
                newName: "TypesSubsidyId");

            migrationBuilder.RenameIndex(
                name: "IX_subsidies_PayrollId",
                schema: "public",
                table: "subsidies",
                newName: "IX_subsidies_TypesSubsidyId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "public",
                table: "payrolls",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_subsidies_types_subsidy_TypesSubsidyId",
                schema: "public",
                table: "subsidies",
                column: "TypesSubsidyId",
                principalSchema: "public",
                principalTable: "types_subsidy",
                principalColumn: "type_subsidy_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
