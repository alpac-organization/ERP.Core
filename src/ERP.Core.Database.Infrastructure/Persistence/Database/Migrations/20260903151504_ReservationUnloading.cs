using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReservationUnloading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unloading_position_reservations",
                schema: "public",
                columns: table => new
                {
                    unloading_position_reservations_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    entrance_ducat_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_assignment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    warehouse_id = table.Column<Guid>(type: "uuid", nullable: false),
                    unloading_details_id = table.Column<Guid>(type: "uuid", nullable: true),
                    rack_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    lot_position_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    reserved_by_user_id = table.Column<string>(type: "text", nullable: false),
                    reserved_at_date = table.Column<DateOnly>(type: "date", nullable: false),
                    reserved_at_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unloading_position_reservations", x => x.unloading_position_reservations_id);
                    table.ForeignKey(
                        name: "FK_unloading_position_reservations_warehouse_assignments_wareh~",
                        column: x => x.warehouse_assignment_id,
                        principalSchema: "public",
                        principalTable: "warehouse_assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_unloading_position_reservations_warehouse_assignment_id",
                schema: "public",
                table: "unloading_position_reservations",
                column: "warehouse_assignment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unloading_position_reservations",
                schema: "public");
        }
    }
}
