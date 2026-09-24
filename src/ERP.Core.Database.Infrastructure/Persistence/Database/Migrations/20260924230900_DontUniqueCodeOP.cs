using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class DontUniqueCodeOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_operational_orders_op_code",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.CreateIndex(
                name: "ix_operational_orders_op_code",
                schema: "public",
                table: "operational_orders",
                column: "op_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_operational_orders_op_code",
                schema: "public",
                table: "operational_orders");

            migrationBuilder.CreateIndex(
                name: "ix_operational_orders_op_code",
                schema: "public",
                table: "operational_orders",
                column: "op_code",
                unique: true);
        }
    }
}
