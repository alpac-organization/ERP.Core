using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarPropiedadesAsignar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_machinery_assignments_warehouse_machinery_machinery_code",
                schema: "public",
                table: "machinery_assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_warehouse_machinery",
                schema: "public",
                table: "warehouse_machinery");

            migrationBuilder.RenameTable(
                name: "warehouse_machinery",
                schema: "public",
                newName: "machinery_catalogs",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "machinery_code",
                schema: "public",
                table: "machinery_assignments",
                newName: "machinery_id");

            migrationBuilder.RenameIndex(
                name: "IX_machinery_assignments_machinery_code",
                schema: "public",
                table: "machinery_assignments",
                newName: "IX_machinery_assignments_machinery_id");

            migrationBuilder.RenameIndex(
                name: "IX_warehouse_machinery_code_company_id",
                schema: "public",
                table: "machinery_catalogs",
                newName: "IX_machinery_catalogs_code_company_id");

            migrationBuilder.Sql(@"
                ALTER TABLE public.warehouse_assignments 
                ALTER COLUMN warehouse_keeper_user_id TYPE uuid USING NULLIF(TRIM(warehouse_keeper_user_id), '')::uuid;

                ALTER TABLE public.warehouse_assignments 
                ALTER COLUMN assigned_by_user_id TYPE uuid USING TRIM(assigned_by_user_id)::uuid;

                ALTER TABLE public.machinery_assignments 
                ALTER COLUMN assigned_by_user_id TYPE uuid USING TRIM(assigned_by_user_id)::uuid;
            ");

            migrationBuilder.AddPrimaryKey(
                name: "PK_machinery_catalogs",
                schema: "public",
                table: "machinery_catalogs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_machinery_assignments_machinery_catalogs_machinery_id",
                schema: "public",
                table: "machinery_assignments",
                column: "machinery_id",
                principalSchema: "public",
                principalTable: "machinery_catalogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_machinery_assignments_machinery_catalogs_machinery_id",
                schema: "public",
                table: "machinery_assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_machinery_catalogs",
                schema: "public",
                table: "machinery_catalogs");

            migrationBuilder.RenameTable(
                name: "machinery_catalogs",
                schema: "public",
                newName: "warehouse_machinery",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "machinery_id",
                schema: "public",
                table: "machinery_assignments",
                newName: "machinery_code");

            migrationBuilder.RenameIndex(
                name: "IX_machinery_assignments_machinery_id",
                schema: "public",
                table: "machinery_assignments",
                newName: "IX_machinery_assignments_machinery_code");

            migrationBuilder.RenameIndex(
                name: "IX_machinery_catalogs_code_company_id",
                schema: "public",
                table: "warehouse_machinery",
                newName: "IX_warehouse_machinery_code_company_id");

            migrationBuilder.AlterColumn<string>(
                name: "warehouse_keeper_user_id",
                schema: "public",
                table: "warehouse_assignments",
                type: "character varying(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "assigned_by_user_id",
                schema: "public",
                table: "warehouse_assignments",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "assigned_by_user_id",
                schema: "public",
                table: "machinery_assignments",
                type: "character varying(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_warehouse_machinery",
                schema: "public",
                table: "warehouse_machinery",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_machinery_assignments_warehouse_machinery_machinery_code",
                schema: "public",
                table: "machinery_assignments",
                column: "machinery_code",
                principalSchema: "public",
                principalTable: "warehouse_machinery",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
