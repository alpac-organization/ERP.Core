using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class CambiosEntidadesDuca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_category_products_category_product_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "registry_date",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.RenameColumn(
                name: "category_product_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ducat_registry_details_category_product_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "IX_ducat_registry_details_product_id");

            migrationBuilder.RenameColumn(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry",
                newName: "RegisteredByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "product_description",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "destination_area_observation",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_id",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_name",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "updated_date",
                schema: "public",
                table: "ducat_registry_details",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "updated_time",
                schema: "public",
                table: "ducat_registry_details",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegisteredByUserId",
                schema: "public",
                table: "ducat_registry",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_id",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_user_name",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "updated_date",
                schema: "public",
                table: "ducat_registry",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "updated_time",
                schema: "public",
                table: "ducat_registry",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_products_product_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "product_id",
                principalSchema: "public",
                principalTable: "products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ducat_registry_details_products_product_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "updated_by_user_name",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "updated_date",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "updated_time",
                schema: "public",
                table: "ducat_registry_details");

            migrationBuilder.DropColumn(
                name: "updated_by_user_id",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "updated_by_user_name",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "updated_date",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.DropColumn(
                name: "updated_time",
                schema: "public",
                table: "ducat_registry");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "category_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ducat_registry_details_product_id",
                schema: "public",
                table: "ducat_registry_details",
                newName: "IX_ducat_registry_details_category_product_id");

            migrationBuilder.RenameColumn(
                name: "RegisteredByUserId",
                schema: "public",
                table: "ducat_registry",
                newName: "registered_by_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "product_description",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "destination_area_observation",
                schema: "public",
                table: "ducat_registry_details",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "registered_by_user_id",
                schema: "public",
                table: "ducat_registry",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "registry_date",
                schema: "public",
                table: "ducat_registry",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ducat_registry_details_category_products_category_product_id",
                schema: "public",
                table: "ducat_registry_details",
                column: "category_product_id",
                principalSchema: "public",
                principalTable: "category_products",
                principalColumn: "category_product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
