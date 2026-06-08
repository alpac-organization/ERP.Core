using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNuevaTablaDeNominasContables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "accounting_payroll_id",
                schema: "public",
                table: "collaborators",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "types_accounting_payroll",
                schema: "public",
                columns: table => new
                {
                    type_income_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    accounting_payroll_name = table.Column<string>(name: "accounting_payroll_name ", type: "text", nullable: true),
                    accounting_payroll_code = table.Column<string>(type: "text", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_accounting_payroll", x => x.type_income_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "types_accounting_payroll",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "accounting_payroll_id",
                schema: "public",
                table: "collaborators");
        }
    }
}
