using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class StatusMerchandiseRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "ducat_registry",
                type: "duca_status_enum",
                nullable: false,
                defaultValueSql: "'pending'::duca_status_enum");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "customs_declarations",
                type: "duca_status_enum",
                nullable: false,
                defaultValueSql: "'pending'::duca_status_enum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "customs_declarations");
        }
    }
}
