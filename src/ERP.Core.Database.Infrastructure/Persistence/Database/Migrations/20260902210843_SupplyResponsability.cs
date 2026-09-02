using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class SupplyResponsability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                schema: "public",
                table: "unloading_supplies");

            migrationBuilder.AddColumn<Guid>(
                name: "supplies_id",
                schema: "public",
                table: "unloading_supplies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "supplies",
                schema: "public",
                columns: table => new
                {
                    supplies_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplies", x => x.supplies_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_unloading_supplies_supplies_id",
                schema: "public",
                table: "unloading_supplies",
                column: "supplies_id");

            migrationBuilder.AddForeignKey(
                name: "FK_unloading_supplies_supplies_supplies_id",
                schema: "public",
                table: "unloading_supplies",
                column: "supplies_id",
                principalSchema: "public",
                principalTable: "supplies",
                principalColumn: "supplies_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_unloading_supplies_supplies_supplies_id",
                schema: "public",
                table: "unloading_supplies");

            migrationBuilder.DropTable(
                name: "supplies",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_unloading_supplies_supplies_id",
                schema: "public",
                table: "unloading_supplies");

            migrationBuilder.DropColumn(
                name: "supplies_id",
                schema: "public",
                table: "unloading_supplies");

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "public",
                table: "unloading_supplies",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
