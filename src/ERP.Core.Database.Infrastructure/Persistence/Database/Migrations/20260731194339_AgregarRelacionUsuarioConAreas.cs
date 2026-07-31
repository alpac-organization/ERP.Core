using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionUsuarioConAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ===== USERS: int -> uuid =====

            // 1. Crear columna temporal uuid en users
            migrationBuilder.Sql(@"
                ALTER TABLE public.users 
                ADD COLUMN area_id_new uuid NULL;
            ");

            // 2. Poblar la columna temporal mapeando por work_area_code
            migrationBuilder.Sql(@"
                UPDATE public.users u
                SET area_id_new = wa.work_area_id
                FROM public.work_areas wa
                WHERE wa.work_area_code = u.area_id;
            ");

            // 3. Validación defensiva: users sin área mapeable
            migrationBuilder.Sql(@"
                DO $$
                DECLARE
                    huerfanos INT;
                BEGIN
                    SELECT COUNT(*) INTO huerfanos
                    FROM public.users
                    WHERE area_id_new IS NULL;

                    IF huerfanos > 0 THEN
                        RAISE EXCEPTION 'Existen % usuarios sin area_id mapeable a work_areas', huerfanos;
                    END IF;
                END $$;
            ");

            // 4. Reemplazar columna vieja por la nueva
            migrationBuilder.Sql(@"
                ALTER TABLE public.users DROP COLUMN area_id;
                ALTER TABLE public.users RENAME COLUMN area_id_new TO area_id;
                ALTER TABLE public.users ALTER COLUMN area_id SET NOT NULL;
            ");

            // ===== PURCHASE_REQUESTS: nueva columna uuid, poblada desde users =====

            // 5. Agregar area_id como NULLABLE primero (no podemos poner NOT NULL
            //    todavía porque aún no tiene datos válidos)
            migrationBuilder.AddColumn<Guid>(
                name: "area_id",
                schema: "public",
                table: "purchase_requests",
                type: "uuid",
                nullable: true);

            // 6. Poblar area_id de purchase_requests con el área del usuario
            //    que generó la solicitud (users.area_id ya es uuid en este punto)
            migrationBuilder.Sql(@"
                UPDATE public.purchase_requests pr
                SET area_id = u.area_id
                FROM public.users u
                WHERE u.user_id = pr.user_id;
            ");

            // 7. Validación defensiva: purchase_requests sin área mapeable
            migrationBuilder.Sql(@"
                DO $$
                DECLARE
                    huerfanos INT;
                BEGIN
                    SELECT COUNT(*) INTO huerfanos
                    FROM public.purchase_requests
                    WHERE area_id IS NULL;

                    IF huerfanos > 0 THEN
                        RAISE EXCEPTION 'Existen % purchase_requests sin area_id mapeable', huerfanos;
                    END IF;
                END $$;
            ");

            // 8. Ahora sí, forzar NOT NULL
            migrationBuilder.Sql(@"
                ALTER TABLE public.purchase_requests ALTER COLUMN area_id SET NOT NULL;
            ");

            // ===== ÍNDICES =====
            migrationBuilder.CreateIndex(
                name: "IX_users_area_id",
                schema: "public",
                table: "users",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_requests_area_id",
                schema: "public",
                table: "purchase_requests",
                column: "area_id");

            // ===== FOREIGN KEYS =====
            migrationBuilder.AddForeignKey(
                name: "FK_purchase_requests_work_areas_area_id",
                schema: "public",
                table: "purchase_requests",
                column: "area_id",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_work_areas_area_id",
                schema: "public",
                table: "users",
                column: "area_id",
                principalSchema: "public",
                principalTable: "work_areas",
                principalColumn: "work_area_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_requests_work_areas_area_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropForeignKey(
                name: "FK_users_work_areas_area_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_area_id",
                schema: "public",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_purchase_requests_area_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.DropColumn(
                name: "area_id",
                schema: "public",
                table: "purchase_requests");

            migrationBuilder.AlterColumn<int>(
                name: "area_id",
                schema: "public",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}