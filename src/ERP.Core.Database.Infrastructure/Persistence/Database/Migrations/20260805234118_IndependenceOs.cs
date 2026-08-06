using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class IndependenceOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_service_orders_service_order_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_service_order_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropColumn(
                name: "service_order_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.AddColumn<string>(
                name: "service_order_code",
                schema: "public",
                table: "entrance_ducats",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "service_order_id",
                schema: "public",
                table: "entrance_ducats",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "service_order_code",
                schema: "public",
                table: "customs_declarations",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "service_order_id",
                schema: "public",
                table: "customs_declarations",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entrance_ducats_service_order_id",
                schema: "public",
                table: "entrance_ducats",
                column: "service_order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customs_declarations_service_order_id",
                schema: "public",
                table: "customs_declarations",
                column: "service_order_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_customs_declarations_service_orders_service_order_id",
                schema: "public",
                table: "customs_declarations",
                column: "service_order_id",
                principalSchema: "public",
                principalTable: "service_orders",
                principalColumn: "service_order_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entrance_ducats_service_orders_service_order_id",
                schema: "public",
                table: "entrance_ducats",
                column: "service_order_id",
                principalSchema: "public",
                principalTable: "service_orders",
                principalColumn: "service_order_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customs_declarations_service_orders_service_order_id",
                schema: "public",
                table: "customs_declarations");

            migrationBuilder.DropForeignKey(
                name: "FK_entrance_ducats_service_orders_service_order_id",
                schema: "public",
                table: "entrance_ducats");

            migrationBuilder.DropIndex(
                name: "IX_entrance_ducats_service_order_id",
                schema: "public",
                table: "entrance_ducats");

            migrationBuilder.DropIndex(
                name: "IX_customs_declarations_service_order_id",
                schema: "public",
                table: "customs_declarations");

            migrationBuilder.DropColumn(
                name: "service_order_code",
                schema: "public",
                table: "entrance_ducats");

            migrationBuilder.DropColumn(
                name: "service_order_id",
                schema: "public",
                table: "entrance_ducats");

            migrationBuilder.DropColumn(
                name: "service_order_code",
                schema: "public",
                table: "customs_declarations");

            migrationBuilder.DropColumn(
                name: "service_order_id",
                schema: "public",
                table: "customs_declarations");

            migrationBuilder.AddColumn<Guid>(
                name: "service_order_id",
                schema: "public",
                table: "record_entrances",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_record_entrances_service_order_id",
                schema: "public",
                table: "record_entrances",
                column: "service_order_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_record_entrances_service_orders_service_order_id",
                schema: "public",
                table: "record_entrances",
                column: "service_order_id",
                principalSchema: "public",
                principalTable: "service_orders",
                principalColumn: "service_order_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
