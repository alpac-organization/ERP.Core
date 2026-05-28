using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarBanderaParaDeduccionesViaticos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_with_range_date",
                schema: "public",
                table: "permit_applications",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_with_range_date",
                schema: "public",
                table: "permit_applications");
        }
    }
}
