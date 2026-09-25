using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMetodosPagoQueAceptaUnProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment_condition",
                schema: "public",
                table: "quotations");

            migrationBuilder.CreateTable(
                name: "supplier_payment_methods",
                schema: "public",
                columns: table => new
                {
                    supplier_payment_method_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    supplier_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_method_type = table.Column<int>(type: "payment_method_type_enum", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier_payment_methods", x => x.supplier_payment_method_id);
                    table.ForeignKey(
                        name: "FK_supplier_payment_methods_suppliers_supplier_id",
                        column: x => x.supplier_id,
                        principalSchema: "public",
                        principalTable: "suppliers",
                        principalColumn: "suppliers_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_supplier_payment_methods_supplier_id",
                schema: "public",
                table: "supplier_payment_methods",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_payment_methods_supplier_payment_type",
                schema: "public",
                table: "supplier_payment_methods",
                columns: new[] { "supplier_id", "payment_method_type" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supplier_payment_methods",
                schema: "public");

            migrationBuilder.AddColumn<int>(
                name: "payment_condition",
                schema: "public",
                table: "quotations",
                type: "payment_condition_enum",
                nullable: false,
                defaultValueSql: "'cash'::payment_condition_enum");
        }
    }
}
