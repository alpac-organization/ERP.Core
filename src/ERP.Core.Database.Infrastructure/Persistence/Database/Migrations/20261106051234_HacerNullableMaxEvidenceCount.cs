using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class HacerNullableMaxEvidenceCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_permit_type_policies_evidence",
                schema: "public",
                table: "permission_type_policies");

            migrationBuilder.AlterColumn<int>(
                name: "max_evidence_count",
                schema: "public",
                table: "permission_type_policies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "ck_permit_type_policies_evidence",
                schema: "public",
                table: "permission_type_policies",
                sql: "(requires_evidence = false AND min_evidence_count = 0 AND max_evidence_count = 0) OR (requires_evidence = true AND min_evidence_count >= 1 AND (max_evidence_count IS NULL OR max_evidence_count >= min_evidence_count))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_permit_type_policies_evidence",
                schema: "public",
                table: "permission_type_policies");

            migrationBuilder.AlterColumn<int>(
                name: "max_evidence_count",
                schema: "public",
                table: "permission_type_policies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "ck_permit_type_policies_evidence",
                schema: "public",
                table: "permission_type_policies",
                sql: "min_evidence_count >= 0 AND max_evidence_count >= min_evidence_count");
        }
    }
}
