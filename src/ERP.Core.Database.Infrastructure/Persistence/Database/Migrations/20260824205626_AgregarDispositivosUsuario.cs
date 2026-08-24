using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDispositivosUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "device_token",
                schema: "public",
                table: "users_profiles");

            migrationBuilder.CreateTable(
                name: "devices",
                schema: "public",
                columns: table => new
                {
                    device_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    fcm_token = table.Column<string>(type: "text", nullable: false),
                    endpoint_arn = table.Column<string>(type: "text", nullable: false),
                    device_name = table.Column<string>(type: "text", nullable: false),
                    user_profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.device_id);
                    table.ForeignKey(
                        name: "FK_devices_users_profiles_user_profile_id",
                        column: x => x.user_profile_id,
                        principalSchema: "public",
                        principalTable: "users_profiles",
                        principalColumn: "user_profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_devices_user_profile_id",
                schema: "public",
                table: "devices",
                column: "user_profile_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devices",
                schema: "public");

            migrationBuilder.AddColumn<string>(
                name: "device_token",
                schema: "public",
                table: "users_profiles",
                type: "text",
                nullable: true);
        }
    }
}
