using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDesingnacionCentrosCostos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_working_information_branches_company_branch_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_company_branch_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropColumn(
                name: "company_branch_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.AlterColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "cost_center_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_working_information_branch_id",
                schema: "public",
                table: "working_information",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_working_information_cost_center_id",
                schema: "public",
                table: "working_information",
                column: "cost_center_id");

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_branches_branch_id",
                schema: "public",
                table: "working_information",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_cost_centers_cost_center_id",
                schema: "public",
                table: "working_information",
                column: "cost_center_id",
                principalSchema: "public",
                principalTable: "cost_centers",
                principalColumn: "cost_center_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_working_information_branches_branch_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropForeignKey(
                name: "FK_working_information_cost_centers_cost_center_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_branch_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_cost_center_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropColumn(
                name: "cost_center_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.AlterColumn<Guid>(
                name: "branch_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "company_branch_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_working_information_company_branch_id",
                schema: "public",
                table: "working_information",
                column: "company_branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_branches_company_branch_id",
                schema: "public",
                table: "working_information",
                column: "company_branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
