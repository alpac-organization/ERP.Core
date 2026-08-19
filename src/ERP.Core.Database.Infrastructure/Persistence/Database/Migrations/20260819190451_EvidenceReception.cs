using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class EvidenceReception : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seal_evidence",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AddColumn<List<string>>(
                name: "deleted_evidence_urls",
                schema: "public",
                table: "reception_entrance",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "evidence_urls",
                schema: "public",
                table: "reception_entrance",
                type: "text[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_evidence_urls",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "evidence_urls",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AddColumn<string>(
                name: "seal_evidence",
                schema: "public",
                table: "reception_entrance",
                type: "jsonb",
                nullable: false,
                defaultValue: "");
        }
    }
}
