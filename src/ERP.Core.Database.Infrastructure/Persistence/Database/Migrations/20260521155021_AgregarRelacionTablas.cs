using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypesSubsidyId",
                schema: "public",
                table: "subsidies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "type_subsidy_id",
                schema: "public",
                table: "subsidies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_subsidies_TypesSubsidyId",
                schema: "public",
                table: "subsidies",
                column: "TypesSubsidyId");

            migrationBuilder.AddForeignKey(
                name: "FK_subsidies_types_subsidy_TypesSubsidyId",
                schema: "public",
                table: "subsidies",
                column: "TypesSubsidyId",
                principalSchema: "public",
                principalTable: "types_subsidy",
                principalColumn: "type_subsidy_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subsidies_types_subsidy_TypesSubsidyId",
                schema: "public",
                table: "subsidies");

            migrationBuilder.DropIndex(
                name: "IX_subsidies_TypesSubsidyId",
                schema: "public",
                table: "subsidies");

            migrationBuilder.DropColumn(
                name: "TypesSubsidyId",
                schema: "public",
                table: "subsidies");

            migrationBuilder.DropColumn(
                name: "type_subsidy_id",
                schema: "public",
                table: "subsidies");
        }
    }
}
