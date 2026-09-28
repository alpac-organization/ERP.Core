using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CodeGeneratorToPOandOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_racks_section_id_code",
                schema: "public",
                table: "racks");

            migrationBuilder.CreateIndex(
                name: "ix_racks_section_id_code",
                schema: "public",
                table: "racks",
                columns: new[] { "section_id", "code" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_racks_section_id_code",
                schema: "public",
                table: "racks");

            migrationBuilder.CreateIndex(
                name: "ix_racks_section_id_code",
                schema: "public",
                table: "racks",
                columns: new[] { "section_id", "code" },
                unique: true);
        }
    }
}
