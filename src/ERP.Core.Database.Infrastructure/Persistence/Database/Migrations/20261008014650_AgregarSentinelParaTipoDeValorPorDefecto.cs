using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSentinelParaTipoDeValorPorDefecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "public",
                table: "assignment_operational",
                type: "assignment_operational_status_enum",
                nullable: false,
                defaultValueSql: "'none'::assignment_operational_status_enum",
                oldClrType: typeof(int),
                oldType: "assignment_operational_status_enum",
                oldDefaultValueSql: "'pending'::assignment_operational_status_enum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "status",
                schema: "public",
                table: "assignment_operational",
                type: "assignment_operational_status_enum",
                nullable: false,
                defaultValueSql: "'pending'::assignment_operational_status_enum",
                oldClrType: typeof(int),
                oldType: "assignment_operational_status_enum",
                oldDefaultValueSql: "'none'::assignment_operational_status_enum");
        }
    }
}
