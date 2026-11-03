using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class ApprovedAnnulledSupplyRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "annulled_by_user_chief_id",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "approved_by_user_chief_id",
                schema: "public",
                table: "supply_requests",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "annulled_by_user_chief_id",
                schema: "public",
                table: "supply_requests");

            migrationBuilder.DropColumn(
                name: "approved_by_user_chief_id",
                schema: "public",
                table: "supply_requests");
        }
    }
}
