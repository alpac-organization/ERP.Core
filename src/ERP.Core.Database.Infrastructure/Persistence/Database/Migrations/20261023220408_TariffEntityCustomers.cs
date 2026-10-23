using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class TariffEntityCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_customer_credit_information_branch_payment_condition",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.RenameIndex(
                name: "ix_customer_credit_information_branch_id",
                schema: "public",
                table: "customer_credit_information",
                newName: "IX_customer_credit_information_branch_id");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                schema: "public",
                table: "customer_credit_information",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomersId",
                schema: "public",
                table: "customer_credit_information",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "customer_charges",
                schema: "public",
                columns: table => new
                {
                    customer_charges_id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceDescription = table.Column<string>(type: "text", nullable: true),
                    Format = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    measure_unit_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    usd_fee_amount = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    nio_fee_amount = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_charges", x => x.customer_charges_id);
                    table.ForeignKey(
                        name: "FK_customer_charges_branches_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "public",
                        principalTable: "branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_charges_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_charges_units_measurement_measure_unit_id",
                        column: x => x.measure_unit_id,
                        principalSchema: "public",
                        principalTable: "units_measurement",
                        principalColumn: "unit_measure_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_credit_information_CustomerId",
                schema: "public",
                table: "customer_credit_information",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_credit_information_CustomersId",
                schema: "public",
                table: "customer_credit_information",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_charges_branch_id",
                schema: "public",
                table: "customer_charges",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_charges_CustomerId",
                schema: "public",
                table: "customer_charges",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_charges_measure_unit_id",
                schema: "public",
                table: "customer_charges",
                column: "measure_unit_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_credit_information_branches_branch_id",
                schema: "public",
                table: "customer_credit_information",
                column: "branch_id",
                principalSchema: "public",
                principalTable: "branches",
                principalColumn: "branch_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_credit_information_customers_CustomerId",
                schema: "public",
                table: "customer_credit_information",
                column: "CustomerId",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_credit_information_customers_CustomersId",
                schema: "public",
                table: "customer_credit_information",
                column: "CustomersId",
                principalSchema: "public",
                principalTable: "customers",
                principalColumn: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_credit_information_branches_branch_id",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_credit_information_customers_CustomerId",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_credit_information_customers_CustomersId",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropTable(
                name: "customer_charges",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_customer_credit_information_CustomerId",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropIndex(
                name: "IX_customer_credit_information_CustomersId",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                schema: "public",
                table: "customer_credit_information");

            migrationBuilder.RenameIndex(
                name: "IX_customer_credit_information_branch_id",
                schema: "public",
                table: "customer_credit_information",
                newName: "ix_customer_credit_information_branch_id");

            migrationBuilder.CreateIndex(
                name: "ix_customer_credit_information_branch_payment_condition",
                schema: "public",
                table: "customer_credit_information",
                columns: new[] { "branch_id", "payment_condition" },
                unique: true);
        }
    }
}
