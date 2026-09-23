using System;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarReparcionReferenciaTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_transport_entrance_reception_entrance_reception_t~",
                schema: "public",
                table: "reception_transport_entrance");

            migrationBuilder.DropIndex(
                name: "IX_reception_entrance_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "reception_transport_entrance");

            migrationBuilder.DropColumn(
                name: "CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceptionEntranceId",
                schema: "public",
                table: "reception_transport_entrance",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "reception_entrance",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<JsonNode>(
                name: "additional_data",
                schema: "public",
                table: "reception_entrance",
                type: "jsonb",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reception_transport_entrance_ReceptionEntranceId",
                schema: "public",
                table: "reception_transport_entrance",
                column: "ReceptionEntranceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_transport_entrance_reception_entrance_ReceptionEn~",
                schema: "public",
                table: "reception_transport_entrance",
                column: "ReceptionEntranceId",
                principalSchema: "public",
                principalTable: "reception_entrance",
                principalColumn: "reception_entrance_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reception_transport_entrance_reception_entrance_ReceptionEn~",
                schema: "public",
                table: "reception_transport_entrance");

            migrationBuilder.DropIndex(
                name: "IX_reception_transport_entrance_ReceptionEntranceId",
                schema: "public",
                table: "reception_transport_entrance");

            migrationBuilder.DropColumn(
                name: "ReceptionEntranceId",
                schema: "public",
                table: "reception_transport_entrance");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AddColumn<JsonNode>(
                name: "additional_data",
                schema: "public",
                table: "reception_transport_entrance",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomsBranchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomsBranchesId",
                principalSchema: "public",
                principalTable: "customs_branches",
                principalColumn: "custom_branch_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reception_transport_entrance_reception_entrance_reception_t~",
                schema: "public",
                table: "reception_transport_entrance",
                column: "reception_transport_entrance_id",
                principalSchema: "public",
                principalTable: "reception_entrance",
                principalColumn: "reception_entrance_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
