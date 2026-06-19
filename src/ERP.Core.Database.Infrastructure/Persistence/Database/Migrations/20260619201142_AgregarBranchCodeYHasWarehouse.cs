using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarBranchCodeYHasWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "branch_code",
                schema: "public",
                table: "branches",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "has_warehouse",
                schema: "public",
                table: "branches",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_branches_branch_code",
                schema: "public",
                table: "branches",
                column: "branch_code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP INDEX IF EXISTS public.""IX_branches_branch_code"";");

            migrationBuilder.DropColumn(
                name: "branch_code",
                schema: "public",
                table: "branches");

            migrationBuilder.DropColumn(
                name: "has_warehouse",
                schema: "public",
                table: "branches");
        }
    }
}
