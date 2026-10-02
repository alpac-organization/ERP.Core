using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class NullFildsOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shipping_company",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "sender",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "consignee",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shipping_company",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sender",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "consignee",
                schema: "public",
                table: "operational_orders",
                type: "character varying(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(70)",
                oldMaxLength: 70,
                oldNullable: true);
        }
    }
}
