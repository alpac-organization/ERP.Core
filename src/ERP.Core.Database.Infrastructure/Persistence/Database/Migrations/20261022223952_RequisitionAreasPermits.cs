using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RequisitionAreasPermits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requisition_operational_areas_permitted",
                schema: "public",
                columns: table => new
                {
                    requisition_operational_area_permitted_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    area_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    set_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_permited = table.Column<int>(type: "product_usage_type_enum", nullable: false, defaultValueSql: "'administrative'::product_usage_type_enum"),
                    area_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    company_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    set_by_user_name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisition_operational_areas_permitted", x => x.requisition_operational_area_permitted_id);
                    table.ForeignKey(
                        name: "FK_requisition_operational_areas_permitted_companies_company_id",
                        column: x => x.company_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_operational_areas_permitted_users_set_by_user_id",
                        column: x => x.set_by_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisition_operational_areas_permitted_work_areas_area_id",
                        column: x => x.area_id,
                        principalSchema: "public",
                        principalTable: "work_areas",
                        principalColumn: "work_area_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requisition_operational_areas_permitted_area_id",
                schema: "public",
                table: "requisition_operational_areas_permitted",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_requisition_operational_areas_permitted_company_id",
                schema: "public",
                table: "requisition_operational_areas_permitted",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_requisition_operational_areas_permitted_set_by_user_id",
                schema: "public",
                table: "requisition_operational_areas_permitted",
                column: "set_by_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requisition_operational_areas_permitted",
                schema: "public");
        }
    }
}
