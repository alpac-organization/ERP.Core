using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RepararDistribucionDatosColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personal_informations_sub_catalogs_departament_id",
                schema: "public",
                table: "personal_informations");

            migrationBuilder.DropIndex(
                name: "IX_personal_informations_departament_id",
                schema: "public",
                table: "personal_informations");

            migrationBuilder.DropColumn(
                name: "departament_id",
                schema: "public",
                table: "personal_informations");

            migrationBuilder.DropColumn(
                name: "gender",
                schema: "public",
                table: "collaborators");

            migrationBuilder.AddColumn<int>(
                name: "gender",
                schema: "public",
                table: "personal_informations",
                type: "gender_type_enum",
                nullable: false,
                defaultValueSql: "'man'::gender_type_enum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                schema: "public",
                table: "personal_informations");

            migrationBuilder.AddColumn<int>(
                name: "departament_id",
                schema: "public",
                table: "personal_informations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "gender",
                schema: "public",
                table: "collaborators",
                type: "gender_type_enum",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_personal_informations_departament_id",
                schema: "public",
                table: "personal_informations",
                column: "departament_id");

            migrationBuilder.AddForeignKey(
                name: "FK_personal_informations_sub_catalogs_departament_id",
                schema: "public",
                table: "personal_informations",
                column: "departament_id",
                principalSchema: "public",
                principalTable: "sub_catalogs",
                principalColumn: "sub_catalog_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
