using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDaemInformacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "daem",
                schema: "public",
                table: "working_information",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "payroll_id",
                schema: "public",
                table: "deductions_payment_histories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_deductions_payment_histories_payroll_id",
                schema: "public",
                table: "deductions_payment_histories",
                column: "payroll_id");

            migrationBuilder.AddForeignKey(
                name: "FK_deductions_payment_histories_payrolls_payroll_id",
                schema: "public",
                table: "deductions_payment_histories",
                column: "payroll_id",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deductions_payment_histories_payrolls_payroll_id",
                schema: "public",
                table: "deductions_payment_histories");

            migrationBuilder.DropIndex(
                name: "IX_deductions_payment_histories_payroll_id",
                schema: "public",
                table: "deductions_payment_histories");

            migrationBuilder.DropColumn(
                name: "daem",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropColumn(
                name: "payroll_id",
                schema: "public",
                table: "deductions_payment_histories");
        }
    }
}
