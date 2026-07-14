using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CambioDeNombreTablaWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reception_details_managua",
                schema: "public");

            migrationBuilder.AlterColumn<Guid>(
                name: "service_order_id",
                schema: "public",
                table: "record_entrances_managua",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "reception_entrance",
                schema: "public",
                columns: table => new
                {
                    reception_entrance_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    country_of_origin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    aduana = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    gate_entrance_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    plate_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    trailer_chassis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    driver_license = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    transportista = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    medio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    driver_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    consignee = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    seal_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception_entrance", x => x.reception_entrance_id);
                    table.ForeignKey(
                        name: "FK_reception_entrance_record_entrances_managua_record_entrance~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reception_entrance_record_entrance_managua_id",
                schema: "public",
                table: "reception_entrance",
                column: "record_entrance_managua_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reception_entrance",
                schema: "public");

            migrationBuilder.AlterColumn<Guid>(
                name: "service_order_id",
                schema: "public",
                table: "record_entrances_managua",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "reception_details_managua",
                schema: "public",
                columns: table => new
                {
                    reception_details_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    record_entrance_managua_id = table.Column<Guid>(type: "uuid", nullable: false),
                    aduana = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    consignee = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    country_of_origin = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    driver_license = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    driver_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    gate_entrance_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    medio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    plate_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    seal_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    trailer_chassis = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    transportista = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reception_details_managua", x => x.reception_details_managua_id);
                    table.ForeignKey(
                        name: "FK_reception_details_managua_record_entrances_managua_record_e~",
                        column: x => x.record_entrance_managua_id,
                        principalSchema: "public",
                        principalTable: "record_entrances_managua",
                        principalColumn: "record_entrance_managua_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reception_details_managua_record_entrance_managua_id",
                schema: "public",
                table: "reception_details_managua",
                column: "record_entrance_managua_id",
                unique: true);
        }
    }
}
