using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixesEntitiesReceptionOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duca_numbers",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "evidence_urls",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_by_user_name",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_date",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "updated_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<JsonNode>(
                name: "additional_data",
                schema: "public",
                table: "reception_entrance",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "reception_id",
                schema: "public",
                table: "operational_orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customs_branch_name",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomsBranchesId");

            migrationBuilder.CreateIndex(
                name: "ix_operational_orders_reception_id",
                schema: "public",
                table: "operational_orders",
                column: "reception_id");

            migrationBuilder.AddForeignKey(
                name: "FK_operational_orders_reception_entrance_reception_id",
                schema: "public",
                table: "operational_orders",
                column: "reception_id",
                principalSchema: "public",
                principalTable: "reception_entrance",
                principalColumn: "reception_entrance_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance",
                column: "CustomsBranchesId",
                principalSchema: "public",
                principalTable: "customs_branches",
                principalColumn: "custom_branch_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operational_orders_reception_entrance_reception_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_reception_entrance_customs_branches_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropIndex(
                name: "IX_reception_entrance_CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropIndex(
                name: "ix_operational_orders_reception_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.DropColumn(
                name: "CustomsBranchesId",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.DropColumn(
                name: "reception_id",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.AddColumn<List<string>>(
                name: "duca_numbers",
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

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_id",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_name",
                schema: "public",
                table: "reception_entrance",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "updated_date",
                schema: "public",
                table: "reception_entrance",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "updated_time",
                schema: "public",
                table: "reception_entrance",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customs_branch_name",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "public",
                table: "customs_branches",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
