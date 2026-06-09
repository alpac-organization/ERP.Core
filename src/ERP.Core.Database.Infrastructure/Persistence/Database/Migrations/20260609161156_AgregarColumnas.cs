using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "payroll_period",
                schema: "public",
                table: "payrolls",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "payroll_period_enum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "payroll_period",
                schema: "public",
                table: "payrolls",
                type: "payroll_period_enum",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
