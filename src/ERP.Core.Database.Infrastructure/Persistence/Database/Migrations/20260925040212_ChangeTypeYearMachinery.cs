using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeYearMachinery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                schema: "public",
                table: "machineries",
                newName: "year");

            migrationBuilder.AlterColumn<string>(
                name: "year",
                schema: "public",
                table: "machineries",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "year",
                schema: "public",
                table: "machineries",
                newName: "Year");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                schema: "public",
                table: "machineries",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4);
        }
    }
}
