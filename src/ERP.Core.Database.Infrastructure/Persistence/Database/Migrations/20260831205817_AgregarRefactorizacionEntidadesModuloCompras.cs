using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRefactorizacionEntidadesModuloCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requisition_accounting_reviews",
                schema: "public");

            migrationBuilder.DropTable(
                name: "requisition_management_reviews",
                schema: "public");

            migrationBuilder.RenameColumn(
                name: "observations",
                schema: "public",
                table: "purchase_requests",
                newName: "concept");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "public",
                table: "purchase_orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "comments",
                schema: "public",
                table: "purchase_orders",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "purchase_request_id",
                schema: "public",
                table: "purchase_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "reviewed_by_user_id",
                schema: "public",
                table: "purchase_orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "send_by_user_id",
                schema: "public",
                table: "purchase_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateOnly>(
                name: "send_to_review_at",
                schema: "public",
                table: "purchase_orders",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.CreateTable(
                name: "purchase_requests_reviewed_accounting",
                schema: "public",
                columns: table => new
                {
                    purchase_requests_reviewed_accounting_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    comments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    send_to_review_at = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "accounting_review_status_enum", nullable: false, defaultValueSql: "'pending'::accounting_review_status_enum"),
                    send_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reviewed_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_requests_reviewed_accounting", x => x.purchase_requests_reviewed_accounting_id);
                    table.ForeignKey(
                        name: "FK_purchase_requests_reviewed_accounting_purchase_requests_pur~",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_requests_reviewed_accounting_users_reviewed_by_use~",
                        column: x => x.reviewed_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_requests_reviewed_accounting_users_send_by_user_id",
                        column: x => x.send_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchase_requests_reviewed_management",
                schema: "public",
                columns: table => new
                {
                    purchase_requests_reviewed_management_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    comments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    send_to_review_at = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "management_review_status_enum", nullable: false, defaultValueSql: "'pending'::management_review_status_enum"),
                    send_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reviewed_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_requests_reviewed_management", x => x.purchase_requests_reviewed_management_id);
                    table.ForeignKey(
                        name: "FK_purchase_requests_reviewed_management_purchase_requests_pur~",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_requests_reviewed_management_users_reviewed_by_use~",
                        column: x => x.reviewed_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchase_requests_reviewed_management_users_send_by_user_id",
                        column: x => x.send_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchase_orders_purchase_request_id",
                schema: "public",
                table: "purchase_orders",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_orders_reviewed_by_user_id",
                schema: "public",
                table: "purchase_orders",
                column: "reviewed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_orders_send_by_user_id",
                schema: "public",
                table: "purchase_orders",
                column: "send_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reviewed_accounting_purchase_request_id",
                schema: "public",
                table: "purchase_requests_reviewed_accounting",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reviewed_accounting_reviewed_by_user_id",
                schema: "public",
                table: "purchase_requests_reviewed_accounting",
                column: "reviewed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reviewed_accounting_send_by_user_id",
                schema: "public",
                table: "purchase_requests_reviewed_accounting",
                column: "send_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reviewed_management_purchase_request_id",
                schema: "public",
                table: "purchase_requests_reviewed_management",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reviewed_management_reviewed_by_user_id",
                schema: "public",
                table: "purchase_requests_reviewed_management",
                column: "reviewed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_reviewed_management_send_by_user_id",
                schema: "public",
                table: "purchase_requests_reviewed_management",
                column: "send_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_orders_purchase_requests_purchase_request_id",
                schema: "public",
                table: "purchase_orders",
                column: "purchase_request_id",
                principalSchema: "public",
                principalTable: "purchase_requests",
                principalColumn: "purchase_request_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_orders_users_reviewed_by_user_id",
                schema: "public",
                table: "purchase_orders",
                column: "reviewed_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_orders_users_send_by_user_id",
                schema: "public",
                table: "purchase_orders",
                column: "send_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_orders_purchase_requests_purchase_request_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_orders_users_reviewed_by_user_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_orders_users_send_by_user_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropTable(
                name: "purchase_requests_reviewed_accounting",
                schema: "public");

            migrationBuilder.DropTable(
                name: "purchase_requests_reviewed_management",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_purchase_orders_purchase_request_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "IX_purchase_orders_reviewed_by_user_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "IX_purchase_orders_send_by_user_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "comments",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "purchase_request_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "reviewed_by_user_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "send_by_user_id",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "send_to_review_at",
                schema: "public",
                table: "purchase_orders");

            migrationBuilder.RenameColumn(
                name: "concept",
                schema: "public",
                table: "purchase_requests",
                newName: "observations");

            migrationBuilder.CreateTable(
                name: "requisition_accounting_reviews",
                schema: "public",
                columns: table => new
                {
                    requisition_accounting_review_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reviewed_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    send_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    comments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    send_to_review_at = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "accounting_review_status_enum", nullable: false, defaultValueSql: "'pending'::accounting_review_status_enum")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisition_accounting_reviews", x => x.requisition_accounting_review_id);
                    table.ForeignKey(
                        name: "FK_requisition_accounting_reviews_purchase_requests_purchase_r~",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_accounting_reviews_users_reviewed_by_user_id",
                        column: x => x.reviewed_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_accounting_reviews_users_send_by_user_id",
                        column: x => x.send_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "requisition_management_reviews",
                schema: "public",
                columns: table => new
                {
                    requisition_management_review_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    purchase_request_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reviewed_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    send_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    comments = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    send_to_review_at = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    status = table.Column<int>(type: "management_review_status_enum", nullable: false, defaultValueSql: "'pending'::management_review_status_enum")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisition_management_reviews", x => x.requisition_management_review_id);
                    table.ForeignKey(
                        name: "FK_requisition_management_reviews_purchase_requests_purchase_r~",
                        column: x => x.purchase_request_id,
                        principalSchema: "public",
                        principalTable: "purchase_requests",
                        principalColumn: "purchase_request_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_management_reviews_users_reviewed_by_user_id",
                        column: x => x.reviewed_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_management_reviews_users_send_by_user_id",
                        column: x => x.send_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requisition_accounting_reviews_purchase_request_id",
                schema: "public",
                table: "requisition_accounting_reviews",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requisition_accounting_reviews_reviewed_by_user_id",
                schema: "public",
                table: "requisition_accounting_reviews",
                column: "reviewed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requisition_accounting_reviews_send_by_user_id",
                schema: "public",
                table: "requisition_accounting_reviews",
                column: "send_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requisition_management_reviews_purchase_request_id",
                schema: "public",
                table: "requisition_management_reviews",
                column: "purchase_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_requisition_management_reviews_reviewed_by_user_id",
                schema: "public",
                table: "requisition_management_reviews",
                column: "reviewed_by_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_requisition_management_reviews_send_by_user_id",
                schema: "public",
                table: "requisition_management_reviews",
                column: "send_by_user_id");
        }
    }
}
