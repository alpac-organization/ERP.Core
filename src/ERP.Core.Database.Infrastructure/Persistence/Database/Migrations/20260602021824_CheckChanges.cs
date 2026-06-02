using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CheckChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inss_accounting_information",
                schema: "public",
                columns: table => new
                {
                    inss_information_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    inatec = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inss_labor = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    inss_patronal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    is_the_end_month = table.Column<bool>(type: "boolean", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inss_accounting_information", x => x.inss_information_id);
                    table.ForeignKey(
                        name: "FK_inss_accounting_information_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inss_accounting_information_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalSchema: "public",
                        principalTable: "payrolls",
                        principalColumn: "payroll_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inss_accounting_information_collaborator_id",
                schema: "public",
                table: "inss_accounting_information",
                column: "collaborator_id");

            migrationBuilder.CreateIndex(
                name: "IX_inss_accounting_information_payroll_id",
                schema: "public",
                table: "inss_accounting_information",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "ix_inss_information_id",
                schema: "public",
                table: "inss_accounting_information",
                column: "inss_information_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inss_accounting_information",
                schema: "public");
        }
    }
}
