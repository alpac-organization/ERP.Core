using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadesDiasFeriados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "public",
                table: "permit_applications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "public",
                table: "permit_applications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PayrolId",
                schema: "public",
                table: "permit_applications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "holidays",
                schema: "public",
                columns: table => new
                {
                    holiday_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: true),
                    holiday_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    day = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    is_global = table.Column<bool>(type: "boolean", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_holidays", x => x.holiday_id);
                });

            migrationBuilder.CreateTable(
                name: "permit_applications_pending",
                schema: "public",
                columns: table => new
                {
                    permit_application_pending_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    permit_application_type = table.Column<int>(type: "permit_application_type_enum", nullable: false),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false),
                    requested_by = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permit_applications_pending", x => x.permit_application_pending_id);
                    table.ForeignKey(
                        name: "FK_permit_applications_pending_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permit_applications_PayrolId",
                schema: "public",
                table: "permit_applications",
                column: "PayrolId");

            migrationBuilder.CreateIndex(
                name: "ix_holiday_id",
                schema: "public",
                table: "holidays",
                column: "holiday_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_permit_application_pending_id",
                schema: "public",
                table: "permit_applications_pending",
                column: "permit_application_pending_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permit_applications_pending_collaborator_id",
                schema: "public",
                table: "permit_applications_pending",
                column: "collaborator_id");

            migrationBuilder.AddForeignKey(
                name: "FK_permit_applications_payrolls_PayrolId",
                schema: "public",
                table: "permit_applications",
                column: "PayrolId",
                principalSchema: "public",
                principalTable: "payrolls",
                principalColumn: "payroll_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permit_applications_payrolls_PayrolId",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.DropTable(
                name: "holidays",
                schema: "public");

            migrationBuilder.DropTable(
                name: "permit_applications_pending",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_permit_applications_PayrolId",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.DropColumn(
                name: "PayrolId",
                schema: "public",
                table: "permit_applications");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                schema: "public",
                table: "permit_applications",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "public",
                table: "permit_applications",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
