using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEmploymentPeriods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_settlements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_advances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "employment_periods",
                schema: "public",
                columns: table => new
                {
                    employment_period_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    collaborator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    collaborator_code = table.Column<string>(type: "text", nullable: false),
                    entry_date = table.Column<DateOnly>(type: "date", nullable: false),
                    departure_date = table.Column<DateOnly>(type: "date", nullable: true),
                    collaborator_termination_id = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employment_periods", x => x.employment_period_id);
                    table.CheckConstraint("ck_employment_periods_dates", "\"departure_date\" IS NULL OR \"departure_date\" >= \"entry_date\"");
                    table.ForeignKey(
                        name: "FK_employment_periods_collaborator_terminations_collaborator_t~",
                        column: x => x.collaborator_termination_id,
                        principalSchema: "public",
                        principalTable: "collaborator_terminations",
                        principalColumn: "termination_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employment_periods_collaborators_collaborator_id",
                        column: x => x.collaborator_id,
                        principalSchema: "public",
                        principalTable: "collaborators",
                        principalColumn: "collaborator_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_settlements_collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_settlements",
                column: "collaborator_period_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_advances_collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "collaborator_period_id");

            migrationBuilder.CreateIndex(
                name: "IX_christmas_bonus_accruals_collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_period_id");

            migrationBuilder.CreateIndex(
                name: "ix_employment_periods_collaborator_dates",
                schema: "public",
                table: "employment_periods",
                columns: new[] { "collaborator_id", "entry_date", "departure_date" });

            migrationBuilder.CreateIndex(
                name: "ux_employment_periods_collaborator_active",
                schema: "public",
                table: "employment_periods",
                column: "collaborator_id",
                unique: true,
                filter: "\"departure_date\" IS NULL AND \"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ux_employment_periods_collaborator_code",
                schema: "public",
                table: "employment_periods",
                column: "collaborator_code",
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "ux_employment_periods_termination",
                schema: "public",
                table: "employment_periods",
                column: "collaborator_termination_id",
                unique: true,
                filter: "\"collaborator_termination_id\" IS NOT NULL AND \"deleted_at\" IS NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_accruals_employment_periods_collaborator_pe~",
                schema: "public",
                table: "christmas_bonus_accruals",
                column: "collaborator_period_id",
                principalSchema: "public",
                principalTable: "employment_periods",
                principalColumn: "employment_period_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_advances_employment_periods_collaborator_pe~",
                schema: "public",
                table: "christmas_bonus_advances",
                column: "collaborator_period_id",
                principalSchema: "public",
                principalTable: "employment_periods",
                principalColumn: "employment_period_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_christmas_bonus_settlements_employment_periods_collaborator~",
                schema: "public",
                table: "christmas_bonus_settlements",
                column: "collaborator_period_id",
                principalSchema: "public",
                principalTable: "employment_periods",
                principalColumn: "employment_period_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_accruals_employment_periods_collaborator_pe~",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_advances_employment_periods_collaborator_pe~",
                schema: "public",
                table: "christmas_bonus_advances");

            migrationBuilder.DropForeignKey(
                name: "FK_christmas_bonus_settlements_employment_periods_collaborator~",
                schema: "public",
                table: "christmas_bonus_settlements");

            migrationBuilder.DropTable(
                name: "employment_periods",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_christmas_bonus_settlements_collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_settlements");

            migrationBuilder.DropIndex(
                name: "IX_christmas_bonus_advances_collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_advances");

            migrationBuilder.DropIndex(
                name: "IX_christmas_bonus_accruals_collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_accruals");

            migrationBuilder.DropColumn(
                name: "collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_settlements");

            migrationBuilder.DropColumn(
                name: "collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_advances");

            migrationBuilder.DropColumn(
                name: "collaborator_period_id",
                schema: "public",
                table: "christmas_bonus_accruals");
        }
    }
}
