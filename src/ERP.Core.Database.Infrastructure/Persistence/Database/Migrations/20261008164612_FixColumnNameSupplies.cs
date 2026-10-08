using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNameSupplies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                schema: "public",
                table: "supplies",
                newName: "category");

            migrationBuilder.AlterColumn<int>(
                name: "unit_measure",
                schema: "public",
                table: "supplies",
                type: "unit_measure_enum",
                nullable: false,
                defaultValueSql: "'none'::unit_measure_enum",
                oldClrType: typeof(int),
                oldType: "supply_category_enum",
                oldDefaultValueSql: "'none'::supply_category_enum");

            migrationBuilder.AlterColumn<int>(
                name: "category",
                schema: "public",
                table: "supplies",
                type: "supply_category_enum",
                nullable: false,
                defaultValueSql: "'none'::supply_category_enum",
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category",
                schema: "public",
                table: "supplies",
                newName: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "unit_measure",
                schema: "public",
                table: "supplies",
                type: "supply_category_enum",
                nullable: false,
                defaultValueSql: "'none'::supply_category_enum",
                oldClrType: typeof(int),
                oldType: "unit_measure_enum",
                oldDefaultValueSql: "'none'::unit_measure_enum");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                schema: "public",
                table: "supplies",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "supply_category_enum",
                oldDefaultValueSql: "'none'::supply_category_enum");
        }
    }
}
