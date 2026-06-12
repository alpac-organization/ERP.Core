using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntidadesServiciosProfesionales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alpac_additional_data",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.DropColumn(
                name: "avasa_additional_data",
                schema: "public",
                table: "professional_services_payrolls");

            migrationBuilder.CreateTable(
                name: "payment_fees",
                schema: "public",
                columns: table => new
                {
                    payment_fess_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    amount = table.Column<decimal>(type: "numeric", maxLength: 180, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, defaultValue: "Sin descripción"),
                    currency = table.Column<int>(type: "currency_enum", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_fees", x => x.payment_fess_id);
                    table.ForeignKey(
                        name: "FK_payment_fees_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assistance_control",
                schema: "public",
                columns: table => new
                {
                    assistance_control_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    shift_date = table.Column<DateOnly>(type: "date", nullable: false),
                    amount_hours = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    location_id = table.Column<Guid>(type: "uuid", nullable: false),
                    professioal_payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assistance_control", x => x.assistance_control_id);
                    table.ForeignKey(
                        name: "FK_assistance_control_professional_services_payrolls_professio~",
                        column: x => x.professioal_payroll_id,
                        principalSchema: "public",
                        principalTable: "professional_services_payrolls",
                        principalColumn: "professional_services_payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                schema: "public",
                columns: table => new
                {
                    location_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    location_name = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssistanceControlId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssistanceControlId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.location_id);
                    table.ForeignKey(
                        name: "FK_locations_assistance_control_AssistanceControlId1",
                        column: x => x.AssistanceControlId1,
                        principalSchema: "public",
                        principalTable: "assistance_control",
                        principalColumn: "assistance_control_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locations_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assistance_control_location_id",
                schema: "public",
                table: "assistance_control",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_assistance_control_professioal_payroll_id",
                schema: "public",
                table: "assistance_control",
                column: "professioal_payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_id",
                schema: "public",
                table: "locations",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_locations_AssistanceControlId1",
                schema: "public",
                table: "locations",
                column: "AssistanceControlId1");

            migrationBuilder.CreateIndex(
                name: "IX_locations_company_id",
                schema: "public",
                table: "locations",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_payment_fees_company_id",
                schema: "public",
                table: "payment_fees",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_fees_id",
                schema: "public",
                table: "payment_fees",
                column: "payment_fess_id");

            migrationBuilder.AddForeignKey(
                name: "FK_assistance_control_locations_location_id",
                schema: "public",
                table: "assistance_control",
                column: "location_id",
                principalSchema: "public",
                principalTable: "locations",
                principalColumn: "location_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assistance_control_locations_location_id",
                schema: "public",
                table: "assistance_control");

            migrationBuilder.DropTable(
                name: "payment_fees",
                schema: "public");

            migrationBuilder.DropTable(
                name: "locations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "assistance_control",
                schema: "public");

            migrationBuilder.AddColumn<string>(
                name: "alpac_additional_data",
                schema: "public",
                table: "professional_services_payrolls",
                type: "jsonb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "avasa_additional_data",
                schema: "public",
                table: "professional_services_payrolls",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
