using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarIsFirstTimeRegisterCollaborator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_first_time_register",
                schema: "public",
                table: "collaborators",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
            name: "is_first_time_register",
            schema: "public",
            table: "collaborators",
            type: "boolean",
            nullable: false,
            defaultValue: true,
            oldClrType: typeof(bool),
            oldType: "boolean",
            oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_first_time_register",
                schema: "public",
                table: "collaborators");
        }
    }
}
