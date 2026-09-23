using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRestructuracionColumnasCatalogoAdunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "customs_branches",
                newName: "customs_branch_name");

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                schema: "public",
                table: "customs_branches",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                schema: "public",
                table: "customs_branches");

            migrationBuilder.DropColumn(
                name: "is_active",
                schema: "public",
                table: "customs_branches");

            migrationBuilder.RenameColumn(
                name: "customs_branch_name",
                schema: "public",
                table: "customs_branches",
                newName: "name");
        }
    }
}
