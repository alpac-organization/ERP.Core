using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCompanyEnPermitTypePolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ux_permit_type_policies_rule",
                schema: "public",
                table: "permission_type_policies");

            migrationBuilder.AddColumn<Guid>(
                name: "company_id",
                schema: "public",
                table: "permission_type_policies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ux_permit_type_policies_company_rule",
                schema: "public",
                table: "permission_type_policies",
                columns: new[] { "company_id", "permit_application_type", "beneficiary_scope", "family_relationship" },
                unique: true,
                filter: "deleted_at IS NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_permission_type_policies_companies_company_id",
                schema: "public",
                table: "permission_type_policies",
                column: "company_id",
                principalSchema: "public",
                principalTable: "companies",
                principalColumn: "company_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permission_type_policies_companies_company_id",
                schema: "public",
                table: "permission_type_policies");

            migrationBuilder.DropIndex(
                name: "ux_permit_type_policies_company_rule",
                schema: "public",
                table: "permission_type_policies");

            migrationBuilder.DropColumn(
                name: "company_id",
                schema: "public",
                table: "permission_type_policies");

            migrationBuilder.CreateIndex(
                name: "ux_permit_type_policies_rule",
                schema: "public",
                table: "permission_type_policies",
                columns: new[] { "permit_application_type", "beneficiary_scope", "family_relationship" },
                unique: true,
                filter: "deleted_at IS NULL");
        }
    }
}
