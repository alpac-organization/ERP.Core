using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgreagarRenombramientoColumnasOrdenesServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_order_requistions_purchase_requests_PurchaseRequest~",
                schema: "public",
                table: "service_order_requistions");

            migrationBuilder.DropForeignKey(
                name: "FK_service_order_requistions_services_orders_service_order_id",
                schema: "public",
                table: "service_order_requistions");

            migrationBuilder.DropForeignKey(
                name: "FK_service_order_requistions_users_created_by_user_id",
                schema: "public",
                table: "service_order_requistions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_service_order_requistions",
                schema: "public",
                table: "service_order_requistions");

            migrationBuilder.DropColumn(
                name: "AdditionalData",
                schema: "public",
                table: "service_order_requistions");

            migrationBuilder.RenameTable(
                name: "service_order_requistions",
                schema: "public",
                newName: "services_orders_requistions",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "SoRequitionCode",
                schema: "public",
                table: "services_orders_requistions",
                newName: "so_requisition_code");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestId",
                schema: "public",
                table: "services_orders_requistions",
                newName: "purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_service_order_requistions_PurchaseRequestId",
                schema: "public",
                table: "services_orders_requistions",
                newName: "IX_services_orders_requistions_purchase_request_id");

            migrationBuilder.RenameIndex(
                name: "IX_service_order_requistions_created_by_user_id",
                schema: "public",
                table: "services_orders_requistions",
                newName: "IX_services_orders_requistions_created_by_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "so_requisition_code",
                schema: "public",
                table: "services_orders_requistions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_services_orders_requistions",
                schema: "public",
                table: "services_orders_requistions",
                column: "services_order_requisition_id");

            migrationBuilder.AddForeignKey(
                name: "FK_services_orders_requistions_purchase_requests_purchase_requ~",
                schema: "public",
                table: "services_orders_requistions",
                column: "purchase_request_id",
                principalSchema: "public",
                principalTable: "purchase_requests",
                principalColumn: "purchase_request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_services_orders_requistions_services_orders_service_order_id",
                schema: "public",
                table: "services_orders_requistions",
                column: "service_order_id",
                principalSchema: "public",
                principalTable: "services_orders",
                principalColumn: "services_order_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_services_orders_requistions_users_created_by_user_id",
                schema: "public",
                table: "services_orders_requistions",
                column: "created_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_orders_requistions_purchase_requests_purchase_requ~",
                schema: "public",
                table: "services_orders_requistions");

            migrationBuilder.DropForeignKey(
                name: "FK_services_orders_requistions_services_orders_service_order_id",
                schema: "public",
                table: "services_orders_requistions");

            migrationBuilder.DropForeignKey(
                name: "FK_services_orders_requistions_users_created_by_user_id",
                schema: "public",
                table: "services_orders_requistions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_services_orders_requistions",
                schema: "public",
                table: "services_orders_requistions");

            migrationBuilder.RenameTable(
                name: "services_orders_requistions",
                schema: "public",
                newName: "service_order_requistions",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "so_requisition_code",
                schema: "public",
                table: "service_order_requistions",
                newName: "SoRequitionCode");

            migrationBuilder.RenameColumn(
                name: "purchase_request_id",
                schema: "public",
                table: "service_order_requistions",
                newName: "PurchaseRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_services_orders_requistions_purchase_request_id",
                schema: "public",
                table: "service_order_requistions",
                newName: "IX_service_order_requistions_PurchaseRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_services_orders_requistions_created_by_user_id",
                schema: "public",
                table: "service_order_requistions",
                newName: "IX_service_order_requistions_created_by_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "SoRequitionCode",
                schema: "public",
                table: "service_order_requistions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalData",
                schema: "public",
                table: "service_order_requistions",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_service_order_requistions",
                schema: "public",
                table: "service_order_requistions",
                column: "services_order_requisition_id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_order_requistions_purchase_requests_PurchaseRequest~",
                schema: "public",
                table: "service_order_requistions",
                column: "PurchaseRequestId",
                principalSchema: "public",
                principalTable: "purchase_requests",
                principalColumn: "purchase_request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_service_order_requistions_services_orders_service_order_id",
                schema: "public",
                table: "service_order_requistions",
                column: "service_order_id",
                principalSchema: "public",
                principalTable: "services_orders",
                principalColumn: "services_order_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_service_order_requistions_users_created_by_user_id",
                schema: "public",
                table: "service_order_requistions",
                column: "created_by_user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
