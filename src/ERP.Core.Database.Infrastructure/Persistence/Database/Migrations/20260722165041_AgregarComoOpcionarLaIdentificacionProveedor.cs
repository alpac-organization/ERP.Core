using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarComoOpcionarLaIdentificacionProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "identification_type",
                schema: "public",
                table: "suppliers",
                type: "identification_type_enum",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "identification_type_enum");

            migrationBuilder.AlterColumn<string>(
                name: "identification_number",
                schema: "public",
                table: "suppliers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "identification_type",
                schema: "public",
                table: "suppliers",
                type: "identification_type_enum",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "identification_type_enum",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "identification_number",
                schema: "public",
                table: "suppliers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
