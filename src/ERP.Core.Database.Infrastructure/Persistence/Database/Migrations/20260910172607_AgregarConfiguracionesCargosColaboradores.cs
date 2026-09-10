using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarConfiguracionesCargosColaboradores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "job_position_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_working_information_job_position_id",
                schema: "public",
                table: "working_information",
                column: "job_position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_working_information_job_positions_job_position_id",
                schema: "public",
                table: "working_information",
                column: "job_position_id",
                principalSchema: "public",
                principalTable: "job_positions",
                principalColumn: "job_position_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_working_information_job_positions_job_position_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.DropIndex(
                name: "IX_working_information_job_position_id",
                schema: "public",
                table: "working_information");

            migrationBuilder.AlterColumn<Guid>(
                name: "job_position_id",
                schema: "public",
                table: "working_information",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
