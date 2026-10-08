using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class InformationPallets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_positinating_information",
                schema: "public",
                table: "assignment_operational",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "merchandise_type",
                schema: "public",
                table: "assignment_operational",
                type: "unloading_merchandise_type_enum",
                nullable: false,
                defaultValueSql: "'bulk'::unloading_merchandise_type_enum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_positinating_information",
                schema: "public",
                table: "assignment_operational");

            migrationBuilder.DropColumn(
                name: "merchandise_type",
                schema: "public",
                table: "assignment_operational");
        }
    }
}
