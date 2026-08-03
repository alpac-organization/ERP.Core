using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CamposEnDucaAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_record_entrances_service_orders_service_order_id",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropIndex(
                name: "IX_record_entrances_service_order_id",
                schema: "public",
                table: "record_entrances");
        }
    }
}
