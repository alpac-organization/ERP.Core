using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRenombramientoParaTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                schema: "public",
                table: "customers",
                newName: "deleted_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");


            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.CreateTable(
                name: "service_orders",
                schema: "public",
                columns: table => new
                {
                    service_order_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_orders", x => x.service_order_id);
                    table.ForeignKey(
                        name: "FK_service_orders_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_service_order_id",
                schema: "public",
                table: "service_orders",
                column: "service_order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_service_orders_company_id",
                schema: "public",
                table: "service_orders",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "service_orders",
                schema: "public");


            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "customers");


            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "public",
                table: "customers",
                newName: "DeletedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "warehouses",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
