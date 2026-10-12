using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPaymentRequestYUnicidadCodigos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payment_requests",
                schema: "public",
                columns: table => new
                {
                    payment_request_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    payment_method_type = table.Column<int>(type: "payment_method_type_enum", nullable: false),
                    purchase_order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_requests", x => x.payment_request_id);
                    table.ForeignKey(
                        name: "FK_payment_requests_purchase_orders_purchase_order_id",
                        column: x => x.purchase_order_id,
                        principalSchema: "public",
                        principalTable: "purchase_orders",
                        principalColumn: "purchase_order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ux_purchase_requests_code",
                schema: "public",
                table: "purchase_requests",
                column: "code",
                unique: true,
                filter: "\"deleted_at\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_payment_requests_purchase_order_id",
                schema: "public",
                table: "payment_requests",
                column: "purchase_order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_payment_requests_code",
                schema: "public",
                table: "payment_requests",
                column: "code",
                unique: true,
                filter: "\"deleted_at\" IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_requests",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ux_purchase_requests_code",
                schema: "public",
                table: "purchase_requests");
        }
    }
}
